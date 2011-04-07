using Ucpf.Core.Model;
using Ucpf.Core.Model.Extensions;
using Ucpf.Languages.CSharp;

namespace Ucpf.Core.Tests {
	public static class CSharpAndJavaSpecificationTest {
		public static UnifiedProgram CreateClassAndMethod(UnifiedBlock block) {
			return new UnifiedProgram {
				"A".ToClassDefinition()
					.AddToBody(
						UnifiedFunctionDefinition.Create(
							"M1",
							"void".ToType(),
							block
						)
					),
			};
		}

		public static UnifiedProgram WhileModel {
			get {
				return CreateClassAndMethod(
					UnifiedBlock.Create(new IUnifiedExpression[] {
						true.ToLiteral()
							.ToWhile()
							.AddToBody(
								UnifiedJump.CreateReturn())
				}));
			}
		}

		public static UnifiedProgram DoWhileModel {
			get {
				return CreateClassAndMethod(
					UnifiedBlock.Create(new IUnifiedExpression[] {
					true.ToLiteral()
						.ToDoWhile()
						.AddToBody(UnifiedJump.CreateReturn())
				}));
			}
		}

		public static UnifiedProgram ForModel {
			get {
				return CreateClassAndMethod(UnifiedBlock.Create(
					UnifiedFor.Create(
						UnifiedVariableDefinition.Create("int".ToType(), "i", 0.ToLiteral()),
						CSharpModelFactoryHelper.CreateExpression(
							"i".ToVariable(),
							UnifiedBinaryOperatorType.LessThan,
							1.ToLiteral()),
						CSharpModelFactoryHelper.CreateExpression(
							"i".ToVariable(), UnifiedUnaryOperatorType.PostIncrementAssign),
						UnifiedBlock.Create(
							UnifiedJump.CreateBreak()
						)
					)
				));
			}
		}

		public static UnifiedProgram ForeachModel {
			get {
				return CreateClassAndMethod(UnifiedBlock.Create(new IUnifiedExpression[] {
					new UnifiedArrayNew {
						InitialValues = 1.ToLiteral(),
					}.ToForeach("int".ToType(), "i")
						.AddToBody(UnifiedJump.CreateContinue())
				}));
			}
		}

		public static UnifiedProgram IfModel {
			get {
				return CreateClassAndMethod(UnifiedBlock.Create(new IUnifiedExpression[] {
					true.ToLiteral()
						.ToIf()
						.AddToBody((-1).ToLiteral().ToReturn())
						.RemoveFalseBody()
				}));
			}
		}

		public static UnifiedProgram IfElseModel {
			get {
				return
					CreateClassAndMethod(UnifiedBlock.Create(new IUnifiedExpression[] {
						false.ToLiteral()
							.ToIf()
							.AddToBody((-1).ToLiteral().ToReturn())
							.AddToFalseBody((0.1).ToLiteral().ToReturn())
					}));
			}
		}

		public static UnifiedProgram NewGenericTypeModel {
			get {
				return
					CreateClassAndMethod(UnifiedBlock.Create(new IUnifiedExpression[] {
						"List".ToType()
							.AddToParameters("List".ToType()
								.AddToParameters("int".ToType()))
							.ToNew()
					}));
			}
		}

		public static UnifiedProgram PlusIntegerLiteralModel {
			get {
				return CreateClassAndMethod(UnifiedBlock.Create(new IUnifiedExpression[] {
					"a".ToVariableDefinition(
						"int".ToType(),
						(+1).ToLiteral()
						),
				}));
			}
		}

		public static UnifiedProgram SwitchCaseModel {
			get {
				return CreateClassAndMethod(
					UnifiedBlock.Create(new IUnifiedExpression[] {
						1.ToLiteral()
							.ToSwitch()
							.AddToCases(1.ToLiteral()
								.ToCase()
								.AddToBody(UnifiedJump.CreateBreak())
							)
					}));
			}
		}

		public static UnifiedProgram SwitchCaseWithDefaultModel {
			get {
				return
					CreateClassAndMethod(UnifiedBlock.Create(new IUnifiedExpression[] {
						1.ToLiteral()
							.ToSwitch()
							.AddToCases(1.ToLiteral()
								.ToCase()
								.AddToBody(UnifiedJump.CreateBreak())
							)
							.AddToCases(UnifiedCase.Create(UnifiedBlock.Create(
								 UnifiedJump.CreateBreak()))
							)
					}));
			}
		}

		public static string CreateCode(string fragment) {
			return "class A { void M1() {" + fragment + "} }";
		}
	}
}