using NUnit.Framework;
using Ucpf.Common.Languages.Common.Antlr;
using Ucpf.Languages.Java;

namespace Ucpf.Languages.Tests.Java {
	[TestFixture]
	public class JavaAstGeneratorTest {
		[Test]
		public void ソースファイルのASTを生成できる() {
			var code =
				@"
package A;
import B.*;

class Test {
	public static void main(String[] args) {
		System.out.println();
	}
}
";
			XParserRuleReturnScope r = null;
			var ast = JavaAstGenerator.Instance.Generate(code,
				p => r = p.compilationUnit());
			Assert.That(r.Element.ToString(), Is.EqualTo(ast.ToString()));
		}

		[Test]
		public void ブロックのASTを生成できる() {
			var code = "{ int i = 0; i = i + 1; }";
			XParserRuleReturnScope r = null;
			var ast = JavaAstGenerator.Instance.Generate(code, p => r = p.block());
			Assert.That(r.Element.ToString(), Is.EqualTo(ast.ToString()));
		}

		[Test]
		public void 代入ステートメントのASTを生成できる() {
			var code = "i = 0;";
			XParserRuleReturnScope r = null;
			var ast = JavaAstGenerator.Instance.Generate(code, p => r = p.statement());
			Assert.That(r.Element.ToString(), Is.EqualTo(ast.ToString()));
		}
	}
}