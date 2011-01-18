using NUnit.Framework;

namespace AntlrHelper.Tests {
	public class LexerModifierTest {
		[Test]
		public void JavaコードをCSharpコードに変換できる() {
			const string code =
				"       skip();";
			const string expected =
				"       Skip();";
			Assert.That(LexerModifier.ModifyFromJavaToCSharp(code), Is.EqualTo(expected));
		}
	}
}