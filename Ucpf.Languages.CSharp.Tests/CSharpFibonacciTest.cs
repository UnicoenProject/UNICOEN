using System.IO;
using NUnit.Framework;
using Ucpf.Core.Model;
using Ucpf.Core.Tests;

namespace Ucpf.Languages.CSharp.Tests
{
	[Ignore, TestFixture]
	public class CSharpFibonacciTest
	{
		#region data

		private static readonly string Code =
			File.ReadAllText(Fixture.GetInputPath("CSharp", "Fibonacci.cs"));

		public static readonly UnifiedProgram Model = UnifiedProgram.Create(
			UnifiedClassDefinition.CreateClass(
				"Fibonacci",
				UnifiedBlock.Create(new IUnifiedExpression[] {
					UnifiedFunctionDefinition.CreateFunction(
						"fibonacci",
						UnifiedType.Create("int"),
						UnifiedModifierCollection.Create(
							UnifiedModifier.Create("public"),
							UnifiedModifier.Create("static")
							),
						UnifiedParameterCollection.Create(
							UnifiedParameter.Create("n", UnifiedType.Create("int"))
							),
						UnifiedBlock.Create(
							UnifiedIf.Create(
								UnifiedBinaryExpression.Create(UnifiedIdentifier.CreateUnknown("n"),
									UnifiedBinaryOperator.Create("<",
										UnifiedBinaryOperatorKind.LessThan),
									UnifiedIntegerLiteral.Create(2)),
								UnifiedBlock.Create(new[] {
									UnifiedSpecialExpression.CreateReturn(UnifiedIdentifier.CreateUnknown("n")),
								}),
								UnifiedBlock.Create(
									UnifiedSpecialExpression.CreateReturn(
										UnifiedBinaryExpression.Create(
											UnifiedCall.Create(UnifiedIdentifier.CreateUnknown("fibonacci"),
												UnifiedArgumentCollection.Create(
													UnifiedArgument.Create(UnifiedBinaryExpression.Create(
														UnifiedIdentifier.CreateUnknown("n"),
														UnifiedBinaryOperator.Create("-",
															UnifiedBinaryOperatorKind.Subtract),
														UnifiedIntegerLiteral.Create(1)
														)))
												),
											UnifiedBinaryOperator.Create("+",
												UnifiedBinaryOperatorKind.Add),
											UnifiedCall.Create(UnifiedIdentifier.CreateUnknown("fibonacci"),
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
							)
						)
				}
					)
				)
			);

		#endregion

		[Test]
		public void CreateFibonacci()
		{
			var actual = CSharpModelFactory.CreateModel(Code);
			var expected = Model;
			Assert.That(actual,
				Is.EqualTo(expected).Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Test]
		public void CreateClassDeclare()
		{
			const string code = "class Fibonacci{}";
			var expected = UnifiedProgram.Create(
				new[] { UnifiedClassDefinition.CreateClass("Fibonacci") });
			var actual = CSharpModelFactory.CreateModel(code);
			Assert.That(actual,
				Is.EqualTo(expected).Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Test]
		public void CreateFuncDec()
		{
			const string code =
				@"
class Fibonacci {
	public static void fibonacci(int n) {
	}
}
";
			var expected = UnifiedProgram.Create(new[] {
				UnifiedClassDefinition.CreateClass(
					"Fibonacci",
					UnifiedBlock.Create(new IUnifiedExpression[] {
						UnifiedFunctionDefinition.CreateFunction(
							"fibonacci",
							UnifiedType.Create("void"),
							UnifiedModifierCollection.Create(
								UnifiedModifier.Create("public"),
								UnifiedModifier.Create("static")
								),
							UnifiedParameterCollection.Create(
								UnifiedParameter.Create(
									"n",
									UnifiedType.Create("int"))
								)
							)
					})
					)
			});
			var actual = CSharpModelFactory.CreateModel(code);
			Assert.That(actual,
				Is.EqualTo(expected).Using(StructuralEqualityComparerForDebug.Instance));
		}
	}
}