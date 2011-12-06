using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Unicoen.Apps.RefactoringDSL.Util;
using Unicoen.Languages.Java;
using Unicoen.Model;
using Unicoen.Tests;
using Unicoen.Apps.RefactoringDSL;

namespace Unicoen.Apps.RefactoringDSL.Tests.NamespaceDetector {
	class NamespaceDetectorTest {
		private UnifiedProgram _model;

		[SetUp]
		public void SetUp() {
			var inputPath = FixtureUtil.GetInputPath("Java", "default", "Namespace.java");
			var code = File.ReadAllText(inputPath, Encoding.Default);
			_model = JavaFactory.GenerateModel(code);
		}

		[Test]
		public void Xml表示用() {
			Console.WriteLine(_model.ToXml());
		}
		[Test]
		public void パッケージ名など最上位名前空間を取得するテスト() {
			var package = GetPackageName(_model);
			Console.WriteLine(package);
		}

		[Test]
		public void クラスの名前空間を取得するテスト() {
			var targetClass = FindUtil.FindClassByClassName(_model, "Cls").First();
			var className = targetClass.Descendants<UnifiedVariableIdentifier>().First().Name;
			Console.WriteLine(className);
			var ns = new Namespace() {
				Value = className,
				NamespaceType = NamespaceType.Class,
				FieldScopeType = FieldScopeType.Ignore,
			};

		}

		public static Namespace GetPackageName(UnifiedProgram program, string delimiter = ".") {
			var package = new Namespace();
			var namespaceNodes = program.Descendants<UnifiedNamespaceDefinition>();
			// パッケージ指定がないとき
			if (namespaceNodes.Count() == 0) {
				return new Namespace() {
					Parent = null,
					Value = "",
					NamespaceType = NamespaceType.Package,
					FieldScopeType = FieldScopeType.Ignore
				};
			}
			var namespaceNode = namespaceNodes.First();
			if (namespaceNode.Descendants<UnifiedProperty>().Count() == 0) {
				return new Namespace() {
					Parent = null,
					Value = namespaceNode.Descendants<UnifiedVariableIdentifier>().First().Name,
					NamespaceType = NamespaceType.Package,
					FieldScopeType = FieldScopeType.Ignore
				};
			}
			var firstProperty = namespaceNode.Descendants<UnifiedProperty>().First();
			return new Namespace() {
				Parent = null,
				Value = string.Join(delimiter, firstProperty.Descendants<UnifiedVariableIdentifier>().Select(e => e.Name)),
				NamespaceType = NamespaceType.Package,
				FieldScopeType = FieldScopeType.Ignore
			};
		}

		// 自分の親になりうる，かつ，名前空間構成要素になり得る要素タイプを返却する
		public static NamespaceType[] GetParentTypes(NamespaceType type) {
			switch(type) {
				case NamespaceType.Package:
					return new NamespaceType[] { };
				case NamespaceType.Class:
					return new NamespaceType[] { NamespaceType.Class, NamespaceType.Package };
				case NamespaceType.Function:
					return new NamespaceType[] { NamespaceType.Class, NamespaceType.Package, NamespaceType.Function};
				default:
					throw new InvalidOperationException();

			}
		}

		// タイプから型へ変換（上へトラバースするときに使う）
		public static Type Namespace2UnifiedType(NamespaceType type) {
			switch(type) {
				case NamespaceType.Package:
					return UnifiedNamespaceDefinition.Create().GetType();
				case NamespaceType.Class:
					return UnifiedClassDefinition.Create().GetType();
				case NamespaceType.Function:
					return UnifiedFunctionDefinition.Create().GetType();
				default:
					throw new InvalidOperationException();

			}
			
		}
	}

	// 名前空間オブジェクトを表すクラス
	public class Namespace {
		public Namespace Parent { get; set; }
		public string Value { get; set; }
		public NamespaceType NamespaceType { get; set; }
		public FieldScopeType FieldScopeType { get; set; }

		public override string ToString() {
			return Value;
		}

		// 自分を含めて親を全部たどって，名前空間文字列くっつける
		public string GetNamespaceString(string delimiter = ".") {
			var ns = "";
			while(this.Parent == null) {
				ns += this.Value;
			}

			return ns;
		}
	}


	// 名前空間を作りうる言語要素
	public enum NamespaceType {
		Package, Class, Function,
	}


	public enum FieldScopeType {
		ClassField, InstanceField, Ignore
	}


}
