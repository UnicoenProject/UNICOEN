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
using Unicoen.Apps.RefactoringDSL.NamespaceDetector;

namespace Unicoen.Apps.RefactoringDSL.Tests.NamespaceDetector {
	public class NamespaceDetectorTest {
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
		public void コード表示用() {
			Console.WriteLine(JavaFactory.GenerateCode(_model));
		}

		[Test]
		public void パッケージ空間名を正しく取得できる() {
			var packageNode = _model.FirstDescendant<UnifiedNamespaceDefinition>();
			var nsString = Detector.GetNamespace(packageNode).ToString();
			const string expected = "pkg.subpkg.subsubpkg.subsubsubpkg";
			Assert.That(nsString, Is.EqualTo(expected));
		}

		[Test]
		public void クラス空間名を正しく取得できる() {
			var targetClass = FindUtil.FindClassByClassName(_model, "Inner").First();
			var nsString = Detector.GetNamespace(targetClass).GetNamespaceString();
			const string expected = "pkg.subpkg.subsubpkg.subsubsubpkg.Cls.Inner";
			Assert.That(nsString, Is.EqualTo(expected));
		}

		[Test]
		public void 関数空間名を正しく取得できる() {
			var targetClass = FindUtil.FindClassByClassName(_model, "Cls").First();
			var functionNode = targetClass.FirstDescendant<UnifiedFunctionDefinition>();
			var nsString = Detector.GetNamespace(functionNode).GetNamespaceString();
			const string expected = "pkg.subpkg.subsubpkg.subsubsubpkg.Cls.method";
			Assert.That(nsString, Is.EqualTo(expected));
			Console.WriteLine(nsString);
		}

		[Test]
		public void 変数空間名を正しく取得できる() {
			var targetClass = FindUtil.FindClassByClassName(_model, "Cls").First();
			var functionNode = targetClass.FirstDescendant<UnifiedVariableDefinition>();
			var nsString = Detector.GetNamespace(functionNode).GetNamespaceString();
			var detailedNsString = Detector.GetNamespace(functionNode).GetDetailedNamespaceString();
			Console.WriteLine(nsString);
		}


		[Test]
		public void For空間名を正しく取得できる() {
			var targetClass = FindUtil.FindClassByClassName(_model, "Cls").First();
			var functionNode = targetClass.FirstDescendant<UnifiedFor>();
			var nsString = Detector.GetNamespace(functionNode).GetNamespaceString();
			var detailedNsString = Detector.GetNamespace(functionNode).GetDetailedNamespaceString();
			Console.WriteLine(nsString);
			Console.WriteLine(detailedNsString);
		}

		[Test]
		public void While空間名を正しく取得できる() {
			var targetClass = FindUtil.FindClassByClassName(_model, "Cls").First();
			var whileNode = targetClass.FirstDescendant<UnifiedWhile>();
			var nsString = Detector.GetNamespace(whileNode).GetNamespaceString();
			var detailedNsString = Detector.GetNamespace(whileNode).GetDetailedNamespaceString();
			Console.WriteLine(nsString);
			Console.WriteLine(detailedNsString);
		}

		[Test]
		public void 名前空間からコードオブジェクトを検索できる() {
			const string nsString = "pkg.subpkg.subsubpkg.subsubsubpkg.Cls.method2.(for)";
			var found = Application.FindUnifiedElementByNamespace(nsString, _model);
			Assert.That(found.Count(), Is.EqualTo(1));
			Assert.IsTrue(found.First() is UnifiedFor);
		}

		[Test]
		public void 名前空間に対応する要素数は必ず1() {
			var variableNodes = _model.Descendants<UnifiedVariableDefinition>();
			Console.WriteLine(variableNodes.Count() + " assertions");
			foreach (var vn in variableNodes) {
				var namespaceString = Detector.GetNamespace(vn).GetNamespaceString();
				Assert.That(Application.FindUnifiedElementByNamespace(namespaceString, _model).Count(), Is.EqualTo(1));
			}
		}



	}



}
