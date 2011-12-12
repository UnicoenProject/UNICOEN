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
			Console.WriteLine(((UnifiedVariableIdentifier)callNode.Function).Name);
			var callingFuncName = ((UnifiedVariableIdentifier)callNode.Function).Name;
			Console.WriteLine(belongingNamespace.GetNamespaceString());

			UnifiedFunctionDefinition parent = null;
			foreach (var ns in belongingNamespace.YieldParents()) {
				var unifiedElement = Application.FindUnifiedElementByNamespace(ns.GetNamespaceString(), _model);
				Console.WriteLine(unifiedElement.Count());
				var element = unifiedElement.First();
				var found = element.Descendants<UnifiedFunctionDefinition>().Where(e => e.Name.Name == callingFuncName);
				if (found.Count() > 0) {
					parent = found.First();
					break;
				}
			}
			if (parent == null) {
				Console.WriteLine("Mitsukaranaiyo!");
			}

			Console.WriteLine(JavaFactory.GenerateCode(parent));
		}

		[Test]
		public void 自分の親を探して変数の宣言部分を探す() {
			// Expression 以下の VariableIdentifier を取り出す
			var viList = new List<UnifiedVariableIdentifier>();
			foreach (var unifiedVariableIdentifiers in _model.Descendants<UnifiedBinaryExpression>().Select(e => e.Descendants<UnifiedVariableIdentifier>())) {
				foreach (var uvi in unifiedVariableIdentifiers) {
					viList.Add(uvi);
				}
			}
			foreach (var unifiedVariableIdentifiers in _model.Descendants<UnifiedUnaryExpression>().Select(e => e.Descendants<UnifiedVariableIdentifier>())) {
				foreach (var uvi in unifiedVariableIdentifiers) {
					viList.Add(uvi);
				}
			}
			foreach (var unifiedVariableIdentifiers in _model.Descendants<UnifiedTernaryExpression>().Select(e => e.Descendants<UnifiedVariableIdentifier>())) {
				foreach (var uvi in unifiedVariableIdentifiers) {
					viList.Add(uvi);
				}
			}

			Console.WriteLine(viList.Count);
			foreach (var vi in viList) {
				Console.WriteLine(vi);
			}

		}

		[Test]
		public void 関数が呼ばれている部分を探す() {
			var fdNode = _model.FirstDescendant<UnifiedFunctionDefinition>();
			var brothers = GetBrotherNode(fdNode);
			foreach (var brother in brothers) {
				var callNodes = brother.Descendants<UnifiedCall>();
			}




		}

		// 自分の兄弟ノード（自分も含む）を取得する
		public static IEnumerable<IUnifiedElement> GetBrotherNode(UnifiedElement node) {
			return node.FirstAncestor<IUnifiedElement>().Descendants();
		}

	}
}
