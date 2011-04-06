using Ucpf.Core.Model;
using Ucpf.Core.Model.Extensions;
using Ucpf.Languages.CSharp;

namespace Ucpf.Core.Tests {
	public static class CSharpAndJavaSpecificationTest {
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

		public static UnifiedProgram WhileModel {
			get {
				return CreateClassAndMethod(new UnifiedBlock {
					true.ToLiteral()
						.ToWhile()
						.AddToBody(
							UnifiedJump.CreateReturn())
				});
			}
		}

		public static UnifiedProgram DoWhileModel {
			get {
				return CreateClassAndMethod(new UnifiedBlock {
					true.ToLiteral()
						.ToDoWhile()
						.AddToBody(UnifiedJump.CreateReturn())
				});
			}
		}

		public static UnifiedProgram ForModel {
			get {
				return CreateClassAndMethod(new UnifiedBlock {
					new UnifiedFor {
						Initializer = new UnifiedVariableDefinition {
							Type = "int".ToType(),
							Name = "i",
							InitialValue = 0.ToLiteral(),
						},
						Condition = CSharpModelFactoryHelper.CreateExpression(
							"i".ToVariable(),
							UnifiedBinaryOperatorType.LessThan,
							1.ToLiteral()),
						Step = CSharpModelFactoryHelper.CreateExpression(
							"i".ToVariable(), UnifiedUnaryOperatorType.PostIncrementAssign),
						Body = {
							UnifiedJump.CreateBreak(),
						},
					}
				});
			}
		}

		public static UnifiedProgram ForeachModel {
			get {
				return CreateClassAndMethod(new UnifiedBlock {
					new UnifiedArrayNew {
						InitialValues = 1.ToLiteral(),
					}.ToForeach("int".ToType(), "i")
						.AddToBody(UnifiedJump.CreateContinue())
				});
			}
		}

		public static UnifiedProgram IfModel {
			get {
				return CreateClassAndMethod(new UnifiedBlock {
					true.ToLiteral()
						.ToIf()
						.AddToBody((-1).ToLiteral().ToReturn())
						.RemoveFalseBody()
				});
			}
		}

		public static UnifiedProgram IfElseModel {
			get {
				return
					CreateClassAndMethod(new UnifiedBlock {
						false.ToLiteral()
							.ToIf()
							.AddToBody((-1).ToLiteral().ToReturn())
							.AddToFalseBody((0.1).ToLiteral().ToReturn())
					});
			}
		}

		public static UnifiedProgram NewGenericTypeModel {
			get {
				return
					CreateClassAndMethod(new UnifiedBlock {
						"List".ToType()
							.AddToParameters("List".ToType()
								.AddToParameters("int".ToType()))
							.ToNew()
					});
			}
		}

		public static UnifiedProgram PlusIntegerLiteralModel {
			get {
				return CreateClassAndMethod(new UnifiedBlock {
					"a".ToVariableDefinition(
						"int".ToType(),
						(+1).ToLiteral()
						),
				});
			}
		}

		public static UnifiedProgram SwitchCaseModel {
			get {
				return CreateClassAndMethod(
					new UnifiedBlock {
						1.ToLiteral()
							.ToSwitch()
							.AddToCases(1.ToLiteral()
								.ToCase()
								.AddToBody(UnifiedJump.CreateBreak())
							)
					});
			}
		}

		public static UnifiedProgram SwitchCaseWithDefaultModel {
			get {
				return
					CreateClassAndMethod(new UnifiedBlock {
						1.ToLiteral()
							.ToSwitch()
							.AddToCases(1.ToLiteral()
								.ToCase()
								.AddToBody(UnifiedJump.CreateBreak())
							)
							.AddToCases(new UnifiedCase {
								Body = { UnifiedJump.CreateBreak() },
							})
					});
			}
		}

		public static string CreateCode(string fragment) {
			return "class A { void M1() {" + fragment + "} }";
		}
	}
}