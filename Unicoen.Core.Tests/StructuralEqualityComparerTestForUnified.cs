﻿#region License

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

using NUnit.Framework;
using Unicoen.Core.Comparers;
using Unicoen.Core.Model;

namespace Unicoen.Core.Tests {
	[TestFixture]
	public class StructuralEqualityComparerTestForUnified {
		[Test]
		public void compares_equal_expressions() {
			var o1 = UnifiedBinaryExpression.Create(
					UnifiedIdentifier.CreateUnknown("n"),
					UnifiedBinaryOperator.Create("-", UnifiedBinaryOperatorKind.Subtract),
					UnifiedIntegerLiteral.Create(1));
			var o2 = UnifiedBinaryExpression.Create(
					UnifiedIdentifier.CreateUnknown("n"),
					UnifiedBinaryOperator.Create("-", UnifiedBinaryOperatorKind.Subtract),
					UnifiedIntegerLiteral.Create(1));
			Assert.That(
					StructuralEqualityComparer.StructuralEquals(o1, o2),
					Is.True);
		}

		[Test]
		public void compares_same_expressions() {
			var o2 = UnifiedBinaryExpression.Create(
					UnifiedIdentifier.CreateUnknown("n"),
					UnifiedBinaryOperator.Create("-", UnifiedBinaryOperatorKind.Subtract),
					UnifiedIntegerLiteral.Create(1));
			var o1 = o2;
			Assert.That(
					StructuralEqualityComparer.StructuralEquals(o1, o2),
					Is.True);
		}

		[Test]
		public void compares_different_expressions_containing_null() {
			var o1 = UnifiedBinaryExpression.Create(
					UnifiedIdentifier.CreateUnknown("n"), null, UnifiedIntegerLiteral.Create(1));
			var o2 = UnifiedBinaryExpression.Create(
					UnifiedIdentifier.CreateUnknown("n"),
					UnifiedBinaryOperator.Create(null, UnifiedBinaryOperatorKind.Add),
					UnifiedIntegerLiteral.Create(1));
			Assert.That(
					StructuralEqualityComparer.StructuralEquals(o1, o2),
					Is.False);
		}

		[Test]
		public void compares_equal_expressions_containing_null() {
			var o1 = UnifiedBinaryExpression.Create(
					UnifiedIdentifier.CreateUnknown("n"), null, UnifiedIntegerLiteral.Create(1));
			var o2 = UnifiedBinaryExpression.Create(
					UnifiedIdentifier.CreateUnknown("n"), null, UnifiedIntegerLiteral.Create(1));
			Assert.That(
					StructuralEqualityComparer.StructuralEquals(o1, o2),
					Is.True);
		}

		[Test]
		public void compares_same_expressions_containing_null() {
			var o2 = UnifiedBinaryExpression.Create(
					UnifiedIdentifier.CreateUnknown("n"), null, UnifiedIntegerLiteral.Create(1));
			var o1 = o2;
			Assert.That(
					StructuralEqualityComparer.StructuralEquals(o1, o2),
					Is.True);
		}

		[Test]
		public void compares_different_expressions() {
			var o1 = UnifiedBinaryExpression.Create(
					UnifiedIdentifier.CreateUnknown("n"),
					UnifiedBinaryOperator.Create("-", UnifiedBinaryOperatorKind.Add),
					UnifiedIntegerLiteral.Create(1));
			var o2 = UnifiedBinaryExpression.Create(
					UnifiedIdentifier.CreateUnknown("n"),
					UnifiedBinaryOperator.Create("-", UnifiedBinaryOperatorKind.Subtract),
					UnifiedIntegerLiteral.Create(1));
			Assert.That(
					StructuralEqualityComparer.StructuralEquals(o1, o2),
					Is.False);
		}

		[Test]
		public void compares_equal_Call() {
			var o1 = UnifiedCall.Create(
					UnifiedIdentifier.CreateUnknown("f"),
					UnifiedArgumentCollection.Create(
							UnifiedArgument.Create(UnifiedIdentifier.CreateUnknown("a")),
							UnifiedArgument.Create(
									UnifiedBinaryExpression.Create(
											UnifiedIdentifier.CreateUnknown("n"),
											UnifiedBinaryOperator.Create("-", UnifiedBinaryOperatorKind.Add),
											UnifiedIntegerLiteral.Create(1))))
					);
			var o2 = UnifiedCall.Create(
					UnifiedIdentifier.CreateUnknown("f"),
					UnifiedArgumentCollection.Create(
							UnifiedArgument.Create(UnifiedIdentifier.CreateUnknown("a")),
							UnifiedArgument.Create(
									UnifiedBinaryExpression.Create(
											UnifiedIdentifier.CreateUnknown("n"),
											UnifiedBinaryOperator.Create("-", UnifiedBinaryOperatorKind.Add),
											UnifiedIntegerLiteral.Create(1))))
					);
			Assert.That(
					StructuralEqualityComparer.StructuralEquals(o1, o2),
					Is.True);
		}

