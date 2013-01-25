#region License

// Copyright (C) 2011-2012 The Unicoen Project
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

using System.Linq;
using Code2Xml.Languages.Java.CodeToXmls;
using Code2Xml.Languages.JavaScript.CodeToXmls;
using NUnit.Framework;
using Unicoen.Languages.Java.ProgramGenerators;
using Unicoen.Languages.JavaScript.ProgramGenerators;
using Unicoen.Model;

namespace Unicoen.Sematics.Tests {
	[TestFixture]
	internal class SemanticAnalyzerTest {
		[Test]
		public void IgnoreSliblingScope() {
			var ast = JavaCodeToXml.Instance
					.Generate(
							"{ {int j = 0;} {j = 1;} }",
							p => p.block());
			var codeObject = JavaProgramGeneratorHelper.CreateBlock(ast);

			var variable =
					codeObject.Descendants<UnifiedIdentifier>().ElementAt(2);
			var definition = SemanticAnalyzer.FindDefinition(variable);

			Assert.That(definition, Is.EqualTo(null));
		}

		[Test]
		public void JavascriptBlockProblem() {
			var ast = JavaScriptCodeToXml.Instance
					.Generate(
							"{ i = 0; var j = 0; j = 1; }",
							p => p.statementBlock());
			var codeObject =
					JavaScriptProgramGeneratorHelper.CreateStatementBlock(ast);

			var variable = codeObject.Descendants<UnifiedIdentifier>().Last();
			var definition = SemanticAnalyzer.FindDefinition(variable);

			Assert.That(definition, Is.EqualTo(null));
		}

		[Test]
		public void 後方の変数定義を無視して変数定義オブジェクトを取得できる() {
			var ast = JavaCodeToXml.Instance
					.Generate(
							"{ j = 0; { j = 1; } int j; }",
							p => p.block());
			var codeObject = JavaProgramGeneratorHelper.CreateBlock(ast);

			var variable =
					codeObject.Descendants<UnifiedIdentifier>().ElementAt(1);
			var definition = SemanticAnalyzer.FindDefinition(variable);

			Assert.That(definition, Is.EqualTo(null));
		}

		[Test]
		public void 異なるブロックの変数定義オブジェクトを取得できる() {
			var ast = JavaCodeToXml.Instance
					.Generate(
							"{ int i; { i = 1; } }",
							p => p.block());
			var codeObject = JavaProgramGeneratorHelper.CreateBlock(ast);

			var variable = codeObject.Descendants<UnifiedIdentifier>().Last();
			var definition = SemanticAnalyzer.FindDefinition(variable);

			var expected =
					codeObject.Descendants<UnifiedVariableDefinition>().First();

			Assert.That(definition, Is.EqualTo(expected));
		}

		[Test]
		public void 直前の変数定義オブジェクトを取得できる() {
			var ast = JavaCodeToXml.Instance.Generate(
					"{ int i; i = 1; }", p => p.block());
			var codeObject = JavaProgramGeneratorHelper.CreateBlock(ast);

			var variable = codeObject.Descendants<UnifiedIdentifier>().Last();
			var definition = SemanticAnalyzer.FindDefinition(variable);

			var expected =
					codeObject.Descendants<UnifiedVariableDefinition>().First();

			Assert.That(definition, Is.EqualTo(expected));
		}

		[Test]
		public void 複数の変数定義から正しい変数定義オブジェクトを取得できる() {
			var ast = JavaCodeToXml.Instance
					.Generate(
							"{ int i; int j; int k; { j = 1; } }",
							p => p.block());
			var codeObject = JavaProgramGeneratorHelper.CreateBlock(ast);

			var variable = codeObject.Descendants<UnifiedIdentifier>().Last();
			var definition = SemanticAnalyzer.FindDefinition(variable);

			var expected =
					codeObject.Descendants<UnifiedVariableDefinition>().
							ElementAt(1);

			Assert.That(definition, Is.EqualTo(expected));
		}
	}
}