using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Ucpf.Core.Model;
using Ucpf.Core.Model.Extensions;

namespace Ucpf.Languages.CSharp.Tests {
	[Ignore, TestFixture]
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
						UnifiedBinaryOperatorType.LessThan,
						1.ToLiteral()),
					Step = CSharpModelFactoryHelper.CreateExpression(
						"i".ToVariable(), UnifiedUnaryOperatorType.PostIncrementAssign),
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

		public static readonly UnifiedClassDefinition IfModel =
			CreateClassAndMethod(new UnifiedBlock {
				true.ToLiteral()
					.ToIf()
					.AddToTrueBody((-1).ToLiteral().ToReturn())
			});

		public static readonly UnifiedClassDefinition IfElseModel =
			CreateClassAndMethod(new UnifiedBlock {
				true.ToLiteral()
					.ToIf()
					.AddToTrueBody((-1).ToLiteral().ToReturn())
					.AddToFalseBody((0.1).ToLiteral().ToReturn())
			});

		public static readonly UnifiedClassDefinition NewGenericTypeModel =
			CreateClassAndMethod(new UnifiedBlock {
				
	});

		public static readonly UnifiedClassDefinition PlusIntegerLiteralModel =
			CreateClassAndMethod(new UnifiedBlock {
				"a".ToVariableDefinition(
					"int".ToType(),
					(+1).ToLiteral()
				),
			});

		#endregion

		private static string CreateCode(string fragment) {
			return "class A { void M1() {" + fragment + "} }";
		}

		[Test]
		[TestCase("int a = +1;")]
		public void CreatePlusIntegerLiteral(string fragment) {
			var code = CreateCode(fragment);
			var actual = CSharpModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(PlusIntegerLiteralModel).Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		[TestCase("while(true) return;")]
		[TestCase("while(true) { return; }")]
		[TestCase("while(true) { { return; } }")]
		public void CreateWhile(string fragment) {
			var code = CreateCode(fragment);
			var actual = CSharpModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(WhileModel).Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		[TestCase("do return; while(true);")]
		[TestCase("do { return; } while(true);")]
		[TestCase("do { { return; } } while(true);")]
		public void CreateDoWhile(string fragment) {
			var code = CreateCode(fragment);
			var actual = CSharpModelFactory.CreateModel(code);

			Assert.That(actual,
			    Is.EqualTo(DoWhileModel).Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		[TestCase("for (int i = 0; i < 1; i++) break;")]
		[TestCase("for (int i = 0; i < 1; i++) { break; }")]
		[TestCase("for (int i = 0; i < 1; i++) { { break; } }")]
		public void CreateFor(string fragment) {
			var code = CreateCode(fragment);
			var actual = CSharpModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(ForModel).Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		[TestCase("foreach (int i in new[] { 1 }) continue;")]
		[TestCase("foreach (int i in new[] { 1 }) { continue; }")]
		[TestCase("foreach (int i in new[] { 1 }) { { continue; } }")]
		public void CreateForeach(string fragment) {
			var code = CreateCode(fragment);
			var actual = CSharpModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(ForeachModel).Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		[TestCase("if (true) return -1;")]
		[TestCase("if (true) { return -1; }")]
		[TestCase("if (true) { { return -1; } }")]
		[TestCase("if (true) { { { return -1; } } }")]
		public void CreateIf(string fragment) {
			var code = CreateCode(fragment);
			var actual = CSharpModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(IfModel).Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		[TestCase("if (true) return -1; else return 0.1;")]
		[TestCase("if (true) { return -1; } else return 0.1;")]
		[TestCase("if (true) return -1; else { return 0.1; }")]
		[TestCase("if (true) { return -1; } else { return 0.1; }")]
		[TestCase("if (true) { { return -1; } } else { return 0.1; }")]
		[TestCase("if (true) { return -1; } else { { return 0.1; } }")]
		[TestCase("if (true) { { return -1; } } else { { return 0.1; } }")]
		[TestCase("if (true) { { { return -1; } } } else { { return 0.1; } }")]
		[TestCase("if (true) { { return -1; } } else { { { return 0.1; } } }")]
		[TestCase("if (true) return -1; else { { { return 0.1; } } }")]
		[TestCase("if (true) { { { return -1; } } } else return 0.1;")]
		[TestCase("if (true) { { { return -1; } } } else { { { return 0.1; } } }")]
		public void CreateIfElse(string fragment) {
			var code = CreateCode(fragment);
			var actual = CSharpModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(IfElseModel).Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		[TestCase("new ArrayList<ArrayList<Integer>>();")]
		public void CreateNewGenericType(string fragment) {
			var code = CreateCode(fragment);
			var actual = CSharpModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(NewGenericTypeModel).Using(StructuralEqualityComparer.Instance));
		}
	}
}