		[Test]
		public void compares_same_calls() {
			var o2 = UnifiedBinaryExpression.Create(
					UnifiedIdentifier.CreateUnknown("n"),
					UnifiedBinaryOperator.Create("-", UnifiedBinaryOperatorKind.Subtract),
					UnifiedIntegerLiteral.Create(1));
			var o1 = o2;
			Assert.That(
					StructuralEqualityComparer.StructuralEquals(o1, o2),
					Is.True);
		}

		[Test]
		public void compares_different_calls() {
			var o1 = UnifiedCall.Create(
					UnifiedIdentifier.CreateUnknown("f"),
					UnifiedArgumentCollection.Create(
							UnifiedArgument.Create(UnifiedIdentifier.CreateUnknown("a")),
							UnifiedArgument.Create(
									UnifiedBinaryExpression.Create(
											UnifiedIdentifier.CreateUnknown("n"),
											UnifiedBinaryOperator.Create("-", UnifiedBinaryOperatorKind.Add),
											UnifiedIntegerLiteral.Create(1)
											)))
					);
			var o2 = UnifiedCall.Create(
					UnifiedIdentifier.CreateUnknown("f"),
					UnifiedArgumentCollection.Create(
							UnifiedArgument.Create(UnifiedIdentifier.CreateUnknown("a")),
							UnifiedArgument.Create(
									UnifiedBinaryExpression.Create(
											UnifiedIdentifier.CreateUnknown("n2"),
											UnifiedBinaryOperator.Create("-", UnifiedBinaryOperatorKind.Add),
											UnifiedIntegerLiteral.Create(1)))));
			Assert.That(
					StructuralEqualityComparer.StructuralEquals(o1, o2),
					Is.False);
		}

		[Test]
		public void compares_equal_blocks() {
			var o1 = UnifiedBlock.Create(
					new IUnifiedExpression[] {
							UnifiedBinaryExpression.Create(
									UnifiedIdentifier.CreateUnknown("n"),
									UnifiedBinaryOperator.Create("=", UnifiedBinaryOperatorKind.Assign),
									UnifiedIntegerLiteral.Create(1)),
							UnifiedSpecialExpression.CreateReturn(UnifiedIntegerLiteral.Create(2)),
					});
			var o2 = UnifiedBlock.Create(
					new IUnifiedExpression[] {
							UnifiedBinaryExpression.Create(
									UnifiedIdentifier.CreateUnknown("n"),
									UnifiedBinaryOperator.Create("=", UnifiedBinaryOperatorKind.Assign),
									UnifiedIntegerLiteral.Create(1)),
							UnifiedSpecialExpression.CreateReturn(UnifiedIntegerLiteral.Create(2)),
					});
			Assert.That(
					StructuralEqualityComparer.StructuralEquals(o1, o2),
					Is.True);
		}

		[Test]
		public void compares_same_blocks() {
			var o1 = UnifiedBlock.Create(
					new IUnifiedExpression[] {
							UnifiedBinaryExpression.Create(
									UnifiedIdentifier.CreateUnknown("n"),
									UnifiedBinaryOperator.Create("=", UnifiedBinaryOperatorKind.Assign),
									UnifiedIntegerLiteral.Create(1)),
							UnifiedSpecialExpression.CreateReturn(UnifiedIntegerLiteral.Create(2)),
					});
			var o2 = o1;
			Assert.That(
					StructuralEqualityComparer.StructuralEquals(o1, o2),
					Is.True);
		}

		[Test]
		public void compares_different_blocks() {
			var o1 = UnifiedBlock.Create(
					new IUnifiedExpression[] {
							UnifiedBinaryExpression.Create(
									UnifiedIdentifier.CreateUnknown("n"),
									UnifiedBinaryOperator.Create("=", UnifiedBinaryOperatorKind.Assign),
									UnifiedIntegerLiteral.Create(1)),
							UnifiedSpecialExpression.CreateReturn(UnifiedIntegerLiteral.Create(2)),
					});
			var o2 = UnifiedBlock.Create(
					new IUnifiedExpression[] {
							UnifiedBinaryExpression.Create(
									UnifiedIdentifier.CreateUnknown("n"),
									UnifiedBinaryOperator.Create("=", UnifiedBinaryOperatorKind.Assign),
									UnifiedIntegerLiteral.Create(2)),
							UnifiedSpecialExpression.CreateReturn(UnifiedIntegerLiteral.Create(2)),
					});
			Assert.That(
					StructuralEqualityComparer.StructuralEquals(o1, o2),
					Is.False);
		}
	}
}