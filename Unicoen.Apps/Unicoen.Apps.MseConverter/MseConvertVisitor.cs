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
using System.Linq;
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
		
		private UnifiedClassDefinition _anonymousClass;
		public void SetAnonymousClass(UnifiedClassDefinition newClass) {
			_anonymousClass = newClass;
		}


		private string _filename;
		public void SetFilename(string name) {
			_filename = name;
		}

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
			if(modifiers == null)
				return "";

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
			//TODO element.Name as UnifiedVariableIdentifierなどで、COdeGeneratorを使わないようにする
			CodeFactory.Generate(element.Name, buffer);
			var packageName = buffer.ToString();

			//すでに登録されているか確認
			int id;
			package2Id.TryGetValue(packageName, out id);

			if(id != 0) {
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

			element.TryAcceptAllChildren(this);
		}



		public override void Visit(
				UnifiedClassDefinition element) {
			var buffer = new StringWriter();

			//パッケージがあるかどうかを確認
			int packageId;
			var package = element.Ancestor<UnifiedNamespaceDefinition>();
			
			//ある場合
			if(package != null) {
				CodeFactory.Generate(package.Name, buffer);
				package2Id.TryGetValue(buffer.ToString(), out packageId);
			} 
			//ない場合
			else{
				//仮のパッケージが定義されているか確認
				package2Id.TryGetValue(_filename, out packageId);
				//パッケージがない場合は、仮のパッケージを作る
				if(packageId == 0) {
					var newPackage = 
						UnifiedNamespaceDefinition.Create(null, null, UnifiedVariableIdentifier.Create(_filename));
					newPackage.TryAccept(this);
					//新しい登録したパッケージのidを取得する
					package2Id.TryGetValue(_filename, out packageId);
					if(packageId == 0)
						throw new InvalidOperationException();
				}
			}

			//クラス名の取得
			buffer = new StringWriter();
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
			Writer.WriteLine("(belongsTo (idref: " + packageId + "))");

			//抽象クラスかどうかを出力
			var modifiers = element.Modifiers;
			var isAbstract = modifiers != null && modifiers.Any(m => m.Name == "abstract");
			Writer.WriteLine(isAbstract ? "(isAbstract true))" : "(isAbstract false))");

			element.TryAcceptAllChildren(this);
		}

		public override void Visit(
				UnifiedFunctionDefinition element) {
			//関数本体がない場合は対象としない
			if (element.Body == null) {
				return;
			}

			int klassId;
			var klass = element.Ancestor<UnifiedClassDefinition>();
			//クラスがある場合
			if(klass != null) {
				class2Id.TryGetValue(klass, out klassId);
			}
			//クラスがない場合
			else {
				//仮のクラスが定義されているか確認
				class2Id.TryGetValue(_anonymousClass, out klassId);
				if(klassId == 0) {
					_anonymousClass.TryAccept(this);
					//新しく登録したクラスのidを取得する
					class2Id.TryGetValue(_anonymousClass, out klassId);
					if(klassId == 0)
						throw new InvalidOperationException();
				}
			}
			
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
			Writer.WriteLine("(belongsTo (idref: " + klassId + "))");
			var loc = element.Body.Descendants<IUnifiedExpression>()
					.Where(e => e.Parent is UnifiedBlock)
					.Count();
			Writer.WriteLine("(LOC " + loc + "))");
		}

		public override void Visit(UnifiedVariableDefinition element) {
			int klassId;
			var klass = element.Ancestor<UnifiedClassDefinition>();
			//クラスがある場合
			if(klass != null) {
				class2Id.TryGetValue(klass, out klassId);
			}
			//クラスがない場合
			else {
				//仮のクラスが定義されているか確認
				class2Id.TryGetValue(_anonymousClass, out klassId);
				if(klassId == 0) {
					_anonymousClass.TryAccept(this);
					//新しく登録したクラスのidを取得する
					class2Id.TryGetValue(_anonymousClass, out klassId);
					if(klassId == 0)
						throw new InvalidOperationException();
				}
			}

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
			Writer.WriteLine("(belongsTo (idref: " + klassId + ")))");

			element.TryAcceptAllChildren(this);
		}

		public override void Visit(UnifiedCall element) {
			element.TryAcceptAllChildren(this);
			return;
			//TODO 将来的にはCall,Accessも実装する
		}
	}
}