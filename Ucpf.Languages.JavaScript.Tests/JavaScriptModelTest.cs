using System;
using System.Linq;
using NUnit.Framework;
using Ucpf.Common.Model;
using Ucpf.Common.OldModel.Operators;
using Ucpf.Common.Tests;
using Ucpf.Languages.JavaScript.AstGenerators;
using Ucpf.Languages.JavaScript.Model;
using Ucpf.Languages.JavaScript.Model.Expressions;
using Ucpf.Languages.JavaScript.Model.Statements;

namespace Ucpf.Languages.JavaScript.Tests {
	[TestFixture]
	public class JavaScriptModelTest {
		private static readonly string InputPath =
			Fixture.GetInputPath("JavaScript", "fibonacci.js");

		[Test]
		public void If文の条件式を取得する() {
			//actual
			var ast = JavaScriptAstGenerator.Instance.GenerateFromFile(InputPath);
			var root = ast.Descendants("functionDeclaration").First();
			var func = JSModelFactory.CreateFunction(root);
			var body = func.Block;
			var exp = (UnifiedExpressionStatement)body.First();
			var ifst = (UnifiedIf)exp.Expression;
			var cond = ifst.Condition;

			//expectation
			var expectation = new UnifiedBinaryExpression {
				LeftHandSide = new UnifiedLiteral {Value = "n"},
				Operator = new UnifiedBinaryOperator("<", BinaryOperatorType.Lesser),
				RightHandSide = new UnifiedLiteral {Value = "2"},
			};

			Assert.That(cond, Is.EqualTo(expectation)
				.Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		public void 一番最初に宣言されている関数のパラメータを取得する() {
			//actual
			var ast = JavaScriptAstGenerator.Instance.GenerateFromFile(InputPath);
			var root = ast.Descendants("functionDeclaration").First();
			var func = JSModelFactory.CreateFunction(root);
			var firstParam = func.Parameters.First();

			//expectation
			var expectation = new UnifiedParameter("n");

			Assert.That(firstParam, Is.EqualTo(expectation)
				.Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		public void 一番最初に宣言されている関数名を取得する() {
			var ast = JavaScriptAstGenerator.Instance.GenerateFromFile(InputPath);
			var root = ast.Descendants("functionDeclaration").First();
			var func = JSModelFactory.CreateFunction(root);

			Assert.That(func.Name, Is.EqualTo("fibonacci"));
		}

		[Test]
		public void 一番最初のreturn文を取得する() {
			//actual
			var ast = JavaScriptAstGenerator.Instance.GenerateFromFile(InputPath);
			var root = ast.Descendants("functionDeclaration").First();
			var func = JSModelFactory.CreateFunction(root);
			var body = func.Block;
			var exp = (UnifiedExpressionStatement)body.First();
			var ifst = (UnifiedIf)exp.Expression;
			var trbl = ifst.TrueBlock;
			var ret = trbl.First();

			//expectation
			var expectation = new UnifiedReturn(
				new UnifiedLiteral {
					Value = "n"
				}
				);

			Assert.That(ret, Is.EqualTo(expectation)
				.Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		public void 二項演算子を取得する() {
			//actual
			var ast = JavaScriptAstGenerator.Instance.GenerateFromFile(InputPath);
			var root = ast.Descendants("functionDeclaration").First();
			var func = JSModelFactory.CreateFunction(root);
			var body = func.Block;
			var exp  = (UnifiedExpressionStatement)body.First();
			var ifst = (UnifiedIf)exp.Expression;
			var elbl = ifst.FalseBlock;
			var ret  = (UnifiedReturn)elbl.First();
			var bin  = (UnifiedBinaryExpression)ret.Value;

			Assert.That(bin.Operator.Sign, Is.EqualTo("+"));
		}

		[Test]
		public void 呼び出す関数の名前を取得する() {
			//actual
			var ast = JavaScriptAstGenerator.Instance.GenerateFromFile(InputPath);
			var root = ast.Descendants("functionDeclaration").First();
			var func = JSModelFactory.CreateFunction(root);
			var body = func.Block;
			var stex = (UnifiedExpressionStatement)body.First();
			var ifst = (UnifiedIf)stex.Expression;
			var elbl = ifst.FalseBlock;
			var ret  = (UnifiedReturn)elbl.First();
			var exp  = (UnifiedBinaryExpression)ret.Value;
			var call = (UnifiedCall)exp.LeftHandSide;
			var f = (UnifiedVariable)call.Function;

			Assert.That(f.Name, Is.EqualTo("fibonacci"));
		}

		[Test]
		public void 呼び出す関数の引数を取得する() {
			var ast = JavaScriptAstGenerator.Instance.GenerateFromFile(InputPath);
			var root = ast.Descendants("functionDeclaration").First();
			var func = JSModelFactory.CreateFunction(root);
			var body = func.Block;
			var stex = (UnifiedExpressionStatement)body.First();
			var ifst = (UnifiedIf)stex.Expression;
			var elbl = ifst.FalseBlock;
			var ret  = (UnifiedReturn)elbl.First();
			var exp  = (UnifiedBinaryExpression)ret.Value;
			var call = (UnifiedCall)exp.LeftHandSide;
			var e = call.Arguments.First().Value;

			//expectation
			var expectation = new UnifiedBinaryExpression {
				LeftHandSide = new UnifiedLiteral {Value = "n"},
				Operator = new UnifiedBinaryOperator("-", BinaryOperatorType.Subtraction),
				RightHandSide = new UnifiedLiteral {Value = "1"},
			};

			Assert.That(e, Is.EqualTo(expectation)
				.Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		public void 返却される式を取得する() {
			//actual
			var ast = JavaScriptAstGenerator.Instance.GenerateFromFile(InputPath);
			var root = ast.Descendants("functionDeclaration").First();
			var func = JSModelFactory.CreateFunction(root);
			var body = func.Block;
			var stex = (UnifiedExpressionStatement)body.First();
			var ifst = (UnifiedIf)stex.Expression;
			var elbl = ifst.FalseBlock;
			var ret = (UnifiedReturn)elbl.First();
			var exp = (UnifiedBinaryExpression)ret.Value;

			//expectation
			var expectation = new UnifiedBinaryExpression {
				LeftHandSide = new UnifiedCall {
					Arguments = new UnifiedArgumentCollection {
						new UnifiedArgument {
							Value = new UnifiedBinaryExpression {
								LeftHandSide = new UnifiedLiteral {
									Value = "n"
								},
								Operator = new UnifiedBinaryOperator("-", BinaryOperatorType.Subtraction),
								RightHandSide = new UnifiedLiteral {
									Value = "1"
								}
							}
						}
					},
					Function = new UnifiedVariable("fibonacci")
				},
				Operator = new UnifiedBinaryOperator("+", BinaryOperatorType.Addition),
				RightHandSide = new UnifiedCall {
					Arguments = new UnifiedArgumentCollection {
						new UnifiedArgument {
							Value = new UnifiedBinaryExpression {
								LeftHandSide = new UnifiedLiteral {
									Value = "n"
								},
								Operator = new UnifiedBinaryOperator("-", BinaryOperatorType.Subtraction),
								RightHandSide = new UnifiedLiteral {
									Value = "2"
								}
							}
						}
					},
					Function = new UnifiedVariable("fibonacci")
				},
			};

			Assert.That(exp, Is.EqualTo(expectation)
				.Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		public void 関数内のステートメントを取得する() {
			//actual
			var ast = JavaScriptAstGenerator.Instance.GenerateFromFile(InputPath);
			var root = ast.Descendants("functionDeclaration").First();
			var func = JSModelFactory.CreateFunction(root);
			var body = func.Block;
			var str1 = body.First();

			Assert.That(str1.GetType(), Is.EqualTo(typeof(UnifiedExpressionStatement)));
		}
	}
}