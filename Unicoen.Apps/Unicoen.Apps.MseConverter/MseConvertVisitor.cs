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
		private Dictionary<string, int> class2Id;
		private Dictionary<string, int> method2Id;
		private Dictionary<string, int> attribute2Id;

	
		private int _id = 2;
		private int _currentPackage;
		private int _currentClass;

		public MseConvertVisitor(TextWriter writer, CodeFactory codeFactory) {
			Writer = writer;
			CodeFactory = codeFactory;
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
			var id = NextId();
			Writer.Write("(FAMIX.Package ");
			Writer.WriteLine("(id: " + id + ")");
			_currentPackage = id;

			//パッケージ名の出力
			Writer.Write("(name \'");
			CodeFactory.Generate(element.Name, Writer);
			Writer.WriteLine("\'))");

			element.Body.TryAccept(this);
		}

		public override void Visit(
				UnifiedClassDefinition element) {
			var id = NextId();
			Writer.Write("(FAMIX.Class ");
			Writer.WriteLine("(id: " + id + ")");
			_currentClass = id;

			Writer.Write("(name \'");
			element.Name.TryAccept(this);
			Writer.WriteLine("\')");

			//パッケージ化されているパッケージIDを出力
			Writer.WriteLine("(packagedIn (idref: " + _currentPackage + "))");

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
			var id = NextId();
			Writer.Write("(FAMIX.Method ");
			Writer.WriteLine("(id: " + id + ")");

			Writer.Write("(name \'");
			element.Name.TryAccept(this);
			Writer.WriteLine("\')");

			Writer.WriteLine(
					"(accessControlQualifier \'" +
					GetAccessControlQualifier(element.Modifiers) + "\')");

			Writer.WriteLine("(belongsTo (idref: " + _currentClass + "))");
			//TODO LOCの計算
			Writer.WriteLine("(LOC 100)");
			Writer.WriteLine("(packagedIn (idref: " + _currentPackage + "))");

			Writer.Write("(signature \'");
			CodeFactory.Generate(element.Name, Writer);
			CodeFactory.Generate(element.Parameters, Writer);
			Writer.WriteLine("\'))");
		}

		public override void Visit(
				UnifiedVariableDefinitionList element) {
			foreach (var variableDefinition in element) {
				variableDefinition.TryAccept(this);
			}
		}

		public override void Visit(UnifiedVariableDefinition element) {
			var id = NextId();
			Writer.Write("(FAMIX.Attribute ");
			Writer.WriteLine("(id: " + id + ")");

			Writer.Write("(name \'");
			CodeFactory.Generate(element.Name, Writer);
			Writer.WriteLine("\')");

			Writer.WriteLine(
					"(accessControlQualifier \'" +
					GetAccessControlQualifier(element.Modifiers) + "\')");

			Writer.WriteLine("(belongsTo (idref: " + _currentClass + ")))");
		}

		public override void Visit(UnifiedCall element) {
			var id = NextId();
			Writer.Write("(FAMIX.Invocation ");
			Writer.WriteLine("(id: " + id + ")");

			//TODO どうやってメソッド定義のidを取得するか
			//Writer.Write("(candidate (idref: ");

			Writer.Write("(invokedBy (idref: " + _currentClass + "))");

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