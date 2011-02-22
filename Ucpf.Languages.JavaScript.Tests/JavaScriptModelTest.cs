using System.Linq;
using System.Xml.Linq;
using NUnit.Framework;
using Ucpf.Common.Model;
using Ucpf.Common.OldModel.Operators;
using Ucpf.Common.Tests;
using Ucpf.Languages.JavaScript.AstGenerators;
using Ucpf.Languages.JavaScript.Model;

namespace Ucpf.Languages.JavaScript.Tests {
	[TestFixture]
	public class JavaScriptModelTest {
		private static readonly string InputPath =
			Fixture.GetInputPath("JavaScript", "fibonacci.js");

		[SetUp]
		public void SetUp() {
			_ast = JavaScriptAstGenerator.Instance.GenerateFromFile(InputPath);
			_root = _ast.Descendants("functionDeclaration").First();
			_func = JSModelFactory.CreateFunction(_root);
		}


		private XElement _ast;
		private XElement _root;
		private UnifiedFunctionDefinition _func;

		[Test]
		public void If文の条件式を取得する() {
			//actual
			var block   = _func.Block;
			var expStmt = (UnifiedExpressionStatement)block.First();
			var ifStmt  = (UnifiedIf)expStmt.Expression;
			var cond    = ifStmt.Condition;

			//expectation
			var expectation = new UnifiedBinaryExpression {
				LeftHandSide = new UnifiedLiteral { Value = "n" },
				Operator = new UnifiedBinaryOperator("<", BinaryOperatorType.Lesser),
				RightHandSide = new UnifiedLiteral { Value = "2" },
			};

			Assert.That(cond, Is.EqualTo(expectation)
				.Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		public void 一番最初に宣言されている関数のパラメータを取得する() {
			//actual
			var firstParam = _func.Parameters.First();

			//expectation
			var expectation = new UnifiedParameter { Name = "n" };

			Assert.That(firstParam, Is.EqualTo(expectation)
				.Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		public void 一番最初に宣言されている関数名を取得する() {
			Assert.That(_func.Name, Is.EqualTo("fibonacci"));
		}

		[Test]
		public void 一番最初のreturn文を取得する() {
			//actual
			var block      = _func.Block;
			var expStmt    = (UnifiedExpressionStatement)block.First();
			var ifStmt     = (UnifiedIf)expStmt.Expression;
			var tBlock     = ifStmt.TrueBlock;
			var returnStmt = tBlock.First();

			//expectation
			var expectation = new UnifiedReturn {
				Value = new UnifiedLiteral {
					Value = "n"
				}
			};

			Assert.That(returnStmt, Is.EqualTo(expectation)
				.Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		public void 二項演算子を取得する() {
			//actual
			var block       = _func.Block;
			var expStmt     = (UnifiedExpressionStatement)block.First();
			var ifStmt      = (UnifiedIf)expStmt.Expression;
			var fBlock      = ifStmt.FalseBlock;
			var returnStmt  = (UnifiedReturn)fBlock.First();
			var binaryExp   = (UnifiedBinaryExpression)returnStmt.Value;

			Assert.That(binaryExp.Operator.Sign, Is.EqualTo("+"));
		}

		[Test]
		public void 呼び出す関数の名前を取得する() {
			//actual
			var block       = _func.Block;
			var expStmt     = (UnifiedExpressionStatement)block.First();
			var ifStmt      = (UnifiedIf)expStmt.Expression;
			var fBlock      = ifStmt.FalseBlock;
			var returnStmt  = (UnifiedReturn)fBlock.First();
			var binaryExp   = (UnifiedBinaryExpression)returnStmt.Value;
			var callExp     = (UnifiedCall)binaryExp.LeftHandSide;
			var identifier  = (UnifiedLiteral)callExp.Function;

			Assert.That(identifier.Value, Is.EqualTo("fibonacci"));
		}

		[Test]
		public void 呼び出す関数の引数を取得する() {
			var block       = _func.Block;
			var expStmt     = (UnifiedExpressionStatement)block.First();
			var ifStmt      = (UnifiedIf)expStmt.Expression;
			var fBlock      = ifStmt.FalseBlock;
			var returnStmt  = (UnifiedReturn)fBlock.First();
			var binaryExp   = (UnifiedBinaryExpression)returnStmt.Value;
			var callExp     = (UnifiedCall)binaryExp.LeftHandSide;
			var firstArg    = callExp.Arguments.First().Value;

			//expectation
			var expectation = new UnifiedBinaryExpression {
				LeftHandSide = new UnifiedLiteral { Value = "n" },
				Operator = new UnifiedBinaryOperator("-", BinaryOperatorType.Subtraction),
				RightHandSide = new UnifiedLiteral { Value = "1" },
			};

			Assert.That(firstArg, Is.EqualTo(expectation)
				.Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		public void 返却される式を取得する() {
			//actual
			var block      = _func.Block;
			var expStmt    = (UnifiedExpressionStatement)block.First();
			var ifStmt     = (UnifiedIf)expStmt.Expression;
			var fBlock     = ifStmt.FalseBlock;
			var returnStmt = (UnifiedReturn)fBlock.First();
			var binaryExp  = (UnifiedBinaryExpression)returnStmt.Value;

			//expectation
			var expectation = new UnifiedBinaryExpression {
				LeftHandSide = new UnifiedCall {
					Arguments = new UnifiedArgumentCollection {
						new UnifiedArgument {
							Value = new UnifiedBinaryExpression {
								LeftHandSide = new UnifiedLiteral {
									Value = "n"
								},
								Operator =
									new UnifiedBinaryOperator("-", BinaryOperatorType.Subtraction),
								RightHandSide = new UnifiedLiteral {
									Value = "1"
								}
							}
						}
					},
					Function = new UnifiedLiteral {
						Value = "fibonacci"
					}
				},
				Operator = new UnifiedBinaryOperator("+", BinaryOperatorType.Addition),
				RightHandSide = new UnifiedCall {
					Arguments = new UnifiedArgumentCollection {
						new UnifiedArgument {
							Value = new UnifiedBinaryExpression {
								LeftHandSide = new UnifiedLiteral {
									Value = "n"
								},
								Operator =
									new UnifiedBinaryOperator("-", BinaryOperatorType.Subtraction),
								RightHandSide = new UnifiedLiteral {
									Value = "2"
								}
							}
						}
					},
					Function = new UnifiedLiteral {
						Value = "fibonacci"
					}
				},
			};

			Assert.That(binaryExp, Is.EqualTo(expectation)
				.Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		public void 関数内のステートメントを取得する() {
			//actual
			var block     = _func.Block;
			var firstStmt = block.First();

			Assert.That(firstStmt.GetType(), Is.EqualTo(typeof(UnifiedExpressionStatement)));
		}
	}
}