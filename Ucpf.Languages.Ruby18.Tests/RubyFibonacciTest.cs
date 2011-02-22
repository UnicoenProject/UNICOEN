using NUnit.Framework;
using Ucpf.Common.Model;
using Ucpf.Common.OldModel.Operators;
using Ucpf.Languages.Ruby18.AstGenerators;
using Ucpf.Languages.Ruby18.Model;

namespace Ucpf.Languages.Ruby18.Tests {
	[TestFixture]
	public class RubyFibonacciTest {
		private static UnifiedCall CreateCall(int? decrement) {
			return new UnifiedCall {
				Function = new UnifiedVariable("fibonacci"),
				Arguments = new UnifiedArgumentCollection {
					decrement == null
						? (UnifiedArgument)new UnifiedVariable("n")
						: (UnifiedArgument)new UnifiedBinaryExpression {
							LeftHandSide = new UnifiedVariable("n"),
							Operator = new UnifiedBinaryOperator("-",
						                   	BinaryOperatorType.Subtraction),
							RightHandSide = new UnifiedIntegerLiteral((int)decrement),
						}
				},
			};
		}

		[Test]
		public void CreateDefineFunction() {
			var ast = Ruby18AstGenerator.Instance.Generate(@"
def fibonacci(n)
end");
			var actual = RubyModelFactory.CreateDefineFunction(ast);
			var expectation = new UnifiedDefineFunction {
				Name = "fibonacci",
				Parameters = new UnifiedParameterCollection {
					new UnifiedParameter("n"),
				},
				Block = new UnifiedBlock(),
			};
			Assert.That(actual, Is.EqualTo(expectation)
				.Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		public void CreateReturn() {
			var ast =
				Ruby18AstGenerator.Instance.Generate(@"
def fibonacci(n)
	return n
end");
			var actual = RubyModelFactory.CreateDefineFunction(ast);
			var expectation = new UnifiedDefineFunction {
				Name = "fibonacci",
				Parameters = new UnifiedParameterCollection {
					new UnifiedParameter("n"),
				},
				Block = new UnifiedBlock {
					new UnifiedReturn(new UnifiedVariable("n")),
				},
			};
			Assert.That(actual, Is.EqualTo(expectation)
				.Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		public void CreateFunctionCall() {
			var ast =
				Ruby18AstGenerator.Instance.Generate(
					@"
def fibonacci(n)
	return fibonacci(n)
end");
			var actual = RubyModelFactory.CreateDefineFunction(ast);
			var expectation = new UnifiedDefineFunction {
				Name = "fibonacci",
				Parameters = new UnifiedParameterCollection {
					new UnifiedParameter("n"),
				},
				Block = new UnifiedBlock {
					new UnifiedReturn(CreateCall(null)),
				},
			};
			Assert.That(actual, Is.EqualTo(expectation)
				.Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		public void CreateFunctionCall2() {
			var ast =
				Ruby18AstGenerator.Instance.Generate(
					@"
def fibonacci(n)
	return fibonacci(n - 1) + fibonacci(n - 2)
end");
			var actual = RubyModelFactory.CreateDefineFunction(ast);
			var expectation = new UnifiedDefineFunction {
				Name = "fibonacci",
				Parameters = new UnifiedParameterCollection {
					new UnifiedParameter("n"),
				},
				Block = new UnifiedBlock {
					new UnifiedReturn(
						new UnifiedBinaryExpression {
							LeftHandSide = CreateCall(1),
							Operator = new UnifiedBinaryOperator("+", BinaryOperatorType.Addition),
							RightHandSide = CreateCall(2),
						})
				},
			};
			Assert.That(actual, Is.EqualTo(expectation)
				.Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		public void CreateIf() {
			var ast =
				Ruby18AstGenerator.Instance.Generate(
					@"
def fibonacci(n)
	if (n < 2)
		return n
	else
		return 0
	end
end
");
			var actual = RubyModelFactory.CreateDefineFunction(ast);
			var expectation = new UnifiedDefineFunction {
				Name = "fibonacci",
				Parameters = new UnifiedParameterCollection {
					new UnifiedParameter("n"),
				},
				Block = new UnifiedBlock {
					new UnifiedExpressionStatement(new UnifiedIf {
						Condition = new UnifiedBinaryExpression {
							LeftHandSide = new UnifiedVariable("n"),
							Operator = new UnifiedBinaryOperator("<", BinaryOperatorType.Lesser),
							RightHandSide = new UnifiedIntegerLiteral(2),
						},
						TrueBlock = new UnifiedBlock {
							new UnifiedReturn(new UnifiedVariable("n")),
						},
						FalseBlock = new UnifiedBlock {
							new UnifiedReturn(new UnifiedIntegerLiteral(0)),
						},
					}),
				},
			};
			Assert.That(actual, Is.EqualTo(expectation)
				.Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		public void CreateFibonacci() {
			var ast =
				Ruby18AstGenerator.Instance.Generate(
					@"
def fibonacci(n)
	if (n < 2)
		return n
	else
		return fibonacci(n - 1) + fibonacci(n - 2)
	end
end
");
			var actual = RubyModelFactory.CreateDefineFunction(ast);
			var expectation = new UnifiedDefineFunction {
				Name = "fibonacci",
				Parameters = new UnifiedParameterCollection {
					new UnifiedParameter("n"),
				},
				Block = new UnifiedBlock {
					new UnifiedExpressionStatement(new UnifiedIf {
						Condition = new UnifiedBinaryExpression {
							LeftHandSide = new UnifiedVariable("n"),
							Operator = new UnifiedBinaryOperator("<", BinaryOperatorType.Lesser),
							RightHandSide = new UnifiedIntegerLiteral(2),
						},
						TrueBlock = new UnifiedBlock {
							new UnifiedReturn(new UnifiedVariable("n")),
						},
						FalseBlock = new UnifiedBlock {
							new UnifiedReturn(
								new UnifiedBinaryExpression {
									LeftHandSide = CreateCall(1),
									Operator = new UnifiedBinaryOperator("+", BinaryOperatorType.Addition),
									RightHandSide = CreateCall(2),
								})
						},
					}),
				},
			};
			Assert.That(actual, Is.EqualTo(expectation)
				.Using(StructuralEqualityComparer.Instance));
		}
	}
}