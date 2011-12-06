using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
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
		}

		public static NameSpace GetPackageName(UnifiedProgram program, string delimiter = ".") {
			var package = new NameSpace();
			var namespaceNodes = program.Descendants<UnifiedNamespaceDefinition>();
			// パッケージ指定がないとき
			if (namespaceNodes.Count() == 0) {
				return new NameSpace() {
						Value = "",
						NamespaceType = NamespaceType.Package,
						FieldScopeType = FieldScopeType.Ignore
				};
			}
			var namespaceNode = namespaceNodes.First();
			if(namespaceNode.Descendants<UnifiedProperty>().Count() == 0) {
				return new NameSpace() {
						Value = namespaceNode.Descendants<UnifiedVariableIdentifier>().First().Name,
						NamespaceType = NamespaceType.Package,
						FieldScopeType = FieldScopeType.Ignore
				};
			}
			var firstProperty = namespaceNode.Descendants<UnifiedProperty>().First();
			return new NameSpace() {
					Value = string.Join(delimiter, firstProperty.Descendants<UnifiedVariableIdentifier>().Select(e => e.Name)),
					NamespaceType = NamespaceType.Package,
					FieldScopeType = FieldScopeType.Ignore
			};
		}
	}

	// 名前空間オブジェクトを表すクラス
	public class NameSpace {
		public string Value { get; set; }
		public NamespaceType NamespaceType { get; set; }
		public FieldScopeType FieldScopeType { get; set; }

		public override string ToString() {
			return Value;
		}
	}

	public enum NamespaceType {
		Package, Class, Function,  
	}
	public enum FieldScopeType {
		ClassField, InstanceField, Ignore
	}

	
}
