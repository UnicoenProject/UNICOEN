using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Ucpf.Common.Model;
using Ucpf.Common.Model.Expressions;
using Ucpf.Common.OldModel.Operators;

namespace Ucpf.Languages.CSharp.Tests {

	[TestFixture]
	public class FibonacciTest {

		public void Test() {
			var code = @"
class Klass {
	public static int Fibonacci(int n) {
		if (n <= 1)
			return n;
		else
			return Fibonacci(n-1) + Fibonacci(n-2);
	}
}
";
			var model = new UnifiedClassDefinition {
				Name = "Klass",
				Body = new UnifiedBlock {
					new UnifiedFunctionDefinition {
						Name = "Fibonacci",
						ReturnType = "int",
						Modifiers = new[] { "public", "static" },
						Parameters = new UnifiedParameterCollection {
							new UnifiedParameter { Type = "int", Name = "n" }
						},
						Block = new UnifiedBlock {
							new UnifiedIf {
								Condition = new UnifiedBinaryExpression {
									Operator =
										new UnifiedBinaryOperator("<=", BinaryOperatorType.LesserEqual),
									LeftHandSide = new UnifiedVariable("n"),
									RightHandSide = new UnifiedIntegerLiteral(1)
								},
								TrueBlock = new UnifiedBlock {
									new UnifiedReturn{
										Value = new UnifiedVariable("n")
									}
								},
								FalseBlock = new UnifiedBlock {
									new UnifiedReturn {
										Value =  new UnifiedBinaryExpression {
										Operator = new UnifiedBinaryOperator("+", BinaryOperatorType.Addition),
										LeftHandSide = new UnifiedCall {
											Function = new UnifiedVariable("Fibonacci"),
											Arguments = new UnifiedArgumentCollection {
												new UnifiedArgument{ Value = new UnifiedBinaryExpression {
													Operator = new UnifiedBinaryOperator("-", BinaryOperatorType.Subtraction),
													LeftHandSide = new UnifiedVariable("n"),
													RightHandSide = new UnifiedIntegerLiteral(1)
												}}
											}
										},
										RightHandSide = new UnifiedCall {
											Function = new UnifiedVariable("Fibonacci"),
											Arguments = new UnifiedArgumentCollection {
												new UnifiedArgument{ Value = new UnifiedBinaryExpression {
													Operator = new UnifiedBinaryOperator("-", BinaryOperatorType.Subtraction),
													LeftHandSide = new UnifiedVariable("n"),
													RightHandSide = new UnifiedIntegerLiteral(2)
												}}
											}
										}
									}
									}
								}
							}.ToStatement()
						}
        			}.ToStatement()
        		}
			};
		}


	}
}