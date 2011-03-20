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

		public static UnifiedProgram CreateClassAndMethod(UnifiedBlock block) {
			return new UnifiedProgram {
				"A".ToClassDefinition()
					.AddToBody(
						new UnifiedFunctionDefinition {
							Type = "void".ToType(),
							Name = "M1",
							Body = block,
						}
					),
			};
		}

		public static readonly UnifiedProgram WhileModel =
			CreateClassAndMethod(new UnifiedBlock {
				true.ToLiteral()
					.ToWhile()
					.AddToBody(
						CSharpModelFactoryHelper.CreateReturn())
			});

		public static readonly UnifiedProgram DoWhileModel = CreateClassAndMethod(new UnifiedBlock {
				true.ToLiteral()
					.ToDoWhile()
					.AddToBody(CSharpModelFactoryHelper.CreateReturn())
			});

		public static readonly UnifiedProgram ForModel = CreateClassAndMethod(new UnifiedBlock {
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

		public static readonly UnifiedProgram ForeachModel =
			CreateClassAndMethod(new UnifiedBlock {
				new UnifiedArrayNew {
					InitialValues = {
						1.ToLiteral(),
					}
				}.ToForeach("int".ToType(), "i")
					.AddToBody(CSharpModelFactoryHelper.CreateContinue())
			});

		public static readonly UnifiedProgram IfModel =
			CreateClassAndMethod(new UnifiedBlock {
				true.ToLiteral()
					.ToIf()
					.AddToTrueBody((-1).ToLiteral().ToReturn())
			});

		public static readonly UnifiedProgram IfElseModel =
			CreateClassAndMethod(new UnifiedBlock {
				true.ToLiteral()
					.ToIf()
					.AddToTrueBody((-1).ToLiteral().ToReturn())
					.AddToFalseBody((0.1).ToLiteral().ToReturn())
			});

		public static readonly UnifiedProgram NewGenericTypeModel =
			CreateClassAndMethod(new UnifiedBlock {
				"List".ToType()
					.AddToParameters("List".ToType()
						.AddToParameters("int".ToType()))
					.ToNew()
			});

		public static readonly UnifiedProgram PlusIntegerLiteralModel =
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

		[Ignore, Test]
		[TestCase("while(true) return;")]
		[TestCase("while(true) { return; }")]
		[TestCase("while(true) { { return; } }")]
		public void CreateWhile(string fragment) {
			var code = CreateCode(fragment);
			var actual = CSharpModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(WhileModel).Using(StructuralEqualityComparer.Instance));
		}

		[Ignore, Test]
		[TestCase("do return; while(true);")]
		[TestCase("do { return; } while(true);")]
		[TestCase("do { { return; } } while(true);")]
		public void CreateDoWhile(string fragment) {
			var code = CreateCode(fragment);
			var actual = CSharpModelFactory.CreateModel(code);

			Assert.That(actual,
			    Is.EqualTo(DoWhileModel).Using(StructuralEqualityComparer.Instance));
		}

		[Ignore, Test]
		[TestCase("for (int i = 0; i < 1; i++) break;")]
		[TestCase("for (int i = 0; i < 1; i++) { break; }")]
		[TestCase("for (int i = 0; i < 1; i++) { { break; } }")]
		public void CreateFor(string fragment) {
			var code = CreateCode(fragment);
			var actual = CSharpModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(ForModel).Using(StructuralEqualityComparer.Instance));
		}

		[Ignore, Test]
		[TestCase("foreach (int i in new[] { 1 }) continue;")]
		[TestCase("foreach (int i in new[] { 1 }) { continue; }")]
		[TestCase("foreach (int i in new[] { 1 }) { { continue; } }")]
		public void CreateForeach(string fragment) {
			var code = CreateCode(fragment);
			var actual = CSharpModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(ForeachModel).Using(StructuralEqualityComparer.Instance));
		}

		[Ignore, Test]
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

		[Ignore, Test]
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

		[Ignore, Test]
		[TestCase("new List<List<int>>();")]
		public void CreateNewGenericType(string fragment) {
			var code = CreateCode(fragment);
			var actual = CSharpModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(NewGenericTypeModel).Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		[TestCase("int a = +1;")]
		public void CreatePlusIntegerLiteral(string fragment) {
			var code = CreateCode(fragment);
			var actual = CSharpModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(PlusIntegerLiteralModel).Using(StructuralEqualityComparer.Instance));
		}
	}
}
