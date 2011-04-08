using Code2Xml.Languages.Ruby18.XmlGenerators;
using NUnit.Framework;
using Ucpf.Core.Model;
using Ucpf.Core.Tests;
using Ucpf.Languages.Ruby18.Model;

namespace Ucpf.Languages.Ruby18.Tests {
	[TestFixture]
	public class RubyFibonacciTest {
		private static UnifiedCall CreateCall(int? decrement) {
			return UnifiedCall.Create(UnifiedIdentifier.CreateUnknown("fibonacci"), UnifiedArgumentCollection.Create(
					decrement == null
						? UnifiedArgument.Create(UnifiedIdentifier.CreateUnknown("n"))
						: UnifiedArgument.Create(UnifiedBinaryExpression.Create(UnifiedIdentifier.CreateUnknown("n"), UnifiedBinaryOperator.Create("-",
						                   	UnifiedBinaryOperatorType.Subtract), UnifiedIntegerLiteral.Create((int)decrement)))
				));
		}

		[Test]
		public void CreateDefineFunction() {
			var ast = Ruby18XmlGenerator.Instance.Generate(@"
def fibonacci(n)
end");
			var actual = RubyModelFactory.CreateDefineFunction(ast);
			var expectation = UnifiedFunctionDefinition.Create(
					"fibonacci",
					UnifiedParameterCollection.Create(
							UnifiedParameter.Create("n"))
					);
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
			var expectation = UnifiedFunctionDefinition.Create(
				"fibonacci",
				UnifiedParameterCollection.Create(
					UnifiedParameter.Create("n")
				),
				UnifiedBlock.Create(
					UnifiedJump.CreateReturn(UnifiedIdentifier.CreateUnknown("n"))
				)
			);
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
			var expectation = UnifiedFunctionDefinition.Create(
				"fibonacci",
				UnifiedParameterCollection.Create(
						UnifiedParameter.Create("n")
				),
				UnifiedBlock.Create(
					UnifiedJump.CreateReturn( CreateCall(null))
				)
			);
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
			var expectation = UnifiedFunctionDefinition.Create(
				"fibonacci",
				UnifiedParameterCollection.Create(
					UnifiedParameter.Create("n")
				),
				UnifiedBlock.Create(
					UnifiedJump.CreateReturn(
						UnifiedBinaryExpression.Create(CreateCall(1), UnifiedBinaryOperator.Create("+", UnifiedBinaryOperatorType.Add), CreateCall(2))
					)
				)
			);
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
			var expectation = UnifiedFunctionDefinition.Create(
				"fibonacci",
				UnifiedParameterCollection.Create(
						UnifiedParameter.Create("n")
				),
				UnifiedBlock.Create(
					UnifiedIf.Create(
						UnifiedBinaryExpression.Create(UnifiedIdentifier.CreateUnknown("n"), UnifiedBinaryOperator.Create("<", UnifiedBinaryOperatorType.LessThan), UnifiedIntegerLiteral.Create(2)),
						UnifiedBlock.Create(
							UnifiedJump.CreateReturn( UnifiedIdentifier.CreateUnknown("n"))
						),
						UnifiedBlock.Create(
							UnifiedJump.CreateReturn( UnifiedIntegerLiteral.Create(0))
						)
					)
				)
			);
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
			var expectation = UnifiedFunctionDefinition.Create(
				"fibonacci",
				UnifiedParameterCollection.Create(
					UnifiedParameter.Create("n")
				),
				UnifiedBlock.Create(
					UnifiedIf.Create(
						UnifiedBinaryExpression.Create(UnifiedIdentifier.CreateUnknown("n"), UnifiedBinaryOperator.Create("<", UnifiedBinaryOperatorType.LessThan), UnifiedIntegerLiteral.Create(2)),
						UnifiedBlock.Create(
							UnifiedJump.CreateReturn(UnifiedIdentifier.CreateUnknown("n"))
						),
						UnifiedBlock.Create(
							UnifiedJump.CreateReturn(
								UnifiedBinaryExpression.Create(CreateCall(1), UnifiedBinaryOperator.Create("+", UnifiedBinaryOperatorType.Add), CreateCall(2))
							)
						)
					)
				)
			);
			Assert.That(actual, Is.EqualTo(expectation)
				.Using(StructuralEqualityComparerForDebug.Instance));
		}
	}
}