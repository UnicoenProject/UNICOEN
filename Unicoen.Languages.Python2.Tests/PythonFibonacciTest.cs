#region License

// Copyright (C) 2011 The Unicoen Project
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using Code2Xml.Languages.Python2.CodeToXmls;
using NUnit.Framework;
using Unicoen.Core.Model;
using Unicoen.Core.Tests;
using Unicoen.Languages.Python2.ModelFactories;

namespace Unicoen.Languages.Python2.Tests {
	[TestFixture]
	internal class PythonFibonacciTest {
		#region data

		private const string TestCode =
				@"
def fib(n):
  if n <= 1:
	return n
  else:
	return fib(n-1) + fib(n-2)
print fib(20)
";

		private static readonly UnifiedBlock ExpectedModel =
				UnifiedBlock.Create(
						new IUnifiedExpression[] {
								UnifiedFunctionDefinition.CreateFunction(
										"fib",
										UnifiedParameterCollection.Create(
												UnifiedParameter.Create("n")
												),
										UnifiedBlock.Create(
												UnifiedIf.Create(
														UnifiedBinaryExpression.Create(
																UnifiedIdentifier.CreateUnknown("n"),
																UnifiedBinaryOperator.Create(
																		"<=",
																		UnifiedBinaryOperatorKind.GreaterThanOrEqual),
																UnifiedIntegerLiteral.Create(1)),
														UnifiedBlock.Create(
																UnifiedSpecialExpression.CreateReturn(
																		UnifiedIdentifier.CreateUnknown("n"))
																),
														UnifiedBlock.Create(
																UnifiedSpecialExpression.CreateReturn(
																		UnifiedBinaryExpression.Create(
																				UnifiedCall.Create(
																						UnifiedIdentifier.CreateUnknown("fib"),
																						UnifiedArgumentCollection.Create(
																								UnifiedArgument.Create(
																										UnifiedBinaryExpression.Create(
																												UnifiedIdentifier.CreateUnknown("n"),
																												UnifiedBinaryOperator.Create(
																														"-",
																														UnifiedBinaryOperatorKind.Subtract),
																												UnifiedIntegerLiteral.Create(1)))
																								)
																						),
																				UnifiedBinaryOperator.Create(
																						"+",
																						UnifiedBinaryOperatorKind.Add),
																				UnifiedCall.Create(
																						UnifiedIdentifier.CreateUnknown("fib"),
																						UnifiedArgumentCollection.Create(
																								UnifiedArgument.Create(
																										UnifiedBinaryExpression.Create(
																												UnifiedIdentifier.CreateUnknown("n"),
																												UnifiedBinaryOperator.Create(
																														"-",
																														UnifiedBinaryOperatorKind.Subtract),
																												UnifiedIntegerLiteral.Create(2)))
																								)
																						)
																				)
																		)
																)
														)
												,
												UnifiedCall.Create(
														UnifiedIdentifier.CreateUnknown("print"),
														UnifiedArgumentCollection.Create(
																UnifiedArgument.Create(
																		UnifiedCall.Create(
																				UnifiedIdentifier.CreateUnknown("fib"),
																				UnifiedArgumentCollection.Create(
																						UnifiedArgument.Create(UnifiedIntegerLiteral.Create(20))
																						))
																		)
																)
														)
												)
								)
						}
						);

		#endregion

		[Test, Ignore]
		public void TestFibonacci() {
			var xml = Python2CodeToXml.Instance.Generate(TestCode);
			var model = Python2ModelFactory.CreateBlock(xml);
			Assert.That(
					model, Is.EqualTo(ExpectedModel)
					       		.Using(StructuralEqualityComparerForDebug.Instance));
		}
	}
}