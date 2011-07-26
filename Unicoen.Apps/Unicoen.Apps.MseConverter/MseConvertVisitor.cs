#region License

// Copyright (C) 2011 The Unicoen Project
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System;
using System.Collections.Generic;
using System.IO;
using Unicoen.CodeFactories;
using Unicoen.Model;
using Unicoen.Processor;

namespace Unicoen.Apps.MseConverter {

	/// <summary>
	///   MSEフォーマット上に記述される要素について出力します。
	/// </summary>
	public partial class MseConvertVisitor : DefaultUnifiedVisitor {
		public TextWriter Writer { get; private set; }
		public CodeFactory CodeFactory { get; private set; }

		private Dictionary<string, int> package2Id;
		private Dictionary<IUnifiedElement, int> class2Id;
		private Dictionary<IUnifiedElement, int> method2Id;
		private Dictionary<IUnifiedElement, int> attribute2Id;
	
		private int _id = 2;
		private UnifiedClassDefinition _anonymousClass = UnifiedClassDefinition.Create();

		public MseConvertVisitor(TextWriter writer, CodeFactory codeFactory) {
			Writer = writer;
			CodeFactory = codeFactory;
			package2Id = new Dictionary<string, int>();
			class2Id = new Dictionary<IUnifiedElement, int>();
			method2Id = new Dictionary<IUnifiedElement, int>();
			attribute2Id = new Dictionary<IUnifiedElement, int>();
		}

		private int NextId() {
			return _id++;
		}

		private static string GetAccessControlQualifier(
				IEnumerable<UnifiedModifier> modifiers) {
			foreach (var modifier in modifiers) {
				switch (modifier.Name) {
				case "public":
					return "public";
				case "private":
					return "private";
				case "protected":
					return "protected";
				}
			}
			return "public";
		}

		public override void Visit(
				UnifiedNamespaceDefinition element) {

			//パッケージ名の取得
			var buffer = new StringWriter();
			CodeFactory.Generate(element.Name, buffer);
			var packageName = buffer.ToString();

			//すでに登録されているか確認
			int id;
			package2Id.TryGetValue(packageName, out id);

			if(id != 0) {
				element.Body.TryAccept(this);
				return;
			}

			//登録されていなければ新しいIdを取得する
			id = NextId();
				package2Id.Add(packageName, id);

			//規定のフォーマットを出力
			Writer.Write("(FAMIX.Namespace ");
			Writer.WriteLine("(id: " + id + ")");

			//パッケージ名の出力
			packageName = packageName.Replace(".", "::");
			Writer.WriteLine("(name \'" + packageName + "\'))");

			//パッケージ内のコードについて探査する
			element.Body.TryAccept(this);
		}



		public override void Visit(
				UnifiedClassDefinition element) {

			//クラス名の取得
			var buffer = new StringWriter();
			CodeFactory.Generate(element.Name, buffer);
			var className = buffer.ToString();

			//すでに登録されているか確認
			int id;
			class2Id.TryGetValue(element, out id);
			
			//登録されていなければ新しいIdを取得する
			if(id == 0) {
				id = NextId();
				class2Id.Add(element, id);
			}

			//規定のフォーマットを出力
			Writer.Write("(FAMIX.Class ");
			Writer.WriteLine("(id: " + id + ")");

			Writer.WriteLine("(name \'" + className + "\')");

			//パッケージ化されているパッケージIDを出力
			buffer = new StringWriter();
			var package = element.Ancestor<UnifiedNamespaceDefinition>();
			if(package != null) {
				CodeFactory.Generate(package.Name, buffer);
				package2Id.TryGetValue(buffer.ToString(), out id);
			} 
			else {
				if(!package2Id.TryGetValue("__anonymous", out id)) {
					id = NextId();
					package2Id.Add("__anonymous", id);
				}
			}
			Writer.WriteLine("(belongsTo (idref: " + id + "))");

			//抽象クラスかどうかを出力
			var isAbstract = false;
			var modifiers = element.Modifiers;
			foreach (var modifier in modifiers) {
				if (modifier.Name == "abstract")
					isAbstract = true;
			}
			Writer.WriteLine(isAbstract ? "(isAbstract true))" : "(isAbstract false))");

			element.Body.TryAccept(this);
		}

