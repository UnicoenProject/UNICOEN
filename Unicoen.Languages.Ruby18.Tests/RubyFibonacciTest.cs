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

using Code2Xml.Languages.Ruby18.XmlGenerators;
using NUnit.Framework;
using Unicoen.Core.Model;
using Unicoen.Core.Tests;
using Unicoen.Languages.Ruby18.Model;

namespace Unicoen.Languages.Ruby18.Tests {
	[TestFixture]
	public class RubyFibonacciTest {
		private static UnifiedCall CreateCall(int? decrement) {
			return UnifiedCall.Create(
					UnifiedIdentifier.CreateUnknown("fibonacci"),
					UnifiedArgumentCollection.Create(
							decrement == null
									? UnifiedArgument.Create(UnifiedIdentifier.CreateUnknown("n"))
									: UnifiedArgument.Create(
											UnifiedBinaryExpression.Create(
													UnifiedIdentifier.CreateUnknown("n"),
													UnifiedBinaryOperator.Create(
															"-",
															UnifiedBinaryOperatorKind.Subtract),
													UnifiedIntegerLiteral.Create((int)decrement)))
							));
		}

		[Test]
		public void CreateDefineFunction() {
			var ast = Ruby18XmlGenerator.Instance.Generate(@"
def fibonacci(n)
end");
			var actual = RubyModelFactory.CreateDefineFunction(ast);
			var expectation =
					UnifiedFunctionDefinition.CreateFunction(
							UnifiedModifierCollection.Create(),
							null,
							"fibonacci", UnifiedParameterCollection.Create(
									UnifiedParameter.Create("n")), null, UnifiedBlock.Create());
			Assert.That(
					actual, Is.EqualTo(expectation)
					        		.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Test]
		public void CreateReturn() {
			var ast =
					Ruby18XmlGenerator.Instance.Generate(@"
def fibonacci(n)
	return n
end");
			var actual = RubyModelFactory.CreateDefineFunction(ast);
			var expectation = UnifiedFunctionDefinition.CreateFunction(
					"fibonacci",
					UnifiedParameterCollection.Create(
							UnifiedParameter.Create("n")
							),
					UnifiedBlock.Create(
							UnifiedSpecialExpression.CreateReturn(
									UnifiedIdentifier.CreateUnknown("n"))
							)
					);
			Assert.That(
					actual, Is.EqualTo(expectation)
					        		.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Test]
		public void CreateFunctionCall() {
			var ast =
					Ruby18XmlGenerator.Instance.Generate(
							@"
def fibonacci(n)
	return fibonacci(n)
end");
			var actual = RubyModelFactory.CreateDefineFunction(ast);
			var expectation = UnifiedFunctionDefinition.CreateFunction(
					"fibonacci",
					UnifiedParameterCollection.Create(
							UnifiedParameter.Create("n")
							),
					UnifiedBlock.Create(
							UnifiedSpecialExpression.CreateReturn(CreateCall(null))
							)
					);
			Assert.That(
					actual, Is.EqualTo(expectation)
					        		.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Test]
		public void CreateFunctionCall2() {
			var ast =
					Ruby18XmlGenerator.Instance.Generate(
							@"
def fibonacci(n)
	return fibonacci(n - 1) + fibonacci(n - 2)
end");
			var actual = RubyModelFactory.CreateDefineFunction(ast);
			var expectation = UnifiedFunctionDefinition.CreateFunction(
					"fibonacci",
					UnifiedParameterCollection.Create(
							UnifiedParameter.Create("n")
							),
					UnifiedBlock.Create(
							UnifiedSpecialExpression.CreateReturn(
									UnifiedBinaryExpression.Create(
											CreateCall(1),
											UnifiedBinaryOperator.Create("+", UnifiedBinaryOperatorKind.Add),
											CreateCall(2))
									)
							)
					);
			Assert.That(
					actual, Is.EqualTo(expectation)
					        		.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Test]
		public void CreateIf() {
			var ast =
					Ruby18XmlGenerator.Instance.Generate(
							@"
def fibonacci(n)
	if (n < 2)
		return n
	else
		return 0
	end
end
");
			var actual = RubyModelFactory.CreateDefineFunction(ast);
			var expectation = UnifiedFunctionDefinition.CreateFunction(
					"fibonacci",
					UnifiedParameterCollection.Create(
							UnifiedParameter.Create("n")
							),
					UnifiedBlock.Create(
							UnifiedIf.Create(
									UnifiedBinaryExpression.Create(
											UnifiedIdentifier.CreateUnknown("n"),
											UnifiedBinaryOperator.Create("<", UnifiedBinaryOperatorKind.LessThan),
											UnifiedIntegerLiteral.Create(2)),
									UnifiedBlock.Create(
											UnifiedSpecialExpression.CreateReturn(
													UnifiedIdentifier.CreateUnknown("n"))
											),
									UnifiedBlock.Create(
											UnifiedSpecialExpression.CreateReturn(
													UnifiedIntegerLiteral.Create(0))
											)
									)
							)
					);
			Assert.That(
					actual, Is.EqualTo(expectation)
					        		.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Test]
		public void CreateFibonacci() {
			var ast =
					Ruby18XmlGenerator.Instance.Generate(
							@"
def fibonacci(n)
	if (n < 2)
		return n
	else
		return fibonacci(n - 1) + fibonacci(n - 2)
	end
end
");
			var actual = RubyModelFactory.CreateDefineFunction(ast);
			var expectation = UnifiedFunctionDefinition.CreateFunction(
					"fibonacci",
					UnifiedParameterCollection.Create(
							UnifiedParameter.Create("n")
							),
					UnifiedBlock.Create(
							UnifiedIf.Create(
									UnifiedBinaryExpression.Create(
											UnifiedIdentifier.CreateUnknown("n"),
											UnifiedBinaryOperator.Create("<", UnifiedBinaryOperatorKind.LessThan),
											UnifiedIntegerLiteral.Create(2)),
									UnifiedBlock.Create(
											UnifiedSpecialExpression.CreateReturn(
													UnifiedIdentifier.CreateUnknown("n"))
											),
									UnifiedBlock.Create(
											UnifiedSpecialExpression.CreateReturn(
													UnifiedBinaryExpression.Create(
															CreateCall(1),
															UnifiedBinaryOperator.Create("+", UnifiedBinaryOperatorKind.Add),
															CreateCall(2))
													)
											)
									)
							)
					);
			Assert.That(
					actual, Is.EqualTo(expectation)
					        		.Using(StructuralEqualityComparerForDebug.Instance));
		}
	}
}