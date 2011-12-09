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
	public class ApplicationTest {
		private UnifiedProgram _model;

		[SetUp]
		public void SetUp() {
			var inputPath = FixtureUtil.GetInputPath("Java", "default", "Namespace.java");
			var code = File.ReadAllText(inputPath, Encoding.Default);
			_model = JavaFactory.GenerateModel(code);
		}

		[Test]
		public void 関数呼び出しの所属空間を特定できる() {
			var callNode = _model.FirstDescendant<UnifiedCall>();
			var belongingNamespace = Application.GetBelongingNamespace(callNode);
			Console.WriteLine(belongingNamespace.GetNamespaceString());
		}

		[Test]
		public void 自分の親を探して関数の宣言部分を探す() {
			var callNode = _model.FirstDescendant<UnifiedCall>();
			var belongingNamespace = Application.GetBelongingNamespace(callNode);
			Console.WriteLine(belongingNamespace.GetNamespaceString());
			foreach (var ns in belongingNamespace.YieldParents()) {
				var unifiedElement = Application.FindUnifiedElementByNamespace(ns.GetNamespaceString(), _model);
				Console.WriteLine(unifiedElement.Count());
				var element = unifiedElement.First();
				var found = element.Descendants<UnifiedFunctionDefinition>().Where(e => e.Name == callNode.Function);
			}
		}

	}
}
