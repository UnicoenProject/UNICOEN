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
		private static Dictionary<UnifiedBinaryOperatorType, string> BinaryOperatorSigns;
		private static Dictionary<UnifiedUnaryOperatorType, string> UnaryOperatorSigns;

		static CSharpModelFactoryHelper() {
			BinaryOperatorSigns = new Dictionary<UnifiedBinaryOperatorType, string>();
			BinaryOperatorSigns[UnifiedBinaryOperatorType.AddAssignment] = "+=";
			BinaryOperatorSigns[UnifiedBinaryOperatorType.Assignment] = "=";
			BinaryOperatorSigns[UnifiedBinaryOperatorType.Lesser] = "<";

			UnaryOperatorSigns = new Dictionary<UnifiedUnaryOperatorType, string>();
			UnaryOperatorSigns[UnifiedUnaryOperatorType.PostfixDecrement] = "--";
			UnaryOperatorSigns[UnifiedUnaryOperatorType.PrefixDecrement] = "--";
			UnaryOperatorSigns[UnifiedUnaryOperatorType.PostfixIncrement] = "++";
			UnaryOperatorSigns[UnifiedUnaryOperatorType.PrefixIncrement] = "++";
		}

		public static UnifiedBinaryExpression CreateAssignExpression(UnifiedExpression lhs, UnifiedExpression rhs) {
			return CreateExpression(lhs, UnifiedBinaryOperatorType.Assignment, rhs);
		}

		public static UnifiedBinaryExpression CreateLesserExpression(UnifiedExpression lhs, UnifiedExpression rhs) {
			return CreateExpression(lhs, UnifiedBinaryOperatorType.Lesser, rhs);
		}

		public static UnifiedBinaryExpression CreateExpression(UnifiedExpression leftOperand, UnifiedBinaryOperatorType operatorType, UnifiedExpression rightOperand) {
			if (!BinaryOperatorSigns.ContainsKey(operatorType))
				throw new NotImplementedException();
			return new UnifiedBinaryExpression {
				LeftHandSide = leftOperand,
				RightHandSide = rightOperand,
				Operator = new UnifiedBinaryOperator(BinaryOperatorSigns[operatorType], operatorType),
			};
		}

		public static UnifiedUnaryExpression CreateExpression(UnifiedExpression operand, UnifiedUnaryOperatorType operatorType) {
			if (!UnaryOperatorSigns.ContainsKey(operatorType))
				throw new NotImplementedException();
			return new UnifiedUnaryExpression {
				Operand = operand,
				Operator = new UnifiedUnaryOperator(UnaryOperatorSigns[operatorType], operatorType),
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

		[Test]
		public void CreateClassDefinition() {
			var actual = CSharpModelFactory.CreateModel(_source);

			var expected = new UnifiedProgram {
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
							Parameters = {
								new UnifiedParameter {
									Type = UnifiedType.Create("String[]"),
									Name = "args"
								}
							},
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
				
			Assert.That(actual,
				Is.EqualTo(expected).Using(StructuralEqualityComparer.Instance));
		}
	}
}
