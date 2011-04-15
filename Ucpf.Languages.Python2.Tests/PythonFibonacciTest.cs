using Code2Xml.Languages.Python2.XmlGenerators;
using NUnit.Framework;
using Ucpf.Core.Model;
using Ucpf.Core.Tests;
using Ucpf.Languages.Python2.Model;

namespace Ucpf.Languages.Python2.Tests {
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
				UnifiedBlock.Create(new IUnifiedExpression[] {
						UnifiedFunctionDefinition.CreateFunction(
								"fib",
								UnifiedParameterCollection.Create(
										UnifiedParameter.Create("n")
										),
								UnifiedBlock.Create(
										UnifiedIf.Create(
												UnifiedBinaryExpression.Create(UnifiedIdentifier.CreateUnknown("n"),
														UnifiedBinaryOperator.Create("<=",
																UnifiedBinaryOperatorKind.GreaterThanOrEqual),
														UnifiedIntegerLiteral.Create(1)),
												UnifiedBlock.Create(
														UnifiedSpecialExpression.CreateReturn(
																UnifiedIdentifier.CreateUnknown("n"))
														),
												UnifiedBlock.Create(
														UnifiedSpecialExpression.CreateReturn(
																UnifiedBinaryExpression.Create(
																		UnifiedCall.Create(UnifiedIdentifier.CreateUnknown("fib"),
																				UnifiedArgumentCollection.Create(
																						UnifiedArgument.Create(UnifiedBinaryExpression.Create(
																								UnifiedIdentifier.CreateUnknown("n"),
																								UnifiedBinaryOperator.Create("-",
																										UnifiedBinaryOperatorKind.Subtract),
																								UnifiedIntegerLiteral.Create(1)))
																						)
																				),
																		UnifiedBinaryOperator.Create("+",
																				UnifiedBinaryOperatorKind.Add),
																		UnifiedCall.Create(UnifiedIdentifier.CreateUnknown("fib"),
																				UnifiedArgumentCollection.Create(
																						UnifiedArgument.Create(
																								UnifiedBinaryExpression.Create(
																										UnifiedIdentifier.CreateUnknown("n"),
																										UnifiedBinaryOperator.Create("-",
																												UnifiedBinaryOperatorKind.Subtract),
																										UnifiedIntegerLiteral.Create(2)))
																						)
																				)
																		)
																)
														)
												)
										,
										UnifiedCall.Create(UnifiedIdentifier.CreateUnknown("print"),
												UnifiedArgumentCollection.Create(
														UnifiedArgument.Create(UnifiedCall.Create(
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
			var xml = Python2XmlGenerator.Instance.Generate(TestCode);
			var model = PythonModelFactory.CreateBlock(xml);
			Assert.That(model, Is.EqualTo(ExpectedModel)
					.Using(StructuralEqualityComparerForDebug.Instance));
		}
	}
}