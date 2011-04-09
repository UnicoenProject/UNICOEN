using System.IO;
using NUnit.Framework;
using Ucpf.Core.Model;
using Ucpf.Core.Tests;

namespace Ucpf.Languages.CSharp.Tests
{
	[TestFixture]
	public class CSharpStudentTest
	{
		private readonly string _source;

		public CSharpStudentTest()
		{
			var path = Fixture.GetInputPath("CSharp", "student.cs");
			_source = File.ReadAllText(path);
		}

		[Test]
		public void CreateExpectedClassDefinition()
		{
			Assert.That(CreateModel(), Is.Not.Null);
		}

		[Test]
		public void CreateClassDefinition()
		{
			var expected = CreateModel();

			var actual = CSharpModelFactory.CreateModel(_source);
			Assert.That(actual,
				Is.EqualTo(expected).Using(StructuralEqualityComparerForDebug.Instance));
		}

		public static UnifiedProgram CreateModel()
		{
			return UnifiedProgram.Create(
				UnifiedClassDefinition.CreateClass(
					"Student",
					UnifiedBlock.Create(new IUnifiedExpression[] {
						UnifiedVariableDefinition.Create(
							UnifiedType.Create("String"),
							"_name",
							UnifiedModifierCollection.Create(UnifiedModifier.Create("private"))
							),
						UnifiedConstructorDefinition.Create(
							UnifiedBlock.Create(
								CSharpModelFactoryHelper.CreateAssignExpression(
									UnifiedIdentifier.CreateUnknown("_name"),
									UnifiedIdentifier.CreateUnknown("name"))
								),
							UnifiedModifier.Create("public"),
							UnifiedParameterCollection.Create(
								UnifiedParameter.Create(
									"name", UnifiedType.Create("String"))
								)
							),
						UnifiedFunctionDefinition.Create(
							"getName",
							UnifiedType.Create("String"),
							UnifiedModifierCollection.Create(
								UnifiedModifier.Create("public")
								),
							UnifiedBlock.Create(
								UnifiedJump.CreateReturn(UnifiedIdentifier.CreateUnknown("_name"))
								)
							),
						UnifiedFunctionDefinition.Create(
							"main",
							UnifiedType.Create("void"),
							UnifiedModifierCollection.Create(
								UnifiedModifier.Create("public"),
								UnifiedModifier.Create("static")
								),
							UnifiedParameterCollection.Create(
								UnifiedParameter.Create("args", UnifiedType.Create("String[]"))
								),
							UnifiedBlock.Create(
								UnifiedVariableDefinition.Create(UnifiedType.Create("Student[]"),
									"students",
									UnifiedArrayNew.Create(UnifiedType.Create("Student"),
										UnifiedArgumentCollection.Create(
											UnifiedArgument.Create(UnifiedIntegerLiteral.Create(2))),
										null)
									),
								CSharpModelFactoryHelper.CreateAssignExpression(
									UnifiedIndexer.Create(UnifiedIdentifier.CreateUnknown("students"),
										UnifiedArgumentCollection.Create(
											UnifiedArgument.Create(UnifiedIntegerLiteral.Create(0)))),
									UnifiedNew.Create(UnifiedType.Create("Student"),
										UnifiedArgumentCollection.Create(
											UnifiedArgument.Create(UnifiedStringLiteral.Create("Tom"))))
									),
								CSharpModelFactoryHelper.CreateAssignExpression(
									UnifiedIndexer.Create(UnifiedIdentifier.CreateUnknown("students"),
										UnifiedArgumentCollection.Create(
											UnifiedArgument.Create(UnifiedIntegerLiteral.Create(1)))),
									UnifiedNew.Create(UnifiedType.Create("Student"),
										UnifiedArgumentCollection.Create(
											UnifiedArgument.Create(UnifiedStringLiteral.Create("Anna"))))
									),
								UnifiedFor.Create(
									UnifiedVariableDefinition.Create(UnifiedType.Create("int"), "i",
										UnifiedIntegerLiteral.Create(0)),
									CSharpModelFactoryHelper.CreateLesserExpression(
										UnifiedIdentifier.CreateUnknown("i"), UnifiedIntegerLiteral.Create(2)),
									CSharpModelFactoryHelper.CreateExpression(
										UnifiedIdentifier.CreateUnknown("i"),
										UnifiedUnaryOperatorType.PostIncrementAssign),
									UnifiedBlock.Create(new[] {
										UnifiedCall.Create(UnifiedIdentifier.CreateUnknown("write"),
											UnifiedArgumentCollection.Create(
												UnifiedArgument.Create(
													UnifiedCall.Create(
														UnifiedProperty.Create(
															UnifiedIndexer.Create(
																UnifiedIdentifier.CreateUnknown("students"),
																UnifiedArgumentCollection.Create(
																	UnifiedArgument.Create(UnifiedIdentifier.CreateUnknown("i")))),
															"getName", "."),
														UnifiedArgumentCollection.Create()
														)
													)
												)
											)
									}
										)
									),
								UnifiedForeach.Create(
									UnifiedVariableDefinition.Create(UnifiedType.Create("Student"),
										"student"),
									UnifiedIdentifier.CreateUnknown("students"),
									UnifiedBlock.Create(
										UnifiedCall.Create(UnifiedIdentifier.CreateUnknown("write"),
											UnifiedArgumentCollection.Create(
												UnifiedArgument.Create(
													UnifiedCall.Create(
														UnifiedProperty.Create(
															UnifiedIdentifier.CreateUnknown("student"), "getName", "."),
														UnifiedArgumentCollection.Create())
													)
												)
											)
										)
									)
								)
							)
					}
						)
					)
				);
		}
	}
}