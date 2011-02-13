using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Ucpf.Languages.Python2.Model;

namespace Ucpf.Languages.Python2.Tests {

	[TestFixture]
	public class PythonLiteralTest {

		[Test, Ignore]
		[TestCase("'1'", "1")]
		[TestCase("\"1\"", "1")]
		public void ParseStringLiteral(string code, string expectation) {
			var ast = Python2AstGenerator.Instance.Generate(code);
			var lit = PythonModelFactory.CreateStringLiteral(ast);
			Assert.That(lit.Value, Is.EqualTo(expectation));
		}

	}
}
