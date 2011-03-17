using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Code2Xml.Languages.Python2.XmlGenerators;
using NUnit.Framework;
using Ucpf.Core.Model;



using Ucpf.Languages.Python2.Model;

namespace Ucpf.Languages.Python2.Tests {

	[TestFixture]
	class PythonFibonacciTest {

		#region data

		private const string TestCode = @"
def fib(n):
  if n <= 1:
	return n
  else:
	return fib(n-1) + fib(n-2)
print fib(20)
";

		private static readonly UnifiedBlock ExpectedModel =
			new UnifiedBlock {
				new UnifiedFunctionDefinition {
					Name = "fib",
					Parameters = {
						new UnifiedParameter{ Name = "n" }
					},
					Body = {
						new UnifiedIf {
							Condition = new UnifiedBinaryExpression {
								Operator = new UnifiedBinaryOperator("<=", UnifiedBinaryOperatorType.GreaterEqual),
								LeftHandSide = UnifiedVariable.Create("n"),
								RightHandSide = UnifiedIntegerLiteral.Create(1),
							},
							TrueBlock = {
								new UnifiedReturn {
									Value = UnifiedVariable.Create("n")
								}
							},
							FalseBlock = {
								new UnifiedReturn {
									Value	= new UnifiedBinaryExpression {
										Operator = new UnifiedBinaryOperator("+", UnifiedBinaryOperatorType.Add),
										LeftHandSide = new UnifiedCall {
											Function = UnifiedVariable.Create("fib"),
											Arguments = {
												UnifiedArgument.Create(new UnifiedBinaryExpression {
													Operator = new UnifiedBinaryOperator("-", UnifiedBinaryOperatorType.Subtract),
													LeftHandSide = UnifiedVariable.Create("n"),
													RightHandSide = UnifiedIntegerLiteral.Create(1)
												})
											}
										},
										RightHandSide = new UnifiedCall {
											Function = UnifiedVariable.Create("fib"),
											Arguments = {
												UnifiedArgument.Create(new UnifiedBinaryExpression {
													Operator = new UnifiedBinaryOperator("-", UnifiedBinaryOperatorType.Subtract),
													LeftHandSide = UnifiedVariable.Create("n"),
													RightHandSide = UnifiedIntegerLiteral.Create(2)
												}),
											}
										}
									}
								}
							}
						}
					}
				},
				new UnifiedCall {
					Function = UnifiedVariable.Create("print"),
					Arguments = {
						UnifiedArgument.Create(new UnifiedCall {
							Function = UnifiedVariable.Create("fib"),
							Arguments = {
								UnifiedArgument.Create(UnifiedIntegerLiteral.Create(20)),
							}
						}),
					}
				}
			};

		#endregion

		[Test, Ignore]
		public void TestFibonacci() {
			var xml = Python2XmlGenerator.Instance.Generate(TestCode);
			var model = PythonModelFactory.CreateBlock(xml);
			Assert.That(model, Is.EqualTo(ExpectedModel)
				.Using(StructuralEqualityComparer.Instance));
		}
	}
}
