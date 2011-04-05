using Code2Xml.Languages.Ruby18.XmlGenerators;
using NUnit.Framework;
using Ucpf.Core.Model;
using Ucpf.Core.Tests;
using Ucpf.Languages.Ruby18.Model;

namespace Ucpf.Languages.Ruby18.Tests {
	[TestFixture]
	public class RubyFibonacciTest {
		private static UnifiedCall CreateCall(int? decrement) {
			return new UnifiedCall {
				Function = UnifiedVariable.Create("fibonacci"),
				Arguments = {
					decrement == null
						? UnifiedArgument.Create(UnifiedVariable.Create("n"))
						: UnifiedArgument.Create(new UnifiedBinaryExpression {
							LeftHandSide = UnifiedVariable.Create("n"),
							Operator = new UnifiedBinaryOperator("-",
						                   	UnifiedBinaryOperatorType.Subtract),
							RightHandSide = UnifiedIntegerLiteral.Create((int)decrement),
						})
				},
			};
		}

		[Test]
		public void CreateDefineFunction() {
			var ast = Ruby18XmlGenerator.Instance.Generate(@"
def fibonacci(n)
end");
			var actual = RubyModelFactory.CreateDefineFunction(ast);
			var expectation = new UnifiedFunctionDefinition {
				Name = "fibonacci",
				Parameters = {
					new UnifiedParameter{ Name = "n" }
				},
			};
			Assert.That(actual, Is.EqualTo(expectation)
				.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Test]
		public void CreateReturn() {
			var ast =
				Ruby18XmlGenerator.Instance.Generate(@"
def fibonacci(n)
	return n
end");
			var actual = RubyModelFactory.CreateDefineFunction(ast);
			var expectation = new UnifiedFunctionDefinition {
				Name = "fibonacci",
				Parameters = {
					new UnifiedParameter{ Name = "n" }
				},
				Body = {
					new UnifiedReturn{ Value = UnifiedVariable.Create("n")}
				},
			};
			Assert.That(actual, Is.EqualTo(expectation)
				.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Test]
		public void CreateFunctionCall() {
			var ast =
				Ruby18XmlGenerator.Instance.Generate(
					@"
def fibonacci(n)
	return fibonacci(n)
end");
			var actual = RubyModelFactory.CreateDefineFunction(ast);
			var expectation = new UnifiedFunctionDefinition {
				Name = "fibonacci",
				Parameters = {
					new UnifiedParameter{ Name = "n" }
				},
				Body = {
					new UnifiedReturn{ Value = CreateCall(null)}
				},
			};
			Assert.That(actual, Is.EqualTo(expectation)
				.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Test]
		public void CreateFunctionCall2() {
			var ast =
				Ruby18XmlGenerator.Instance.Generate(
					@"
def fibonacci(n)
	return fibonacci(n - 1) + fibonacci(n - 2)
end");
			var actual = RubyModelFactory.CreateDefineFunction(ast);
			var expectation = new UnifiedFunctionDefinition {
				Name = "fibonacci",
				Parameters = {
					new UnifiedParameter{ Name = "n" }
				},
				Body = {
					new UnifiedReturn{
						Value = new UnifiedBinaryExpression {
							LeftHandSide = CreateCall(1),
							Operator = new UnifiedBinaryOperator("+", UnifiedBinaryOperatorType.Add),
							RightHandSide = CreateCall(2),
						}
					}
				}
			};
			Assert.That(actual, Is.EqualTo(expectation)
				.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Test]
		public void CreateIf() {
			var ast =
				Ruby18XmlGenerator.Instance.Generate(
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
			var expectation = new UnifiedFunctionDefinition {
				Name = "fibonacci",
				Parameters = {
					new UnifiedParameter{ Name = "n" }
				},
				Body = {
					new UnifiedIf {
						Condition = new UnifiedBinaryExpression {
							LeftHandSide = UnifiedVariable.Create("n"),
							Operator = new UnifiedBinaryOperator("<", UnifiedBinaryOperatorType.LessThan),
							RightHandSide = UnifiedIntegerLiteral.Create(2),
						},
						TrueBody = {
							new UnifiedReturn{
								Value = UnifiedVariable.Create("n")
							}
						},
						FalseBody = {
							new UnifiedReturn {
								Value = UnifiedIntegerLiteral.Create(0)
							}
						},
					},
				},
			};
			Assert.That(actual, Is.EqualTo(expectation)
				.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Test]
		public void CreateFibonacci() {
			var ast =
				Ruby18XmlGenerator.Instance.Generate(
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
			var expectation = new UnifiedFunctionDefinition {
				Name = "fibonacci",
				Parameters = {
					new UnifiedParameter{ Name = "n" }
				},
				Body = {
					new UnifiedIf {
						Condition = new UnifiedBinaryExpression {
							LeftHandSide = UnifiedVariable.Create("n"),
							Operator = new UnifiedBinaryOperator("<", UnifiedBinaryOperatorType.LessThan),
							RightHandSide = UnifiedIntegerLiteral.Create(2),
						},
						TrueBody = {
							new UnifiedReturn{ Value = UnifiedVariable.Create("n") }
						},
						FalseBody = {
							new UnifiedReturn {
								Value = new UnifiedBinaryExpression {
									LeftHandSide = CreateCall(1),
									Operator = new UnifiedBinaryOperator("+", UnifiedBinaryOperatorType.Add),
									RightHandSide = CreateCall(2),
								}
							}
						},
					},
				},
			};
			Assert.That(actual, Is.EqualTo(expectation)
				.Using(StructuralEqualityComparerForDebug.Instance));
		}
	}
}