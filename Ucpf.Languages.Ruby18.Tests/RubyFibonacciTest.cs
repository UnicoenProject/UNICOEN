using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Ucpf.Common.Model;
using Ucpf.Languages.Ruby18.Model;

namespace Ucpf.Languages.Ruby18.Tests {
	public class RubyFibonacciTest {
		[Test]
		public void ParseReturn() {
			var ast = Ruby18AstGenerator.Instance.Generate("return n");
			var actual = RubyModelFactory.CreateReturn(ast);
			var expectation = new UnifiedReturn {
				Value = new UnifiedVariable("n"),
			};
			Assert.That(actual, Is.EqualTo(expectation)
				.Using(UnifiedStructuralEqualityComparer.Instance));
		}

		[Test]
		public void ParseFunctionCall() {
			var ast = Ruby18AstGenerator.Instance.Generate("fibonacci(n - 1)");
			var actual = RubyModelFactory.CreateReturn(ast);
			var expectation = new UnifiedCall {
				Function = new UnifiedVariable("fibonacci"),
				Arguments = new UnifiedArgumentCollection()
			};
			Assert.That(actual, Is.EqualTo(expectation)
				.Using(UnifiedStructuralEqualityComparer.Instance));
		}

	}
}
