using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Ucpf.Common.Model;
using Ucpf.Common.Model;
using Ucpf.Common.Model;
using Ucpf.Common.OldModel.Operators;
using Ucpf.Languages.Ruby18.AstGenerators;
using Ucpf.Languages.Ruby18.Model;

namespace Ucpf.Languages.Ruby18.Tests {
	[TestFixture]
	public class RubyFibonacciTest {
		[Test]
		public void ParseDefineFunction() {
			var ast = Ruby18AstGenerator.Instance.Generate(@"
def fibonacci(n)
end");
			var actual = RubyModelFactory.CreateDefineFunction(ast);
			var expectation = new UnifiedDefineFunction {
				Name = "fibonacci",
				Parameters = new UnifiedParameterCollection {
					new UnifiedParameter("n"),
				},
				Block = new UnifiedBlock(),
			};
			Assert.That(actual, Is.EqualTo(expectation)
				.Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		public void ParseReturn() {
			var ast = Ruby18AstGenerator.Instance.Generate(@"
def fibonacci(n)
	return n
end");
			var actual = RubyModelFactory.CreateDefineFunction(ast);
			var expectation = new UnifiedDefineFunction {
				Name = "fibonacci",
				Parameters = new UnifiedParameterCollection {
					new UnifiedParameter("n"),
				},
				Block = new UnifiedBlock {
					new UnifiedReturn {
						Value = new UnifiedVariable("n"),
					},
				},
			};
			Assert.That(actual, Is.EqualTo(expectation)
				.Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		public void ParseFunctionCall() {
			var ast = Ruby18AstGenerator.Instance.Generate(@"
def fibonacci(n)
	return fibonacci(n)
end");
			var actual = RubyModelFactory.CreateDefineFunction(ast);
			var expectation = new UnifiedDefineFunction {
				Name = "fibonacci",
				Parameters = new UnifiedParameterCollection {
					new UnifiedParameter("n"),
				},
				Block = new UnifiedBlock {
					new UnifiedReturn {
						Value = new UnifiedCall {
							Function = new UnifiedVariable("fibonacci"),
							Arguments = new UnifiedArgumentCollection {
								new UnifiedVariable("n"),
							},
						},
					},
				},
			};
			Assert.That(actual, Is.EqualTo(expectation)
				.Using(StructuralEqualityComparer.Instance));
		}

	}
}
