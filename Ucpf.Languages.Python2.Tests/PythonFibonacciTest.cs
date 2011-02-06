using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

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
";

		}
	}
}
