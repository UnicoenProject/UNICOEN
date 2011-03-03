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
				Function = UnifiedVariable.Create("fibonacci"),
				Arguments = {
					decrement == null
						? UnifiedArgument.Create(UnifiedVariable.Create("n"))
						: UnifiedArgument.Create(new UnifiedBinaryExpression {
							LeftHandSide = UnifiedVariable.Create("n"),
							Operator =
						                   	new UnifiedBinaryOperator("-",
						                   	UnifiedBinaryOperatorType.Subtraction),
							RightHandSide = UnifiedIntegerLiteral.Create((int)decrement),
						})
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
				Modifiers = {
					new UnifiedModifier() {
						Name = "public"
					},
					new UnifiedModifier() {
						Name = "static"
					}
				},
				Type = new UnifiedType { Name = "int" },
				Name = "fibonacci",
				Parameters = {
					new UnifiedParameter() {
						Modifier = new UnifiedModifier(),
						Name = "n",
						Type = new UnifiedType { Name = "int"},
					}
				},
				Block = new UnifiedBlock(),
			};
			Assert.That(actual,
				Is.EqualTo(expectation).Using(StructuralEqualityComparer.Instance));
		}
	}
}