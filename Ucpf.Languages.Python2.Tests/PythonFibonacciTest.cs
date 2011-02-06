using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Ucpf.Common.Model;

namespace Ucpf.Languages.Python2.Tests {

	[TestFixture]
	class PythonFibonacciTest {

		[Test]
		void TestFibonacci() {
			var code = @"
def fib(n):
  if n <= 1:
    return n:
  else
    return fib(n-1) + fib(n-2)

print fib(20)
";
			var expected = new UnifiedBlock {
				new UnifiedFunction {
					Name = "fib",
					Parameters = new UnifiedParameterCollection {
						new UnifiedParameter{ Name = "n" }
					},
					Block = new UnifiedBlock()
				}
			};
		}
	}
}
