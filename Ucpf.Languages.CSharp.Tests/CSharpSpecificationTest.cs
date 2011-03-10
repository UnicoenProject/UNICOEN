using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Ucpf.Core.Model;
using Ucpf.Core.Model.Extensions;

namespace Ucpf.Languages.CSharp.Tests {
	[TestFixture]
	public class CSharpSpecificationTest {
		public static UnifiedClassDefinition CreateClassAndMethod(UnifiedBlock block) {
			return "A".ToClassDefinition()
				.AddToBody(
					new UnifiedFunctionDefinition {
						Name = "M1",
						Body = block,
					}
				);
		}

		private static readonly UnifiedClassDefinition WhileExpected =
			CreateClassAndMethod(new UnifiedBlock {
				true.ToLiteral()
					.ToWhile()
					.AddToBody(
						CSharpElement.CreateReturn())
			});

		[Test]
		public void CreateSimpleWhile() {
			const string code = @"
class A { void M1() {
	while(true) return;
} }";

			var actual = CSharpModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(WhileExpected).Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		public void CreateWhile() {
			const string code = @"
class A { void M1() {
	while(true) { return; }
} }";

			var actual = CSharpModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(WhileExpected).Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		public void CreateDoWhile() {
			const string code = @"
class A { void M1() {
	do { return; } while(true)
} }";

			var expected = CreateClassAndMethod(new UnifiedBlock {
				true.ToLiteral()
					.ToDoWhile()
					.AddToBody(CSharpElement.CreateReturn())
			});

			var actual = CSharpModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(WhileExpected).Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		public void CreateFor() {
			const string code = @"
class A { void M1() {
	for (int i = 0; i < 1; i++) { return; }
} }";

			var expected = CreateClassAndMethod(new UnifiedBlock {
				new UnifiedFor {
					Initializer = new UnifiedVariableDefinition {
						Type = "int".ToType(),
						Name = "i",
						InitialValue = 1.ToLiteral(),
					},
					Condition = CSharpModelFactoryHelper.CreateExpression(
						"i".ToVariable(),
						UnifiedBinaryOperatorType.Lesser,
						1.ToLiteral()),
					Step = CSharpModelFactoryHelper.CreateExpression(
						"i".ToVariable(), UnifiedUnaryOperatorType.PostfixIncrement),
					Body = {
						CSharpElement.CreateReturn(),
					},
				}
			});

			var actual = CSharpModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(WhileExpected).Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		public void CreateForEach() {
			const string code = @"
class A { void M1() {
	foreach (var i in new[] { 1 }) { return; }
} }";

			var expected = CreateClassAndMethod(new UnifiedBlock {
				new UnifiedFor {
					Initializer = new UnifiedVariableDefinition {
						Type = "int".ToType(),
						Name = "i",
						InitialValue = 1.ToLiteral(),
					},
					Condition = CSharpModelFactoryHelper.CreateExpression(
						"i".ToVariable(),
						UnifiedBinaryOperatorType.Lesser,
						1.ToLiteral()),
					Step = CSharpModelFactoryHelper.CreateExpression(
						"i".ToVariable(), UnifiedUnaryOperatorType.PostfixIncrement),
					Body = {
						CSharpElement.CreateReturn(),
					},
				}
			});

			var actual = CSharpModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(WhileExpected).Using(StructuralEqualityComparer.Instance));
		}
	}
}
