using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Ucpf.Common.Model;
using Ucpf.Common.Tests;

namespace Ucpf.Languages.CSharp.Tests {

	public static class CSharpModelFactoryHelper {
		public static UnifiedBinaryExpression CreateAssignExpression(UnifiedExpression lhs, UnifiedExpression rhs) {
			return new UnifiedBinaryExpression {
				LeftHandSide = lhs,
				Operator =
					new UnifiedBinaryOperator("=", UnifiedBinaryOperatorType.Assignment),
				RightHandSide = rhs,
			};
		}
	}

	[TestFixture]
	public class StudentTest {
		private readonly string _source;

		public StudentTest() {
			var path = Fixture.GetInputPath("CSharp", "student.cs");
			_source = File.ReadAllText(path);
		}

		[Ignore, Test]
		public void CreateClassDefinition() {
			var actual = CSharpModelFactory.CreateModel(_source);

			var expected = new UnifiedProgram {
				new UnifiedImport {
					Name = "System"
				},
				new UnifiedClassDefinition {
					Name = "Student",
					Body = new UnifiedBlock {
						new UnifiedVariableDefinition {
							Modifiers = {
								UnifiedModifier.Create("public"),
							},
							Type = new UnifiedType { Name = "string" },
							Name = "_name",
						},
						new UnifiedConstructorDefinition {
							Modifiers = {
								UnifiedModifier.Create("public"),
							},
							Parameters = {
								new UnifiedParameter {
									Type = new UnifiedType { Name = "string" },
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
							ReturnType = new UnifiedType { Name = "string" },
							Name = "getName",
							Block = {
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
							ReturnType = new UnifiedType { Name = "void" },
							Name = "main",
							Block = {
								new UnifiedVariableDefinition {
									Type = new UnifiedType { Name = "Student[]" },
									Name = "students",
									InitialValue = new UnifiedNew {
										Name = "Student",
										Arguments = {
											new UnifiedArgument {
												Value = new UnifiedIntegerLiteral(2),
											},
										},
									},
								},
								CSharpModelFactoryHelper.CreateAssignExpression(
									new UnifiedIndexer {
										Arguments = {
											new UnifiedArgument { Value = new UnifiedIntegerLiteral(0) }
										},
										Target = new UnifiedVariable {
											Name = "students"
										},
									},
									new UnifiedNew {
										Name = "Student",
										Arguments = {
											new UnifiedArgument {
												Value = new UnifiedStringLiteral {
													TypedValue = "Tom"
												},
											},
										},
									}
									),
								CSharpModelFactoryHelper.CreateAssignExpression(
									new UnifiedIndexer {
										Arguments = {
											new UnifiedArgument { Value = new UnifiedIntegerLiteral(1) }
										},
										Target = new UnifiedVariable {
											Name = "students"
										},
									},
									new UnifiedNew {
										Name = "Student",
										Arguments = {
											new UnifiedArgument {
												Value = new UnifiedStringLiteral {
													TypedValue = "Anna",
													Value = "Anna",
												},
											},
										},
									}
									),
								new UnifiedReturn { Value = UnifiedVariable.Create("_name") },
							}
						},
					}
				},
			};
				
			Assert.That(actual,
				Is.EqualTo(expected).Using(StructuralEqualityComparer.Instance));
		}
	}
}
