using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Ucpf.Core.Model;
using Ucpf.Core.Tests;

namespace Ucpf.Languages.CSharp.Tests {

	[TestFixture]
	public class CSharpFibonacciTest {

		#region data

		private static readonly string Code =
			File.ReadAllText(Fixture.GetInputPath("CSharp", "Fibonacci.cs"));

		public static readonly UnifiedProgram Model = new UnifiedProgram {
			new UnifiedClassDefinition {
				Name = "Fibonacci",
				Body = {
					new UnifiedFunctionDefinition {
						Name = "fibonacci",
						Type = UnifiedType.Create("int"),
						Modifiers = {
							UnifiedModifier.Create("public"),
							UnifiedModifier.Create("static"),
						},
						Parameters = {
							new UnifiedParameter {
								Type = UnifiedType.Create("int"), Name = "n"
							}
						},
						Body = {
							new UnifiedIf {
								Condition = new UnifiedBinaryExpression {
									Operator =
										new UnifiedBinaryOperator("<", UnifiedBinaryOperatorType.Lesser),
									LeftHandSide = UnifiedVariable.Create("n"),
									RightHandSide = UnifiedIntegerLiteral.Create(2)
								},
								TrueBlock = {
									new UnifiedReturn {
										Value = UnifiedVariable.Create("n")
									}
								},
								FalseBlock = {
									new UnifiedReturn {
										Value = new UnifiedBinaryExpression {
											Operator =
												new UnifiedBinaryOperator("+", UnifiedBinaryOperatorType.Add),
											LeftHandSide = new UnifiedCall {
												Function = UnifiedVariable.Create("fibonacci"),
												Arguments = {
													new UnifiedArgument {
														Value = new UnifiedBinaryExpression {
															Operator =
																new UnifiedBinaryOperator("-",
																	UnifiedBinaryOperatorType.Subtract),
															LeftHandSide = UnifiedVariable.Create("n"),
															RightHandSide = UnifiedIntegerLiteral.Create(1)
														}
													}
												}
											},
											RightHandSide = new UnifiedCall {
												Function = UnifiedVariable.Create("fibonacci"),
												Arguments = {
													UnifiedArgument.Create(new UnifiedBinaryExpression {
														Operator =
															new UnifiedBinaryOperator("-",
																UnifiedBinaryOperatorType.Subtract),
														LeftHandSide = UnifiedVariable.Create("n"),
														RightHandSide = UnifiedIntegerLiteral.Create(2)
													})
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		};

		#endregion

		[Test]
		public void CreateFibonacci() {
			var actual = CSharpModelFactory.CreateModel(Code);
			var expected = Model;
			Assert.That(actual,
				Is.EqualTo(expected).Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		public void CreateClassDeclare() {
			const string code = "class Fibonacci{}";
			var expected = new UnifiedProgram(new[]{new UnifiedClassDefinition {
				Name = "Fibonacci",
			}});
			var actual = CSharpModelFactory.CreateModel(code);
			Assert.That(actual,
				Is.EqualTo(expected).Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		public void CreateFuncDec() {
			const string code =
				@"
class Fibonacci {
	public static void fibonacci(int n) {
	}
}
";
			var expected = new UnifiedProgram(new[]{new UnifiedClassDefinition {
				Name = "Fibonacci",
				Body = new UnifiedBlock {
					new UnifiedFunctionDefinition {
						Name = "fibonacci",
						Type = UnifiedType.Create("void"),
						Modifiers = {
							new UnifiedModifier {
								Name = "public"
							},
							new UnifiedModifier {
								Name = "static"
							}
						},
						Parameters = {
							new UnifiedParameter {
								Type = UnifiedType.Create("int"),
								Name = "n",
							}
						},
					}
				}
			}});
			var actual = CSharpModelFactory.CreateModel(code);
			Assert.That(actual,
				Is.EqualTo(expected).Using(StructuralEqualityComparer.Instance));
		}
	}
}