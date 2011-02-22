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
						                   	BinaryOperatorType.Subtraction),
							RightHandSide = new UnifiedIntegerLiteral((int)decrement),
						}
				},
			};
		}

		[Test]
		public void CreateDefineFunction() {
			var ast =
				JavaAstGenerator.Instance.Generate("public static int fibonacci(int n){}", p => p.methodDeclaration());
			var actual = JavaModelFactory.CreateDefineFunction(ast);
			var modifiers = new List<String>();
			modifiers.Add("public");
			modifiers.Add("static");
			var expectation = new UnifiedFunctionDefinition {
				Modifiers = modifiers,
				ReturnType = "int",
				Name = "fibonacci",
				Parameters = new UnifiedParameterCollection(),
				Block = new UnifiedBlock(),

			};
			Assert.That(actual, Is.EqualTo(expectation).Using(StructuralEqualityComparer.Instance));
		}
	}
}
