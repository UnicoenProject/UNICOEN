using Ucpf.Core.Model;
using Ucpf.Core.Model.Extensions;
using Ucpf.Languages.CSharp;

namespace Ucpf.Core.Tests
{
	public static class CSharpAndJavaSpecificationTest
	{
		public static UnifiedProgram CreateClassAndMethod(UnifiedBlock block)
		{
			return UnifiedProgram.Create(
				"A".ToClassDefinition()
					.AddToBody(
						UnifiedFunctionDefinition.CreateFunction(
							"M1",
							"void".ToType(),
							block
							)
					)
				);
		}

		public static UnifiedProgram WhileModel
		{
			get
			{
				return CreateClassAndMethod(
					UnifiedBlock.Create(new IUnifiedExpression[] {
						true.ToLiteral()
							.ToWhile()
							.AddToBody(
								UnifiedSpecialExpression.CreateReturn())
					}));
			}
		}

		public static UnifiedProgram DoWhileModel
		{
			get
			{
				return CreateClassAndMethod(
					UnifiedBlock.Create(new IUnifiedExpression[] {
						true.ToLiteral()
							.ToDoWhile()
							.AddToBody(UnifiedSpecialExpression.CreateReturn())
					}));
			}
		}

		public static UnifiedProgram ForModel
		{
			get
			{
				return CreateClassAndMethod(UnifiedBlock.Create(
					UnifiedFor.Create(
						UnifiedVariableDefinition.CreateSingle("int".ToType(), "i", 0.ToLiteral()),
						CSharpModelFactoryHelper.CreateExpression(
							"i".ToVariable(),
							UnifiedBinaryOperatorKind.LessThan,
							1.ToLiteral()),
						CSharpModelFactoryHelper.CreateExpression(
							"i".ToVariable(), UnifiedUnaryOperatorKind.PostIncrementAssign),
						UnifiedBlock.Create(
							UnifiedSpecialExpression.CreateBreak()
							)
						)
					));
			}
		}

		public static UnifiedProgram ForeachModel
		{
			get
			{
				return CreateClassAndMethod(UnifiedBlock.Create(
					UnifiedNew.CreateArray(
						1.ToLiteral().ToExpressionList())
						.ToForeach("int".ToType(), "i")
						.AddToBody(UnifiedSpecialExpression.CreateContinue())
					));
			}
		}

		public static UnifiedProgram IfModel
		{
			get
			{
				return CreateClassAndMethod(UnifiedBlock.Create(new IUnifiedExpression[] {
					true.ToLiteral()
						.ToIf()
						.AddToBody((-1).ToLiteral().ToReturn())
						.RemoveFalseBody()
				}));
			}
		}

		public static UnifiedProgram IfElseModel
		{
			get
			{
				return
					CreateClassAndMethod(UnifiedBlock.Create(new IUnifiedExpression[] {
						false.ToLiteral()
							.ToIf()
							.AddToBody((-1).ToLiteral().ToReturn())
							.AddToFalseBody((0.1).ToLiteral().ToReturn())
					}));
			}
		}

		public static UnifiedProgram NewGenericTypeModel
		{
			get
			{
				return
					CreateClassAndMethod(UnifiedBlock.Create(new IUnifiedExpression[] {
						"List".ToType()
							.AddToParameters("List".ToType()
								.AddToParameters("int".ToType()))
							.ToNew()
					}));
			}
		}

		public static UnifiedProgram PlusIntegerLiteralModel
		{
			get
			{
				return CreateClassAndMethod(UnifiedBlock.Create(new IUnifiedExpression[] {
					"a".ToVariableDefinition(
						"int".ToType(),
						(+1).ToLiteral()
						),
				}));
			}
		}

		public static UnifiedProgram SwitchCaseModel
		{
			get
			{
				return CreateClassAndMethod(
					UnifiedBlock.Create(new IUnifiedExpression[] {
						1.ToLiteral()
							.ToSwitch()
							.AddToCases(1.ToLiteral()
								.ToCase()
								.AddToBody(UnifiedSpecialExpression.CreateBreak())
							)
					}));
			}
		}

		public static UnifiedProgram CastModel
		{
			get
			{
				return CreateClassAndMethod(
					UnifiedBlock.Create(
						"i".ToVariableDefinition(
							"Integer".ToType(),
							UnifiedCast.Create(
								UnifiedType.CreateUsingString("Integer"),
								UnifiedIntegerLiteral.Create(1)
								)
							)));
			}
		}

