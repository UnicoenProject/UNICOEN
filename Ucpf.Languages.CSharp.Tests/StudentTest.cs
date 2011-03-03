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

		public static UnifiedBinaryExpression CreateLesserExpression(UnifiedExpression lhs, UnifiedExpression rhs) {
			return new UnifiedBinaryExpression {
				LeftHandSide = lhs,
				Operator =
					new UnifiedBinaryOperator("<", UnifiedBinaryOperatorType.Lesser),
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
					Body =  {
						new UnifiedVariableDefinition {
							Modifiers = {
								UnifiedModifier.Create("public"),
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
							Type = UnifiedType.Create("void"),
							Name = "main",
							Block = {
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
										Arguments = {
											UnifiedArgument.Create(UnifiedIntegerLiteral.Create(0)),
										},
										Target = UnifiedVariable.Create("students"),
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
										Arguments = {
											UnifiedArgument.Create(UnifiedIntegerLiteral.Create(1)),
										},
										Target = UnifiedVariable.Create("students"),
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
									Step = ,
								}
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
