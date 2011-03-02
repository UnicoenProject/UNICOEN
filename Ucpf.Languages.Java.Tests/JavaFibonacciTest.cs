using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Ucpf.Common.Model;
using Ucpf.Common.OldModel.Operators;
using Ucpf.Common.Tests;
using Ucpf.Languages.Java.AstGenerators;
using Ucpf.Languages.Java.CodeModel;
using Ucpf.Languages.Java.Model;

namespace Ucpf.Languages.Java.Tests {
	[TestFixture]
	public class JavaFibonacciTest {
		private static UnifiedCall CreateCall(int? decrement) {
			return new UnifiedCall {
				Function = new UnifiedVariable("fibonacci"),
				Arguments = new UnifiedArgumentCollection {
					decrement == null
						? (UnifiedArgument)new UnifiedVariable("n")
						: (UnifiedArgument)new UnifiedBinaryExpression {
							LeftHandSide = new UnifiedVariable("n"),
							Operator =
						                   	new UnifiedBinaryOperator("-",
						                   	UnifiedBinaryOperatorType.Subtraction),
							RightHandSide = new UnifiedIntegerLiteral((int)decrement),
						}
				},
			};
		}

		[Test]
		public void CreateDefineFunction() {
			var ast =
				JavaAstGenerator.Instance.Generate("public static int fibonacci(int n){}",
					p => p.methodDeclaration());
			var actual = JavaModelFactory.CreateDefineFunction(ast);
			var expectation = new UnifiedFunctionDefinition {
				Modifiers = new UnifiedModifierCollection() {
					new UnifiedModifier() {
						Name = "public"
					},
					new UnifiedModifier() {
						Name = "static"
					}
				},
				ReturnType = "int",
				Name = "fibonacci",
				Parameters = new UnifiedParameterCollection() {
					new UnifiedParameter() {
						Modifier = new UnifiedModifier(),
						Name = "n",
						Type = "int"
					}
				},
				Block = new UnifiedBlock(),
			};
			Assert.That(actual,
				Is.EqualTo(expectation).Using(StructuralEqualityComparer.Instance));
		}
	}
}