		public static UnifiedProgram SwitchCaseWithDefaultModel
		{
			get
			{
				return
					CreateClassAndMethod(UnifiedBlock.Create(
						1.ToLiteral()
							.ToSwitch()
							.AddToCases(1.ToLiteral()
								.ToCase()
								.AddToBody(UnifiedSpecialExpression.CreateBreak())
							)
							.AddToCases(UnifiedCase.Create(UnifiedBlock.Create(
								UnifiedSpecialExpression.CreateBreak()))
							)
						));
			}
		}

		public static UnifiedProgram SynchronizedModel
		{
			get
			{
				return CreateClassAndMethod(UnifiedBlock.Create(
					UnifiedSpecialBlock.Create(
						UnifiedSpecialBlockKind.Synchronized,
						UnifiedIdentifier.CreateUnknown("this"),
						UnifiedBlock.Create(
							UnifiedCall.Create(
								UnifiedIdentifier.CreateUnknown("M1"),
								UnifiedArgumentCollection.Create())))));
			}
		}

		public static UnifiedProgram ThrowModel
		{
			get
			{
				return CreateClassAndMethod(UnifiedBlock.Create(
					UnifiedSpecialExpression.CreateThrow(
						UnifiedNew.Create(
							UnifiedType.CreateUsingString("Exception"),
							UnifiedArgumentCollection.Create()))));
			}
		}

		public static UnifiedProgram TryCatchModel
		{
			get
			{
				return
					CreateClassAndMethod(UnifiedBlock.Create(
						UnifiedTry.Create(
							UnifiedBlock.Create(
								"i".ToVariableDefinition(
									"int".ToType(),
									0.ToLiteral())
								),
							UnifiedCatchCollection.Create(),
							null)
						));
			}
		}

		public static UnifiedProgram TryCatchWithTypeModel
		{
			get
			{
				return CreateClassAndMethod(UnifiedBlock.Create(
					UnifiedTry.Create(
						UnifiedBlock.Create(
							"i".ToVariableDefinition(
								"int".ToType(),
								0.ToLiteral())
							),
						UnifiedCatchCollection.Create(
							UnifiedCatch.Create(
								UnifiedParameterCollection.Create(
									UnifiedParameter.Create(null, "Exception".ToType())),
								UnifiedBlock.Create())),
						null)));
			}
		}

		public static UnifiedProgram TryCatchWithVariableModel
		{
			get
			{
				return CreateClassAndMethod(UnifiedBlock.Create(
					UnifiedTry.Create(
						UnifiedBlock.Create(
							"i".ToVariableDefinition(
								"int".ToType(),
								0.ToLiteral())),
						UnifiedCatchCollection.Create(
							UnifiedCatch.Create(
								UnifiedParameterCollection.Create(
									UnifiedParameter.Create("e", "Exception".ToType())),
								UnifiedBlock.Create())),
						null)
					));
			}
		}

		public static UnifiedProgram TryCatchWithTwoVariableModel
		{
			get
			{
				return CreateClassAndMethod(UnifiedBlock.Create(
					UnifiedTry.Create(
						UnifiedBlock.Create(
							"i".ToVariableDefinition(
								"int".ToType(),
								0.ToLiteral())),
						UnifiedCatchCollection.Create(
							UnifiedCatch.Create(
								UnifiedParameterCollection.Create(
									UnifiedParameter.Create("e", "Exception".ToType())),
								UnifiedBlock.Create()),
							UnifiedCatch.Create(
								UnifiedParameterCollection.Create(
									UnifiedParameter.Create("e", "Exception".ToType())),
								UnifiedBlock.Create())),
						null)
					));
			}
		}

		public static UnifiedProgram TryFinallyModel
		{
			get
			{
				return CreateClassAndMethod(UnifiedBlock.Create(
					UnifiedTry.Create(
						UnifiedBlock.Create(
							"i".ToVariableDefinition(
								"int".ToType(),
								0.ToLiteral())),
						null,
						UnifiedBlock.Create())
					));
			}
		}

		public static UnifiedProgram TryCatchFinallyModel
		{
			get
			{
				return CreateClassAndMethod(UnifiedBlock.Create(
					UnifiedTry.Create(
						UnifiedBlock.Create(
							"i".ToVariableDefinition(
								"int".ToType(),
								0.ToLiteral())),
						UnifiedCatchCollection.Create(
							UnifiedCatch.Create(
								UnifiedParameterCollection.Create(
									UnifiedParameter.Create("e", "Exception".ToType())),
								UnifiedBlock.Create())),
						UnifiedBlock.Create())
					));
			}
		}

		public static string CreateCode(string fragment)
		{
			return "class A { void M1() {" + fragment + "} }";
		}
	}
}