using NUnit.Framework;
using Ucpf.Common.Model;
using Ucpf.Common.OldModel.Operators;

namespace Ucpf.Common.Tests {
	[TestFixture]
	public class StructuralEqualityComparerTestForUnified {
		[Test]
		public void compares_equal_expressions() {
			var o1 = new UnifiedBinaryExpression {
				LeftHandSide = new UnifiedVariable("n"),
				Operator = new UnifiedBinaryOperator("-", BinaryOperatorType.Subtraction),
				RightHandSide = new UnifiedIntegerLiteral(1),
			};
			var o2 = new UnifiedBinaryExpression {
				LeftHandSide = new UnifiedVariable("n"),
				Operator = new UnifiedBinaryOperator("-", BinaryOperatorType.Subtraction),
				RightHandSide = new UnifiedIntegerLiteral(1),
			};
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.True);
		}

		[Test]
		public void compares_same_expressions() {
			var o2 = new UnifiedBinaryExpression {
				LeftHandSide = new UnifiedVariable("n"),
				Operator = new UnifiedBinaryOperator("-", BinaryOperatorType.Subtraction),
				RightHandSide = new UnifiedIntegerLiteral(1),
			};
			var o1 = o2;
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.True);
		}

		[Test]
		public void compares_different_expressions() {
			var o1 = new UnifiedBinaryExpression {
				LeftHandSide = new UnifiedVariable("n"),
				Operator = new UnifiedBinaryOperator("-", BinaryOperatorType.Addition),
				RightHandSide = new UnifiedIntegerLiteral(1),
			};
			var o2 = new UnifiedBinaryExpression {
				LeftHandSide = new UnifiedVariable("n"),
				Operator = new UnifiedBinaryOperator("-", BinaryOperatorType.Subtraction),
				RightHandSide = new UnifiedIntegerLiteral(1),
			};
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.False);
		}

		[Test]
		public void compares_equal_Call() {
			var o1 = new UnifiedCall {
				Function = new UnifiedVariable("f"),
				Arguments = new UnifiedArgumentCollection {
					new UnifiedArgument { Value = new UnifiedVariable("a") },
					new UnifiedArgument {
						Value = new UnifiedBinaryExpression {
							LeftHandSide = new UnifiedVariable("n"),
							Operator = new UnifiedBinaryOperator("-", BinaryOperatorType.Addition),
							RightHandSide = new UnifiedIntegerLiteral(1),
						}
					},
				},
			};
			var o2 = new UnifiedCall {
				Function = new UnifiedVariable("f"),
				Arguments = new UnifiedArgumentCollection {
					new UnifiedArgument { Value = new UnifiedVariable("a") },
					new UnifiedArgument {
						Value = new UnifiedBinaryExpression {
							LeftHandSide = new UnifiedVariable("n"),
							Operator = new UnifiedBinaryOperator("-", BinaryOperatorType.Addition),
							RightHandSide = new UnifiedIntegerLiteral(1),
						}
					},
				},
			};
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.True);
		}

		[Test]
		public void compares_same_calls() {
			var o2 = new UnifiedBinaryExpression {
				LeftHandSide = new UnifiedVariable("n"),
				Operator = new UnifiedBinaryOperator("-", BinaryOperatorType.Subtraction),
				RightHandSide = new UnifiedIntegerLiteral(1),
			};
			var o1 = o2;
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.True);
		}

		[Test]
		public void compares_different_calls() {
			var o1 = new UnifiedCall {
				Function = new UnifiedVariable("f"),
				Arguments = new UnifiedArgumentCollection {
					new UnifiedArgument { Value = new UnifiedVariable("a") },
					new UnifiedArgument {
						Value = new UnifiedBinaryExpression {
							LeftHandSide = new UnifiedVariable("n"),
							Operator = new UnifiedBinaryOperator("-", BinaryOperatorType.Addition),
							RightHandSide = new UnifiedIntegerLiteral(1),
						}
					},
				},
			};
			var o2 = new UnifiedCall {
				Function = new UnifiedVariable("f"),
				Arguments = new UnifiedArgumentCollection {
					new UnifiedArgument { Value = new UnifiedVariable("a") },
					new UnifiedArgument {
						Value = new UnifiedBinaryExpression {
							LeftHandSide = new UnifiedVariable("n2"),
							Operator = new UnifiedBinaryOperator("-", BinaryOperatorType.Addition),
							RightHandSide = new UnifiedIntegerLiteral(1),
						}
					},
				},
			};
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.False);
		}

		[Test]
		public void compares_equal_blocks() {
			var o1 = new UnifiedBlock {
				new UnifiedExpressionStatement(
					new UnifiedBinaryExpression {
						LeftHandSide = new UnifiedVariable("n"),
						Operator = new UnifiedBinaryOperator("=", BinaryOperatorType.Assignment),
						RightHandSide = new UnifiedIntegerLiteral(1),
					}),
				new UnifiedReturn(new UnifiedIntegerLiteral(2)),
			};
			var o2 = new UnifiedBlock {
				new UnifiedExpressionStatement(
					new UnifiedBinaryExpression {
						LeftHandSide = new UnifiedVariable("n"),
						Operator = new UnifiedBinaryOperator("=", BinaryOperatorType.Assignment),
						RightHandSide = new UnifiedIntegerLiteral(1),
					}),
				new UnifiedReturn(new UnifiedIntegerLiteral(2)),
			};
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.True);
		}

		[Test]
		public void compares_same_blocks() {
			var o1 = new UnifiedBlock {
				new UnifiedExpressionStatement(
					new UnifiedBinaryExpression {
						LeftHandSide = new UnifiedVariable("n"),
						Operator = new UnifiedBinaryOperator("=", BinaryOperatorType.Assignment),
						RightHandSide = new UnifiedIntegerLiteral(1),
					}),
				new UnifiedReturn(new UnifiedIntegerLiteral(2)),
			};
			var o2 = o1;
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.True);
		}

		[Test]
		public void compares_different_blocks() {
			var o1 = new UnifiedBlock {
				new UnifiedExpressionStatement(
					new UnifiedBinaryExpression {
						LeftHandSide = new UnifiedVariable("n"),
						Operator = new UnifiedBinaryOperator("=", BinaryOperatorType.Assignment),
						RightHandSide = new UnifiedIntegerLiteral(1),
					}),
				new UnifiedReturn(new UnifiedIntegerLiteral(2)),
			};
			var o2 = new UnifiedBlock {
				new UnifiedExpressionStatement(
					new UnifiedBinaryExpression {
						LeftHandSide = new UnifiedVariable("n"),
						Operator = new UnifiedBinaryOperator("=", BinaryOperatorType.Assignment),
						RightHandSide = new UnifiedIntegerLiteral(2),
					}),
				new UnifiedReturn(new UnifiedIntegerLiteral(2)),
			};
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.False);
		}
	}
}