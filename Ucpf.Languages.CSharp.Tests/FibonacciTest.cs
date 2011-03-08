using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Ucpf.Core.Model;




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
		private static readonly UnifiedProgram Model = new UnifiedProgram(new[]{ new UnifiedClassDefinition {
			Name = "Klass",
			Body = new UnifiedBlock {
					new UnifiedFunctionDefinition {
						Name = "Fibonacci",
						Type = new UnifiedType { Name = "int"},
						Modifiers = {
							new UnifiedModifier {
								Name = "public"
							},
							new UnifiedModifier {
								Name = "static"
							}
						},
						Parameters ={
							new UnifiedParameter { Type = new UnifiedType { Name = "int"}, Name = "n" }
						},
						Body = {
							new UnifiedIf {
								Condition = new UnifiedBinaryExpression {
									Operator =
										new UnifiedBinaryOperator("<=", UnifiedBinaryOperatorType.LesserEqual),
									LeftHandSide = UnifiedVariable.Create("n"),
									RightHandSide = UnifiedIntegerLiteral.Create(1)
								},
								TrueBlock = {
									new UnifiedReturn {
										Value = UnifiedVariable.Create("n")
									}
								},
								FalseBlock = {
									new UnifiedReturn {
										Value = new UnifiedBinaryExpression {
											Operator = new UnifiedBinaryOperator("+", UnifiedBinaryOperatorType.Addition),
											LeftHandSide = new UnifiedCall {
												Function = UnifiedVariable.Create("Fibonacci"),
												Arguments = {
													new UnifiedArgument{ Value = new UnifiedBinaryExpression {
														Operator = new UnifiedBinaryOperator("-", UnifiedBinaryOperatorType.Subtraction),
														LeftHandSide = UnifiedVariable.Create("n"),
														RightHandSide = UnifiedIntegerLiteral.Create(1)
													}}
												}
											},
											RightHandSide = new UnifiedCall {
												Function = UnifiedVariable.Create("Fibonacci"),
												Arguments = {
													UnifiedArgument.Create(new UnifiedBinaryExpression {
														Operator = new UnifiedBinaryOperator("-", UnifiedBinaryOperatorType.Subtraction),
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
		}});

		#endregion

		[Test]
		public void Test() {
			var actual = CSharpModelFactory.CreateModel(Code);
			var expected = Model;
			Assert.That(actual,
				Is.EqualTo(expected).Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		public void GenerateFibonacciCode() {
			var firstModel = CSharpModelFactory.CreateModel(Code);
			Assert.That(firstModel,
				Is.EqualTo(Model).Using(StructuralEqualityComparer.Instance));
			var firstCode = CSharpCodeGenerator.Generate(firstModel);
			var secondModel = CSharpModelFactory.CreateModel(firstCode);
			Assert.That(secondModel,
				Is.EqualTo(firstModel).Using(StructuralEqualityComparer.Instance));
			var secondCode = CSharpCodeGenerator.Generate(secondModel);
			Assert.AreEqual(firstCode, secondCode);
		}

		[Test]
		public void FibonacciAnother() {
			const string code = @"
class Klass {
	int Fib(int n) {
		if (n <= 1) { hoge(); return n; }
		else { return fib(n-1) + fib(n-2); }
	}
}
";
			var firstModel = CSharpModelFactory.CreateModel(code);
			var generatedCode = CSharpCodeGenerator.Generate(firstModel);
			var secondModel = CSharpModelFactory.CreateModel(generatedCode);
			Assert.That(secondModel,
				Is.EqualTo(firstModel).Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		public void ClassDeclareTest() {
			const string code = "class Klass{}";
			var expected = new UnifiedProgram(new[]{new UnifiedClassDefinition {
				Name = "Klass",
			}});
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
			var expected = new UnifiedProgram(new[]{new UnifiedClassDefinition {
				Name = "Klass",
				Body = new UnifiedBlock {
					new UnifiedFunctionDefinition {
						Name = "Fibonacci",
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