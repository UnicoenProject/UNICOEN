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
							CSharpModelFactoryHelper.CreateReturn())
				});
			}
		}

		public static UnifiedProgram DoWhileModel {
			get {
				return CreateClassAndMethod(new UnifiedBlock {
					true.ToLiteral()
						.ToDoWhile()
						.AddToBody(CSharpModelFactoryHelper.CreateReturn())
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
							CSharpModelFactoryHelper.CreateBreak(),
						},
					}
				});
			}
		}

		public static UnifiedProgram ForeachModel {
			get {
				return CreateClassAndMethod(new UnifiedBlock {
					new UnifiedArrayNew {
						InitialValues = {
							1.ToLiteral(),
						}
					}.ToForeach("int".ToType(), "i")
						.AddToBody(CSharpModelFactoryHelper.CreateContinue())
				});
			}
		}

		public static UnifiedProgram IfModel {
			get {
				return CreateClassAndMethod(new UnifiedBlock {
					true.ToLiteral()
						.ToIf()
						.AddToTrueBody((-1).ToLiteral().ToReturn())
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
							.AddToTrueBody((-1).ToLiteral().ToReturn())
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
				return
					CreateClassAndMethod(new UnifiedBlock {
						1.ToLiteral()
							.ToSwitch()
							.AddToCases(1.ToLiteral()
								.ToCase()
								.AddToBody(new UnifiedBreak())
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
								.AddToBody(new UnifiedBreak())
							)
							.AddToCases(new UnifiedCase {
								Body = { new UnifiedBreak() },
							})
					});
			}
		}

		public static string CreateCode(string fragment) {
			return "class A { void M1() {" + fragment + "} }";
		}
	}
}