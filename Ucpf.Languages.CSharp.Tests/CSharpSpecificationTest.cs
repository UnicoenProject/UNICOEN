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
		#region Models

		public static UnifiedClassDefinition CreateClassAndMethod(UnifiedBlock block) {
			return "A".ToClassDefinition()
				.AddToBody(
					new UnifiedFunctionDefinition {
						Name = "M1",
						Body = block,
					}
				);
		}

		public static readonly UnifiedClassDefinition WhileModel =
			CreateClassAndMethod(new UnifiedBlock {
				true.ToLiteral()
					.ToWhile()
					.AddToBody(
						CSharpModelFactoryHelper.CreateReturn())
			});

		public static UnifiedClassDefinition DoWhileModel = CreateClassAndMethod(new UnifiedBlock {
				true.ToLiteral()
					.ToDoWhile()
					.AddToBody(CSharpModelFactoryHelper.CreateReturn())
			});

		public static UnifiedClassDefinition ForModel = CreateClassAndMethod(new UnifiedBlock {
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
						CSharpModelFactoryHelper.CreateBreak(),
					},
				}
			});

		public static UnifiedClassDefinition ForeachModel =
			CreateClassAndMethod(new UnifiedBlock {
				new UnifiedArrayNew {
					InitialValues = {
						1.ToLiteral(),
					}
				}.ToForeach("int".ToType(), "i")
					.AddToBody(CSharpModelFactoryHelper.CreateContinue())
			});

		#endregion

		[Test]
		public void CreateSimpleWhile() {
			const string code = @"
class A { void M1() {
	while(true) return;
} }";

			var actual = CSharpModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(WhileModel).Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		public void CreateWhile() {
			const string code = @"
class A { void M1() {
	while(true) { return; }
} }";

			var actual = CSharpModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(WhileModel).Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		public void CreateDoWhile() {
			const string code = @"
class A { void M1() {
	do { return; } while(true)
} }";

			var actual = CSharpModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(DoWhileModel).Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		public void CreateFor() {
			const string code = @"
class A { void M1() {
	for (int i = 0; i < 1; i++) { break; }
} }";

			var actual = CSharpModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(ForModel).Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		public void CreateForeach() {
			const string code = @"
class A { void M1() {
	foreach (int i in new[] { 1 }) { continue; }
} }";

			var actual = CSharpModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(ForeachModel).Using(StructuralEqualityComparer.Instance));
		}
	}
}
