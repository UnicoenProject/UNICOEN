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

using System.IO;
using NUnit.Framework;
using Unicoen.Core.Model;
using Unicoen.Core.Tests;

namespace Unicoen.Languages.CSharp.Tests {
	[Ignore, TestFixture]
	public class CSharpFibonacciTest {
		#region data

		private static readonly string Code =
				File.ReadAllText(Fixture.GetInputPath("CSharp", "Fibonacci.cs"));

		public static readonly UnifiedProgram Model = UnifiedProgram.Create(
				UnifiedClassDefinition.CreateClass(
						"Fibonacci",
						UnifiedBlock.Create(
								new IUnifiedExpression[] {
										UnifiedFunctionDefinition.CreateFunction(
												UnifiedModifierCollection.Create(
														UnifiedModifier.Create("public"),
														UnifiedModifier.Create("static")
														),
												UnifiedType.CreateUsingString("int"),
												"fibonacci", UnifiedParameterCollection.Create(
														UnifiedParameter.Create("n", UnifiedType.CreateUsingString("int"))
												             		), UnifiedBlock.Create(
												             				UnifiedIf.Create(
												             						UnifiedBinaryExpression.Create(
												             								UnifiedIdentifier.CreateUnknown("n"),
												             								UnifiedBinaryOperator.Create(
												             										"<",
												             										UnifiedBinaryOperatorKind.LessThan),
												             								UnifiedIntegerLiteral.Create(2)),
												             						UnifiedBlock.Create(
												             								new[] {
												             										UnifiedSpecialExpression.CreateReturn(
												             												UnifiedIdentifier.CreateUnknown("n")),
												             								}),
												             						UnifiedBlock.Create(
												             								UnifiedSpecialExpression.CreateReturn(
												             										UnifiedBinaryExpression.Create(
												             												UnifiedCall.Create(
												             														UnifiedIdentifier.CreateUnknown(
												             																"fibonacci"),
												             														UnifiedArgumentCollection.Create(
												             																UnifiedArgument.Create(
												             																		UnifiedBinaryExpression.Create(
												             																				UnifiedIdentifier.CreateUnknown(
												             																						"n"),
												             																				UnifiedBinaryOperator.Create(
												             																						"-",
												             																						UnifiedBinaryOperatorKind.
												             																								Subtract),
												             																				UnifiedIntegerLiteral.Create(1)
												             																				)))
												             														),
												             												UnifiedBinaryOperator.Create(
												             														"+",
												             														UnifiedBinaryOperatorKind.Add),
												             												UnifiedCall.Create(
												             														UnifiedIdentifier.CreateUnknown(
												             																"fibonacci"),
												             														UnifiedArgumentCollection.Create(
												             																UnifiedArgument.Create(
												             																		UnifiedBinaryExpression.Create(
												             																				UnifiedIdentifier.CreateUnknown(
												             																						"n"),
												             																				UnifiedBinaryOperator.Create(
												             																						"-",
												             																						UnifiedBinaryOperatorKind.
												             																								Subtract),
												             																				UnifiedIntegerLiteral.Create(2)))
												             																)
												             														)
												             												)
												             										)
												             								)
												             						)
												             		   		))
								}
								)
						)
				);

		#endregion

		[Test]
		public void CreateFibonacci() {
			var actual = CSharpModelFactory.CreateModel(Code);
			var expected = Model;
			Assert.That(
					actual,
					Is.EqualTo(expected).Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Test]
		public void CreateClassDeclare() {
			const string code = "class Fibonacci{}";
			var expected = UnifiedProgram.Create(
					new[] { UnifiedClassDefinition.CreateClass("Fibonacci") });
			var actual = CSharpModelFactory.CreateModel(code);
			Assert.That(
					actual,
					Is.EqualTo(expected).Using(StructuralEqualityComparerForDebug.Instance));
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
			var expected = UnifiedProgram.Create(
					new[] {
							UnifiedClassDefinition.CreateClass(
									"Fibonacci",
									UnifiedBlock.Create(
											new IUnifiedExpression[] {
													UnifiedFunctionDefinition.CreateFunction(
															UnifiedModifierCollection.Create(
																	UnifiedModifier.Create("public"),
																	UnifiedModifier.Create("static")
																	),
															UnifiedType.CreateUsingString("void"), "fibonacci",
															UnifiedParameterCollection.Create(
																	UnifiedParameter.Create(
																			"n",
																			UnifiedType.CreateUsingString("int"))
																	))
											})
							)
					});
			var actual = CSharpModelFactory.CreateModel(code);
			Assert.That(
					actual,
					Is.EqualTo(expected).Using(StructuralEqualityComparerForDebug.Instance));
		}
	}
}