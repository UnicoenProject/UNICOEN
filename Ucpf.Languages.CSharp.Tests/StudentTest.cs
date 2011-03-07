using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Ucpf.Core.Model;
using Ucpf.Core.Tests;

namespace Ucpf.Languages.CSharp.Tests {
	[TestFixture]
	public class StudentTest {
		private readonly string _source;

		public StudentTest() {
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
				Is.EqualTo(expected).Using(StructuralEqualityComparer.Instance));
		}

		public static UnifiedProgram CreateModel() {
			return new UnifiedProgram {
				new UnifiedClassDefinition {
					Name = "Student",
					Body = {
						new UnifiedVariableDefinition {
							Modifiers = {
								UnifiedModifier.Create("private"),
							},
							Type = UnifiedType.Create("String"),
							Name = "_name",
						},
						new UnifiedConstructorDefinition {
							Modifiers = {
								UnifiedModifier.Create("public"),
							},
							Parameters = {
								new UnifiedParameter {
									Type = UnifiedType.Create("String"),
									Name = "name",
								}
							},
							Block = {
								CSharpModelFactoryHelper.CreateAssignExpression(
									UnifiedVariable.Create("_name"), UnifiedVariable.Create("name"))
							},
						},
						new UnifiedFunctionDefinition {
							Modifiers = {
								UnifiedModifier.Create("public"),
							},
							Type = UnifiedType.Create("String"),
							Name = "getName",
							Body = {
								new UnifiedReturn {
									Value = UnifiedVariable.Create("_name")
								},
							}
						},
						new UnifiedFunctionDefinition {
							Modifiers = {
								UnifiedModifier.Create("public"),
								UnifiedModifier.Create("static"),
							},
							Type = UnifiedType.Create("void"),
							Name = "main",
							Parameters = {
								new UnifiedParameter {
									Type = UnifiedType.Create("String[]"),
									Name = "args"
								}
							},
							Body = {
								new UnifiedVariableDefinition {
									Type = UnifiedType.Create("Student[]"),
									Name = "students",
									InitialValue = new UnifiedArrayNew {
										Type = UnifiedType.Create("Student"),
										Arguments = {
											UnifiedArgument.Create(UnifiedIntegerLiteral.Create(2)),
										},
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
								new UnifiedFor {
									Initializer = new UnifiedVariableDefinition {
										Type = UnifiedType.Create("int"),
										Name = "i",
										InitialValue = UnifiedIntegerLiteral.Create(0),
									},
									Condition = CSharpModelFactoryHelper.CreateLesserExpression(
										UnifiedVariable.Create("i"), UnifiedIntegerLiteral.Create(2)),
									Step = CSharpModelFactoryHelper.CreateExpression(
										UnifiedVariable.Create("i"), UnifiedUnaryOperatorType.PostfixIncrement),
									Block = {
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
									}
								},
								new UnifiedForeach {
									Element = new UnifiedVariableDefinition {
										Type = UnifiedType.Create("Student"),
										Name = "student",
									},
									Set = UnifiedVariable.Create("students"),
									Block = {
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
									}
								}
							}
						},
					}
				},
			};
		}
	}
}
