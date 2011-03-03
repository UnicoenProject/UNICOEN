using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Ucpf.Common.Model;

namespace Ucpf.Languages.CSharp.Tests {

	[TestFixture]
	public class FibonacciTest {

		#region data

		const string Code = @"
class Klass {
	public static int Fibonacci(int n) {
		if (n <= 1)
			return n;
		else
			return Fibonacci(n-1) + Fibonacci(n-2);
	}
}
";
		private static UnifiedClassDefinition Model = new UnifiedClassDefinition {
			Name = "Klass",
			Body = new UnifiedBlock {
					new UnifiedFunctionDefinition {
						Name = "Fibonacci",
						Type = new UnifiedType { Name = "int"},
						Modifiers = new UnifiedModifierCollection {
							new UnifiedModifier {
								Name = "public"
							},
							new UnifiedModifier {
								Name = "static"
							}
						},
						Parameters = new UnifiedParameterCollection {
							new UnifiedParameter { Type = new UnifiedType { Name = "int"}, Name = "n" }
						},
						Block = new UnifiedBlock {
							new UnifiedIf {
								Condition = new UnifiedBinaryExpression {
									Operator =
										new UnifiedBinaryOperator("<=", UnifiedBinaryOperatorType.LesserEqual),
									LeftHandSide = UnifiedVariable.Create("n"),
									RightHandSide = new UnifiedIntegerLiteral(1)
								},
								TrueBlock = new UnifiedBlock {
									new UnifiedReturn{
										Value = UnifiedVariable.Create("n")
									}
								},
								FalseBlock = new UnifiedBlock {
									new UnifiedReturn {
										Value =  new UnifiedBinaryExpression {
											Operator = new UnifiedBinaryOperator("+", UnifiedBinaryOperatorType.Addition),
											LeftHandSide = new UnifiedCall {
												Function = UnifiedVariable.Create("Fibonacci"),
												Arguments = new UnifiedArgumentCollection {
													new UnifiedArgument{ Value = new UnifiedBinaryExpression {
														Operator = new UnifiedBinaryOperator("-", UnifiedBinaryOperatorType.Subtraction),
														LeftHandSide = UnifiedVariable.Create("n"),
														RightHandSide = new UnifiedIntegerLiteral(1)
													}}
												}
											},
											RightHandSide = new UnifiedCall {
												Function = UnifiedVariable.Create("Fibonacci"),
												Arguments = new UnifiedArgumentCollection {
													new UnifiedArgument{ Value = new UnifiedBinaryExpression {
														Operator = new UnifiedBinaryOperator("-", UnifiedBinaryOperatorType.Subtraction),
														LeftHandSide = UnifiedVariable.Create("n"),
														RightHandSide = new UnifiedIntegerLiteral(2)
													}}
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
		public void Test() {
			var actual = CSharpModelFactory.CreateModel(Code);
			var expected = Model;
			Assert.That(actual,
				Is.EqualTo(expected).Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		public void ClassDeclareTest() {
			const string code = "class Klass{}";
			var expected = new UnifiedClassDefinition { Name = "Klass", Body = new UnifiedBlock() };
			var actual = CSharpModelFactory.CreateModel(code);
			Assert.That(actual,
				Is.EqualTo(expected).Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		public void FuncDecTest() {
			const string code =
				@"
class Klass {
	public static void Fibonacci(int n) {
	}
}
";
			var expected = new UnifiedClassDefinition {
				Name = "Klass",
				Body = new UnifiedBlock {
					new UnifiedFunctionDefinition {
						Name = "Fibonacci",
						Type = new UnifiedType { Name = "void"},
						Modifiers = new UnifiedModifierCollection() {
							new UnifiedModifier {
								Name = "public"
							},
							new UnifiedModifier {
								Name = "static"
							}
						},
						Parameters = new UnifiedParameterCollection {
							new UnifiedParameter { Type = new UnifiedType { Name = "int"}, Name = "n" }
						},
						Block = new UnifiedBlock()
					}
				}
			};
			var actual = CSharpModelFactory.CreateModel(code);
			Assert.That(actual,
				Is.EqualTo(expected).Using(StructuralEqualityComparer.Instance));
		}
	}
}