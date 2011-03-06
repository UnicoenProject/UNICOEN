using NUnit.Framework;
using Ucpf.Core.Model;
using Ucpf.Core.Model.Expressions;
using Ucpf.Core.Model.Expressions.Literals;
using Ucpf.Core.Model.Expressions.Operators;

namespace Ucpf.Core.Tests {
	[TestFixture]
	public class StructuralEqualityComparerTestForUnified {
		[Test]
		public void compares_equal_expressions() {
			var o1 = new UnifiedBinaryExpression {
				LeftHandSide = UnifiedVariable.Create("n"),
				Operator = new UnifiedBinaryOperator("-", UnifiedBinaryOperatorType.Subtraction),
				RightHandSide = UnifiedIntegerLiteral.Create(1),
			};
			var o2 = new UnifiedBinaryExpression {
				LeftHandSide = UnifiedVariable.Create("n"),
				Operator = new UnifiedBinaryOperator("-", UnifiedBinaryOperatorType.Subtraction),
				RightHandSide = UnifiedIntegerLiteral.Create(1),
			};
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.True);
		}

		[Test]
		public void compares_same_expressions() {
			var o2 = new UnifiedBinaryExpression {
				LeftHandSide = UnifiedVariable.Create("n"),
				Operator = new UnifiedBinaryOperator("-", UnifiedBinaryOperatorType.Subtraction),
				RightHandSide = UnifiedIntegerLiteral.Create(1),
			};
			var o1 = o2;
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.True);
		}

		[Test]
		public void compares_different_expressions_containing_null() {
			var o1 = new UnifiedBinaryExpression {
				LeftHandSide = UnifiedVariable.Create("n"),
				Operator = null,
				RightHandSide = UnifiedIntegerLiteral.Create(1),
			};
			var o2 = new UnifiedBinaryExpression {
				LeftHandSide = UnifiedVariable.Create("n"),
				Operator = new UnifiedBinaryOperator(null, UnifiedBinaryOperatorType.Addition),
				RightHandSide = UnifiedIntegerLiteral.Create(1),
			};
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.False);
		}
		[Test]
		public void compares_equal_expressions_containing_null() {
			var o1 = new UnifiedBinaryExpression {
				LeftHandSide = UnifiedVariable.Create("n"),
				Operator = null,
				RightHandSide = UnifiedIntegerLiteral.Create(1),
			};
			var o2 = new UnifiedBinaryExpression {
				LeftHandSide = UnifiedVariable.Create("n"),
				Operator = null,
				RightHandSide = UnifiedIntegerLiteral.Create(1),
			};
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.True);
		}

		[Test]
		public void compares_same_expressions_containing_null() {
			var o2 = new UnifiedBinaryExpression {
				LeftHandSide = UnifiedVariable.Create("n"),
				Operator = null,
				RightHandSide = UnifiedIntegerLiteral.Create(1),
			};
			var o1 = o2;
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.True);
		}

		[Test]
		public void compares_different_expressions() {
			var o1 = new UnifiedBinaryExpression {
				LeftHandSide = UnifiedVariable.Create("n"),
				Operator = new UnifiedBinaryOperator("-", UnifiedBinaryOperatorType.Addition),
				RightHandSide = UnifiedIntegerLiteral.Create(1),
			};
			var o2 = new UnifiedBinaryExpression {
				LeftHandSide = UnifiedVariable.Create("n"),
				Operator = new UnifiedBinaryOperator("-", UnifiedBinaryOperatorType.Subtraction),
				RightHandSide = UnifiedIntegerLiteral.Create(1),
			};
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.False);
		}

		[Test]
		public void compares_equal_Call() {
			var o1 = new UnifiedCall {
				Function = UnifiedVariable.Create("f"),
				Arguments = {
					new UnifiedArgument { Value = UnifiedVariable.Create("a") },
					new UnifiedArgument {
						Value = new UnifiedBinaryExpression {
							LeftHandSide = UnifiedVariable.Create("n"),
							Operator = new UnifiedBinaryOperator("-", UnifiedBinaryOperatorType.Addition),
							RightHandSide = UnifiedIntegerLiteral.Create(1),
						}
					},
				},
			};
			var o2 = new UnifiedCall {
				Function = UnifiedVariable.Create("f"),
				Arguments = {
					new UnifiedArgument { Value = UnifiedVariable.Create("a") },
					new UnifiedArgument {
						Value = new UnifiedBinaryExpression {
							LeftHandSide = UnifiedVariable.Create("n"),
							Operator = new UnifiedBinaryOperator("-", UnifiedBinaryOperatorType.Addition),
							RightHandSide = UnifiedIntegerLiteral.Create(1),
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
				LeftHandSide = UnifiedVariable.Create("n"),
				Operator = new UnifiedBinaryOperator("-", UnifiedBinaryOperatorType.Subtraction),
				RightHandSide = UnifiedIntegerLiteral.Create(1),
			};
			var o1 = o2;
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.True);
		}

		[Test]
		public void compares_different_calls() {
			var o1 = new UnifiedCall {
				Function = UnifiedVariable.Create("f"),
				Arguments = {
					new UnifiedArgument { Value = UnifiedVariable.Create("a") },
					new UnifiedArgument {
						Value = new UnifiedBinaryExpression {
							LeftHandSide = UnifiedVariable.Create("n"),
							Operator = new UnifiedBinaryOperator("-", UnifiedBinaryOperatorType.Addition),
							RightHandSide = UnifiedIntegerLiteral.Create(1),
						}
					},
				},
			};
			var o2 = new UnifiedCall {
				Function = UnifiedVariable.Create("f"),
				Arguments = {
					new UnifiedArgument { Value = UnifiedVariable.Create("a") },
					new UnifiedArgument {
						Value = new UnifiedBinaryExpression {
							LeftHandSide = UnifiedVariable.Create("n2"),
							Operator = new UnifiedBinaryOperator("-", UnifiedBinaryOperatorType.Addition),
							RightHandSide = UnifiedIntegerLiteral.Create(1),
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
				new UnifiedBinaryExpression {
					LeftHandSide = UnifiedVariable.Create("n"),
					Operator = new UnifiedBinaryOperator("=", UnifiedBinaryOperatorType.Assignment),
					RightHandSide = UnifiedIntegerLiteral.Create(1),
				},
				new UnifiedReturn{
					Value = UnifiedIntegerLiteral.Create(2)
				}
			};
			var o2 = new UnifiedBlock {
				new UnifiedBinaryExpression {
					LeftHandSide = UnifiedVariable.Create("n"),
					Operator = new UnifiedBinaryOperator("=", UnifiedBinaryOperatorType.Assignment),
					RightHandSide = UnifiedIntegerLiteral.Create(1),
				},
				new UnifiedReturn{ Value = UnifiedIntegerLiteral.Create(2) }
			};
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.True);
		}

		[Test]
		public void compares_same_blocks() {
			var o1 = new UnifiedBlock {
				new UnifiedBinaryExpression {
					LeftHandSide = UnifiedVariable.Create("n"),
					Operator = new UnifiedBinaryOperator("=", UnifiedBinaryOperatorType.Assignment),
					RightHandSide = UnifiedIntegerLiteral.Create(1),
				},
				new UnifiedReturn{ Value = UnifiedIntegerLiteral.Create(2) }
			};
			var o2 = o1;
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.True);
		}

		[Test]
		public void compares_different_blocks() {
			var o1 = new UnifiedBlock {
				new UnifiedBinaryExpression {
					LeftHandSide = UnifiedVariable.Create("n"),
					Operator = new UnifiedBinaryOperator("=", UnifiedBinaryOperatorType.Assignment),
					RightHandSide = UnifiedIntegerLiteral.Create(1),
				},
				new UnifiedReturn{ Value = UnifiedIntegerLiteral.Create(2) }
			};
			var o2 = new UnifiedBlock {
				new UnifiedBinaryExpression {
					LeftHandSide = UnifiedVariable.Create("n"),
					Operator = new UnifiedBinaryOperator("=", UnifiedBinaryOperatorType.Assignment),
					RightHandSide = UnifiedIntegerLiteral.Create(2),
				},
				new UnifiedReturn{ Value = UnifiedIntegerLiteral.Create(2) }
			};
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.False);
		}
	}
}