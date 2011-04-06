using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Ucpf.Core.Model;
using Ucpf.Core.Tests;

namespace Ucpf.Languages.CSharp.Tests {
	[TestFixture]
	public class CSharpStudentTest {
		private readonly string _source;

		public CSharpStudentTest() {
			var path = Fixture.GetInputPath("CSharp", "student.cs");
			_source = File.ReadAllText(path);
		}

		[Test]
		public void CreateExpectedClassDefinition() {
			Assert.That(CreateModel(), Is.Not.Null);
		}

		[Test]
		public void CreateClassDefinition() {
			var expected = CreateModel();

			var actual = CSharpModelFactory.CreateModel(_source);
			Assert.That(actual,
				Is.EqualTo(expected).Using(StructuralEqualityComparerForDebug.Instance));
		}

		public static UnifiedProgram CreateModel() {
			return new UnifiedProgram {
				UnifiedClassDefinition.Create(
					"Student",
					UnifiedBlock.Create(new IUnifiedExpression[] {
						new UnifiedVariableDefinition {
							Modifiers = {
								UnifiedModifier.Create("private"),
							},
							Type = UnifiedType.Create("String"),
							Name = "_name",
						},
						UnifiedConstructorDefinition.Create(
							UnifiedBlock.Create(
								CSharpModelFactoryHelper.CreateAssignExpression(
									UnifiedVariable.Create("_name"), UnifiedVariable.Create("name"))
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
								UnifiedJump.CreateReturn( UnifiedVariable.Create("_name"))
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
								new UnifiedVariableDefinition {
									Type = UnifiedType.Create("Student[]"),
									Name = "students",
									InitialValue = new UnifiedArrayNew {
										Type = UnifiedType.Create("Student"),
										Arguments = {
											UnifiedArgument.Create(UnifiedIntegerLiteral.Create(2)),
										},
										InitialValues = null,
									},
								},
								CSharpModelFactoryHelper.CreateAssignExpression(
									new UnifiedIndexer {
										Target = UnifiedVariable.Create("students"),
										Arguments = {
											UnifiedArgument.Create(UnifiedIntegerLiteral.Create(0)),
										},
									},
									new UnifiedNew {
										Type = UnifiedType.Create("Student"),
										Arguments = {
											UnifiedArgument.Create(UnifiedStringLiteral.Create("Tom")),
										},
									}
									),
								CSharpModelFactoryHelper.CreateAssignExpression(
									new UnifiedIndexer {
										Target = UnifiedVariable.Create("students"),
										Arguments = {
											UnifiedArgument.Create(UnifiedIntegerLiteral.Create(1)),
										},
									},
									new UnifiedNew {
										Type = UnifiedType.Create("Student"),
										Arguments = {
											UnifiedArgument.Create(UnifiedStringLiteral.Create("Anna")),
										},
									}
									),
								UnifiedFor.Create(
									new UnifiedVariableDefinition {
										Type = UnifiedType.Create("int"),
										Name = "i",
										InitialValue = UnifiedIntegerLiteral.Create(0),
									},
									CSharpModelFactoryHelper.CreateLesserExpression(
										UnifiedVariable.Create("i"), UnifiedIntegerLiteral.Create(2)),
									CSharpModelFactoryHelper.CreateExpression(
										UnifiedVariable.Create("i"), UnifiedUnaryOperatorType.PostIncrementAssign),
									UnifiedBlock.Create(new[] {
										new UnifiedCall {
											Function = UnifiedVariable.Create("write"),
											Arguments = {
												UnifiedArgument.Create(
													new UnifiedCall {
														Function = new UnifiedProperty {
															Owner = new UnifiedIndexer {
																Target = UnifiedVariable.Create("students"),
																Arguments = {
																	UnifiedArgument.Create(UnifiedVariable.Create("i"))
																},
															},
															Name = "getName",
														},
													}),
											},
										}
									})
								),
								UnifiedForeach.Create(
									new UnifiedVariableDefinition {
										Type = UnifiedType.Create("Student"),
										Name = "student",
									},
									UnifiedVariable.Create("students"),
									UnifiedBlock.Create(
										new UnifiedCall {
											Function = UnifiedVariable.Create("write"),
											Arguments = {
												UnifiedArgument.Create(
													new UnifiedCall {
														Function = new UnifiedProperty {
															Owner = UnifiedVariable.Create("student"),
															Name = "getName",
														},
													}),
											},
										}
									)
								)
							)
						)
					})
				),
			};
		}
	}
}