		public override void Visit(
				UnifiedFunctionDefinition element) {
			//関数名の取得
			var buffer = new StringWriter();
			CodeFactory.Generate(element.Name, buffer);
			var functionName = buffer.ToString();

			//すでに登録されているか確認
			int id;
			method2Id.TryGetValue(element, out id);
			
			//登録されていなければ新しいIdを取得する
			if(id == 0) {
				id = NextId();
				method2Id.Add(element, id);
			}

			//規定のフォーマットを出力
			Writer.Write("(FAMIX.Method ");
			Writer.WriteLine("(id: " + id + ")");

			Writer.WriteLine("(name \'" + functionName + "\')");

			Writer.WriteLine(
					"(accessControlQualifier \'" +
					GetAccessControlQualifier(element.Modifiers) + "\')");

			var klass = element.Ancestor<UnifiedClassDefinition>();
			if(klass != null) {
				class2Id.TryGetValue(klass, out id);
			} 
			else {
				if(!class2Id.TryGetValue(_anonymousClass, out id)) {
					id = NextId();
					class2Id.Add(_anonymousClass, id);
				}
			}
			Writer.WriteLine("(belongsTo (idref: " + id + "))");
			//TODO LOCの計算
			Writer.WriteLine("(LOC 100)");

			/*
			buffer = new StringWriter();
			CodeFactory.Generate(element.Ancestor<UnifiedNamespaceDefinition>().Name, buffer);
			package2Id.TryGetValue(buffer.ToString(), out id);			
			Writer.WriteLine("(packagedIn (idref: " + id + "))");
			*/

			/*
			Writer.Write("(signature \'");
			CodeFactory.Generate(element.Name, Writer);
			CodeFactory.Generate(element.Parameters, Writer);
			Writer.WriteLine("\'))");
			*/
		}

		public override void Visit(
				UnifiedVariableDefinitionList element) {
			foreach (var variableDefinition in element) {
				variableDefinition.TryAccept(this);
			}
		}

		public override void Visit(UnifiedVariableDefinition element) {
			//変数名の取得
			var buffer = new StringWriter();
			CodeFactory.Generate(element.Name, buffer);
			var attributeName = buffer.ToString();

			//すでに登録されているか確認
			int id;
			attribute2Id.TryGetValue(element, out id);
			
			//登録されていなければ新しいIdを取得する
			if(id == 0) {
				attribute2Id.Add(element, id);
				id = NextId();
			}

			//規定のフォーマットを出力
			Writer.Write("(FAMIX.Attribute ");
			Writer.WriteLine("(id: " + id + ")");

			Writer.WriteLine("(name \'" + attributeName + "\')");

			Writer.WriteLine(
					"(accessControlQualifier \'" +
					GetAccessControlQualifier(element.Modifiers) + "\')");

			var klass = element.Ancestor<UnifiedClassDefinition>();
			if(klass != null) {
				class2Id.TryGetValue(klass, out id);
			}
			else {
				id = 3;
			}
			Writer.WriteLine("(belongsTo (idref: " + id + ")))");
		}

		public override void Visit(UnifiedCall element) {

			return;

			var id = NextId();
			Writer.Write("(FAMIX.Invocation ");
			Writer.WriteLine("(id: " + id + ")");

			//TODO どうやってメソッド定義のidを取得するか
			//Writer.Write("(candidate (idref: ");

			//一時的にコメントアウトします
			//Writer.Write("(invokedBy (idref: " + _currentClass + "))");

			Writer.Write("(invokes '");
			CodeFactory.Generate(element, Writer);
			Writer.WriteLine("')");

			Writer.WriteLine("(stub false))");
		}

		public override void Visit(UnifiedConstructor element) {
			//TODO コンストラクタはMethodに含まれるのか確認
			//element.Body.TryAccept(this);
		}
	}
}