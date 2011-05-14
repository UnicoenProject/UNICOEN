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

using System.Linq;
using System.Xml.Linq;
using Code2Xml.Languages.JavaScript.CodeToXmls;
using NUnit.Framework;
using Unicoen.Core.Model;
using Unicoen.Core.Tests;
using Unicoen.Languages.JavaScript.ModelFactories;

namespace Unicoen.Languages.JavaScript.Tests {
	[Ignore, TestFixture]
	public class JavaScriptModelTest {
		private static readonly string InputPath =
				FixtureUtil.GetInputPath("JavaScript", "fibonacci.js");

		[SetUp]
		public void SetUp() {
			_ast = JavaScriptCodeToXml.Instance.GenerateFromFile(InputPath);
			_root = _ast.Descendants("functionDeclaration").First();
			_func = JavaScriptModelFactoryHelper.CreateFunctionDeclaration(_root);
		}

		private XElement _ast;
		private XElement _root;
		private UnifiedFunctionDefinition _func;

		[Test]
		public void If文の条件式を取得する() {
			//actual
			var block = _func.Body;
			var expStmt = block.First() as UnifiedIf;
			if (expStmt == null) return;
			var cond = expStmt.Condition;

			//expectation
			var expectation =
					UnifiedBlock.Create(
							UnifiedBinaryExpression.Create(
									UnifiedIdentifier.CreateVariable("n"),
									UnifiedBinaryOperator.Create("<", UnifiedBinaryOperatorKind.LessThan),
									UnifiedIntegerLiteral.CreateBigInteger(2)
									)
							);

			Assert.That(
					cond, Is.EqualTo(expectation)
					      		.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Test]
		public void 一番最初に宣言されている関数のパラメータを取得する() {
			//actual
			var firstParam = _func.Parameters.First();

			//expectation
			var expectation = UnifiedParameter.Create(
					null,
					null, null, UnifiedIdentifier.CreateVariable("n").ToCollection(),
					null);

			Assert.That(
					firstParam, Is.EqualTo(expectation)
					            		.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Test]
		public void 一番最初に宣言されている関数名を取得する() {
			Assert.That(_func.Name.Value, Is.EqualTo("fibonacci"));
		}

		[Test]
		public void 一番最初のreturn文を取得する() {
			//actual
			var block = _func.Body;
			var expStmt = block.First();
			var ifStmt = (UnifiedIf)expStmt;
			var tBlock = ifStmt.Body;
			var returnStmt = tBlock.First();

			//expectation
			var expectation =
					UnifiedBlock.Create(
							UnifiedSpecialExpression.CreateReturn(
									UnifiedBlock.Create(
											UnifiedIdentifier.CreateVariable("n")
											)
									)
							);

			Assert.That(
					returnStmt, Is.EqualTo(expectation)
					            		.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Test]
		public void 二項演算子を取得する() {
			//actual
			var block = _func.Body;
			var expStmt = block.First();
			var ifStmt = (UnifiedIf)expStmt;
			var fBlock = ifStmt.ElseBody;
			var returnStmt = (UnifiedSpecialExpression)fBlock.First();
			var binaryExp = (UnifiedBinaryExpression)returnStmt.Value;

			Assert.That(binaryExp.Operator.Sign, Is.EqualTo("+"));
		}

		[Test]
		public void 呼び出す関数の名前を取得する() {
			//actual
			var block = _func.Body;
			var expStmt = block.First();
			var ifStmt = (UnifiedIf)expStmt;
			var fBlock = ifStmt.ElseBody;
			var returnStmt = (UnifiedSpecialExpression)fBlock.First();
			var binaryExp = (UnifiedBinaryExpression)returnStmt.Value;
			var callExp = (UnifiedCall)binaryExp.LeftHandSide;
			var identifier = (UnifiedIdentifier)callExp.Function;

			Assert.That(identifier.Value, Is.EqualTo("fibonacci"));
		}

		[Test]
		public void 呼び出す関数の引数を取得する() {
			var block = _func.Body;
			var ifStmt = block.First() as UnifiedIf;
			if (ifStmt == null) return;
			var fBlock = ifStmt.ElseBody;
			var returnStmt =
					(UnifiedSpecialExpression)
					ModelSweeper.Descendants(fBlock).Where(e => e is UnifiedSpecialExpression).
							First();
			var binaryExp = (UnifiedBinaryExpression)returnStmt.Value;
			var callExp = (UnifiedCall)binaryExp.LeftHandSide;
			var firstArg = callExp.Arguments.First().Value;

			//expectation
			var expectation =
					UnifiedBinaryExpression.Create(
							UnifiedIdentifier.CreateUnknown("n"),
							UnifiedBinaryOperator.Create("-", UnifiedBinaryOperatorKind.Subtract),
							UnifiedIntegerLiteral.Create(1));

			Assert.That(
					firstArg, Is.EqualTo(expectation)
					          		.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Test]
		public void 返却される式を取得する() {
			//actual
			var block = _func.Body;
			var expStmt = block.First();
			var ifStmt = (UnifiedIf)expStmt;
			var fBlock = ifStmt.ElseBody;
			var returnStmt = (UnifiedSpecialExpression)fBlock.First();
			var binaryExp = (UnifiedBinaryExpression)returnStmt.Value;

			//expectation
			var expectation = UnifiedBinaryExpression.Create(
					UnifiedCall.Create(
							UnifiedIdentifier.CreateUnknown("fibonacci"),
							UnifiedArgumentCollection.Create(
									UnifiedArgument.Create(
											UnifiedBinaryExpression.Create(
													UnifiedIdentifier.CreateUnknown("n"),
													UnifiedBinaryOperator.Create(
															"-", UnifiedBinaryOperatorKind.Subtract),
													UnifiedIntegerLiteral.Create(1)
													))
									)
							),
					UnifiedBinaryOperator.Create("+", UnifiedBinaryOperatorKind.Add),
					UnifiedCall.Create(
							UnifiedIdentifier.CreateUnknown("fibonacci"),
							UnifiedArgumentCollection.Create(
									UnifiedArgument.Create(
											UnifiedBinaryExpression.Create(
													UnifiedIdentifier.CreateUnknown("n"),
													UnifiedBinaryOperator.Create(
															"-",
															UnifiedBinaryOperatorKind.Subtract),
													UnifiedIntegerLiteral.Create(2)
													))
									)
							)
					);

			Assert.That(
					binaryExp, Is.EqualTo(expectation)
					           		.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Test]
		public void 関数内のステートメントを取得する() {
			//actual
			var block = _func.Body;
			var firstStmt = block.First();

			Assert.That(firstStmt, Is.InstanceOf<IUnifiedExpression>());
		}
	}
}