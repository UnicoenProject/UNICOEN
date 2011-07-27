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
using System.Linq;
using Unicoen.CodeFactories;
using Unicoen.Languages.Java.CodeFactories;
using Unicoen.Model;
using Unicoen.Processor;

namespace Unicoen.Apps.MseConverter {
	/// <summary>
	///   MSEフォーマット上に記述される要素について出力します。
	/// </summary>
	public class MseConvertVisitor : DefaultUnifiedVisitor {
		private readonly Dictionary<IUnifiedElement, int> _package2Id;
		private readonly Dictionary<IUnifiedElement, int> _class2Id;
		private readonly Dictionary<IUnifiedElement, int> _method2Id;
		private readonly Dictionary<IUnifiedElement, int> _attribute2Id;
		private UnifiedClassDefinition _defaultClass;
		private UnifiedNamespaceDefinition _defaultNamespace, _lastGetDefaultNamespace;
		private int _id = 1;

		public TextWriter Writer { get; private set; }
		public CodeFactory CodeFactory { get; set; }
		public int LanguageValue { get; set; }

		public UnifiedClassDefinition DefaultClass {
			get { return _defaultClass; }
			set {
				if (_defaultClass != value) {
					_defaultClass = value;
					_class2Id[_defaultClass] = NextId();
				}
			}
		}

		public UnifiedNamespaceDefinition DefaultNamespace {
			get { return _defaultNamespace; }
			set {
				if (_defaultNamespace != value) {
					_defaultNamespace = value;
					_package2Id[_defaultNamespace] = NextId();

					Writer.Write("(FAMIX.Namespace ");
					Writer.WriteLine("(id: " + _id + ")");
					Writer.WriteLine("(name \'" + CodeFactory.Generate(_defaultNamespace.Name) + "\'))");
				}
			}
		}

		public MseConvertVisitor(TextWriter writer) {
			Writer = writer;
			CodeFactory = new JavaCodeFactory();
			_package2Id = new Dictionary<IUnifiedElement, int>();
			_class2Id = new Dictionary<IUnifiedElement, int>();
			_method2Id = new Dictionary<IUnifiedElement, int>();
			_attribute2Id = new Dictionary<IUnifiedElement, int>();
		}

		private int NextId() {
			return ++_id;
		}

		private static string GetAccessControlQualifier(
				IEnumerable<UnifiedModifier> modifiers) {
			if (modifiers == null)
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
			//すでに登録されているか確認
			int id;
			if (_package2Id.TryGetValue(element, out id)) {
				return;
			}

			//登録されていなければ新しいIdを取得する
			id = NextId();
			_package2Id.Add(element, id);

			//規定のフォーマットを出力
			Writer.Write("(FAMIX.Namespace ");
			Writer.WriteLine("(id: " + id + ")");

			//パッケージ名の出力
			//TODO element.Name as UnifiedVariableIdentifierなどで、CodeGeneratorを使わないようにする
			var packageName = CodeFactory.Generate(element.Name).Replace(".", "::");
			Writer.WriteLine("(name \'" + packageName + "\'))");

			element.TryAcceptAllChildren(this);
		}

		public override void Visit(
				UnifiedClassDefinition element) {
			// パッケージがあるかどうかを確認
			var package = element.Ancestor<UnifiedNamespaceDefinition>()
			              ?? DefaultNamespace;
			var packageId = _package2Id[package];

			//クラス名の取得
			var className = CodeFactory.Generate(element.Name);

			//すでに登録されているか確認
			//登録されていなければ新しいIdを取得する
			int id;
			if (!_class2Id.TryGetValue(element, out id)) {
				id = NextId();
				_class2Id.Add(element, id);
			}

			//規定のフォーマットを出力
			Writer.Write("(FAMIX.Class ");
			Writer.WriteLine("(id: " + id + ")");
			Writer.WriteLine("(name \'" + className + "\')");
			Writer.WriteLine("(belongsTo (idref: " + packageId + "))");

			//抽象クラスかどうかを出力
			var modifiers = element.Modifiers;
			var isAbstract = modifiers != null
			                 && modifiers.Any(m => m.Name == "abstract");
			Writer.WriteLine(isAbstract ? "(isAbstract true)" : "(isAbstract false)");
			Writer.WriteLine("(WMC "+ LanguageValue + ".00))");

			element.TryAcceptAllChildren(this);
		}

		public override void Visit(
				UnifiedFunctionDefinition element) {
			//関数本体がない場合は対象としない
			if (element.Body == null) {
				return;
			}

			var klass = element.Ancestor<UnifiedClassDefinition>() ?? DefaultClass;
			var klassId = _class2Id[klass];

			//関数名の取得
			var functionName = CodeFactory.Generate(element.Name);

			//すでに登録されているか確認
			//登録されていなければ新しいIdを取得する
			int id;
			if (!_method2Id.TryGetValue(element, out id)) {
				id = NextId();
				_method2Id.Add(element, id);
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
			var klass = element.Ancestor<UnifiedClassDefinition>() ?? DefaultClass;
			var klassId = _class2Id[klass];

			//変数名の取得
			var attributeName = CodeFactory.Generate(element.Name);

			//すでに登録されているか確認
			//登録されていなければ新しいIdを取得する
			int id;
			if (!_attribute2Id.TryGetValue(element, out id)) {
				_attribute2Id.Add(element, id);
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