using Code2Xml.Languages.Python2.XmlGenerators;
using NUnit.Framework;
using Ucpf.Languages.Python2.Model;

namespace Ucpf.Languages.Python2.Tests {
	[TestFixture]
	public class PythonLiteralTest {
		[Test]
		[TestCase("'1'", "1")]
		[TestCase("\"1\"", "1")]
		public void ParseStringLiteral(string code, string expectation) {
			var ast = Python2XmlGenerator.Instance.Generate(code);
			var lit = PythonModelFactory.CreateStringLiteral(ast);
			Assert.That(lit.Value, Is.EqualTo(expectation));
		}
	}
}