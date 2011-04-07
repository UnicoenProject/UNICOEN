using NUnit.Framework;
using Ucpf.Core.Model;

namespace Ucpf.Core.Tests {
	[TestFixture]
	public class StructuralEqualityComparerTestForUnified {
		[Test]
		public void compares_equal_expressions() {
			var o1 = UnifiedBinaryExpression.Create(UnifiedVariable.Create("n"), UnifiedBinaryOperator.Create("-", UnifiedBinaryOperatorType.Subtract), UnifiedIntegerLiteral.Create(1));
			var o2 = UnifiedBinaryExpression.Create(UnifiedVariable.Create("n"), UnifiedBinaryOperator.Create("-", UnifiedBinaryOperatorType.Subtract), UnifiedIntegerLiteral.Create(1));
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.True);
		}

		[Test]
		public void compares_same_expressions() {
			var o2 = UnifiedBinaryExpression.Create(UnifiedVariable.Create("n"), UnifiedBinaryOperator.Create("-", UnifiedBinaryOperatorType.Subtract), UnifiedIntegerLiteral.Create(1));
			var o1 = o2;
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.True);
		}

		[Test]
		public void compares_different_expressions_containing_null() {
			var o1 = UnifiedBinaryExpression.Create(UnifiedVariable.Create("n"), null, UnifiedIntegerLiteral.Create(1));
			var o2 = UnifiedBinaryExpression.Create(UnifiedVariable.Create("n"), UnifiedBinaryOperator.Create(null, UnifiedBinaryOperatorType.Add), UnifiedIntegerLiteral.Create(1));
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.False);
		}
		[Test]
		public void compares_equal_expressions_containing_null() {
			var o1 = UnifiedBinaryExpression.Create(UnifiedVariable.Create("n"), null, UnifiedIntegerLiteral.Create(1));
			var o2 = UnifiedBinaryExpression.Create(UnifiedVariable.Create("n"), null, UnifiedIntegerLiteral.Create(1));
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.True);
		}

		[Test]
		public void compares_same_expressions_containing_null() {
			var o2 = UnifiedBinaryExpression.Create(UnifiedVariable.Create("n"), null, UnifiedIntegerLiteral.Create(1));
			var o1 = o2;
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.True);
		}

		[Test]
		public void compares_different_expressions() {
			var o1 = UnifiedBinaryExpression.Create(UnifiedVariable.Create("n"), UnifiedBinaryOperator.Create("-", UnifiedBinaryOperatorType.Add), UnifiedIntegerLiteral.Create(1));
			var o2 = UnifiedBinaryExpression.Create(UnifiedVariable.Create("n"), UnifiedBinaryOperator.Create("-", UnifiedBinaryOperatorType.Subtract), UnifiedIntegerLiteral.Create(1));
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.False);
		}

		[Test]
		public void compares_equal_Call() {
			var o1 = UnifiedCall.Create(UnifiedVariable.Create("f"),
					UnifiedArgumentCollection.Create(
							UnifiedArgument.Create(UnifiedVariable.Create("a")),
							UnifiedArgument.Create(UnifiedBinaryExpression.Create(UnifiedVariable.Create("n"),
													UnifiedBinaryOperator.Create("-", UnifiedBinaryOperatorType.Add),
													UnifiedIntegerLiteral.Create(1))))
					);
			var o2 = UnifiedCall.Create(UnifiedVariable.Create("f"),
					UnifiedArgumentCollection.Create(
							UnifiedArgument.Create(UnifiedVariable.Create("a")),
							UnifiedArgument.Create(UnifiedBinaryExpression.Create(UnifiedVariable.Create("n"),
													UnifiedBinaryOperator.Create("-", UnifiedBinaryOperatorType.Add),
													UnifiedIntegerLiteral.Create(1))))
					);
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.True);
		}

		[Test]
		public void compares_same_calls() {
			var o2 = UnifiedBinaryExpression.Create(UnifiedVariable.Create("n"), UnifiedBinaryOperator.Create("-", UnifiedBinaryOperatorType.Subtract), UnifiedIntegerLiteral.Create(1));
			var o1 = o2;
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.True);
		}

		[Test]
		public void compares_different_calls() {
			var o1 = UnifiedCall.Create(UnifiedVariable.Create("f"),
					UnifiedArgumentCollection.Create(
							UnifiedArgument.Create(UnifiedVariable.Create("a")),
							UnifiedArgument.Create(UnifiedBinaryExpression.Create(UnifiedVariable.Create("n"),
													UnifiedBinaryOperator.Create("-", UnifiedBinaryOperatorType.Add),
													UnifiedIntegerLiteral.Create(1)
													)))
					);
			var o2 = UnifiedCall.Create(UnifiedVariable.Create("f"),
					UnifiedArgumentCollection.Create(
							UnifiedArgument.Create(UnifiedVariable.Create("a")),
							UnifiedArgument.Create(UnifiedBinaryExpression.Create(UnifiedVariable.Create("n2"),
													UnifiedBinaryOperator.Create("-", UnifiedBinaryOperatorType.Add),
													UnifiedIntegerLiteral.Create(1)))));
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.False);
		}

		[Test]
		public void compares_equal_blocks() {
			var o1 = UnifiedBlock.Create(new IUnifiedExpression[] {
				UnifiedBinaryExpression.Create(UnifiedVariable.Create("n"), UnifiedBinaryOperator.Create("=", UnifiedBinaryOperatorType.Assign), UnifiedIntegerLiteral.Create(1)),
				UnifiedJump.CreateReturn(UnifiedIntegerLiteral.Create(2)),
			});
			var o2 = UnifiedBlock.Create(new IUnifiedExpression[] {
				UnifiedBinaryExpression.Create(UnifiedVariable.Create("n"), UnifiedBinaryOperator.Create("=", UnifiedBinaryOperatorType.Assign), UnifiedIntegerLiteral.Create(1)),
				UnifiedJump.CreateReturn(UnifiedIntegerLiteral.Create(2)),
			});
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.True);
		}

		[Test]
		public void compares_same_blocks() {
			var o1 = UnifiedBlock.Create(new IUnifiedExpression[] {
				UnifiedBinaryExpression.Create(UnifiedVariable.Create("n"), UnifiedBinaryOperator.Create("=", UnifiedBinaryOperatorType.Assign), UnifiedIntegerLiteral.Create(1)),
				UnifiedJump.CreateReturn(UnifiedIntegerLiteral.Create(2)),
			});
			var o2 = o1;
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.True);
		}

		[Test]
		public void compares_different_blocks() {
			var o1 = UnifiedBlock.Create(new IUnifiedExpression[] {
				UnifiedBinaryExpression.Create(UnifiedVariable.Create("n"), UnifiedBinaryOperator.Create("=", UnifiedBinaryOperatorType.Assign), UnifiedIntegerLiteral.Create(1)),
				UnifiedJump.CreateReturn(UnifiedIntegerLiteral.Create(2)),
			});
			var o2 = UnifiedBlock.Create(new IUnifiedExpression[] {
				UnifiedBinaryExpression.Create(UnifiedVariable.Create("n"), UnifiedBinaryOperator.Create("=", UnifiedBinaryOperatorType.Assign), UnifiedIntegerLiteral.Create(2)),
				UnifiedJump.CreateReturn(UnifiedIntegerLiteral.Create(2)),
			});
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.False);
		}
	}
}