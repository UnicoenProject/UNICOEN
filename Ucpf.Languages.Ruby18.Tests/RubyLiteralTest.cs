using System.Numerics;
using NUnit.Framework;
using Ucpf.Common.Model;
using Ucpf.Languages.Ruby18.Model;

namespace Ucpf.Languages.Ruby18.Tests {
	[TestFixture]
	public class RubyParseLiteralTest {
		[Test]
		[TestCase("true", UnifiedBoolean.True)]
		[TestCase("false", UnifiedBoolean.False)]
		public void ParseBooleanLiteral(string code, UnifiedBoolean expectation) {
			var ast = Ruby18AstGenerator.Instance.Generate(code);
			var lit = RubyModelFactory.CreateBooleanLiteral(ast);
			Assert.That(lit.TypedValue, Is.EqualTo(expectation));
		}

		[Test]
		[TestCase("1.1", 1.1)]
		public void ParseDecimalLiteral(string code, double expectation) {
			var ast = Ruby18AstGenerator.Instance.Generate(code);
			var lit = RubyModelFactory.CreateDecimalLiteral(ast);
			Assert.That(lit.TypedValue, Is.EqualTo((decimal)expectation));
		}

		[Test]
		[TestCase("1", 1)]
		public void ParseIntegerLiteral(string code, int expectation) {
			var ast = Ruby18AstGenerator.Instance.Generate(code);
			var lit = RubyModelFactory.CreateIntegerLiteral(ast);
			Assert.That(lit.TypedValue, Is.EqualTo((BigInteger)expectation));
		}

		[Test]
		[TestCase("'1'", "1")]
		[TestCase("\"1\"", "1")]
		//TODO: [TestCase("\"#{1}\"", "1")]
		//TODO: [TestCase("\"#{a}\"", "a")]
		public void ParseStringLiteral(string code, string expectation) {
			var ast = Ruby18AstGenerator.Instance.Generate(code);
			var lit = RubyModelFactory.CreateStringLiteral(ast);
			Assert.That(lit.Value, Is.EqualTo(expectation));
		}
	}
}