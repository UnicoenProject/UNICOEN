using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Ucpf.Common.Model;
using Ucpf.Languages.Python2.Model;

namespace Ucpf.Languages.Python2.Tests {

	[TestFixture]
	class PythonFibonacciTest {

		#region data

		private const string TestCode = @"
def fib(n):
  if n <= 1:
	return n:
  else
	return fib(n-1) + fib(n-2)

print fib(20)
";

		private static readonly UnifiedBlock ExpectedModel = new UnifiedBlock {
				new UnifiedDefineFunction {
					Name = "fib",
					Parameters = new UnifiedParameterCollection {
						new UnifiedParameter("n")
					},
					Block = new UnifiedBlock {
						new UnifiedIf {
							Condition = new UnifiedBinaryExpression {
								Operator = new UnifiedBinaryOperator("<=", BinaryOperatorType.GreaterEqual),
								LeftHandSide = new UnifiedVariable("n"),
								RightHandSide = new UnifiedIntegerLiteral(1),
							},
							TrueBlock = new UnifiedBlock {
								new UnifiedReturn {
									Value = new UnifiedVariable("n")
								}
							},
							FalseBlock = new UnifiedBlock {
								new UnifiedReturn {
									Value = new UnifiedBinaryExpression {
										Operator = new UnifiedBinaryOperator("+", BinaryOperatorType.Addition),
										LeftHandSide = new UnifiedCall {
											Function = new UnifiedVariable("fib"),
											Arguments = new UnifiedArgumentCollection {
												new UnifiedBinaryExpression {
													Operator = new UnifiedBinaryOperator("-", BinaryOperatorType.Subtraction),
													LeftHandSide = new UnifiedVariable("n"),
													RightHandSide = new UnifiedIntegerLiteral(1)
												}
											}
										},
										RightHandSide = new UnifiedCall {
											Function = new UnifiedVariable("fib"),
											Arguments = new UnifiedArgumentCollection {
												new UnifiedBinaryExpression {
													Operator = new UnifiedBinaryOperator("-", BinaryOperatorType.Subtraction),
													LeftHandSide = new UnifiedVariable("n"),
													RightHandSide = new UnifiedIntegerLiteral(2)
												}
											}
										}
									}
								}
							}
						}
					}
				},
				new UnifiedCall {
					Function = new UnifiedVariable("print"),
					Arguments = new UnifiedArgumentCollection {
						new UnifiedCall {
							Function = new UnifiedVariable("fib"),
							Arguments = new UnifiedArgumentCollection {
								new UnifiedIntegerLiteral(20)
							}
						}
					}
				}
			};

		#endregion

		[Test, Ignore]
		public void TestFibonacci() {
			var xml = Python2AstGenerator.Instance.Generate(TestCode);
			var model = PythonModelFactory.CreateBlock(xml);
			Assert.IsTrue(model.StructuralEqual(ExpectedModel));
		}
	}
}
