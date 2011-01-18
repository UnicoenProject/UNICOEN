using System.Diagnostics.Contracts;
using System.IO;
using Paraiba.Text;

namespace AntlrHelper {
	public static class LexerModifier {
		public static void Modify(string path) {
			Contract.Requires(path != null);

			string code;
			using (var reader = new StreamReader(path, XEncoding.SJIS)) {
				code = reader.ReadToEnd();
				code = ModifyFromJavaToCSharp(code);
			}
			using (var writer = new StreamWriter(path, false, XEncoding.SJIS)) {
				writer.WriteLine("using Ucpf.Languages.Common.Antlr;");
				writer.WriteLine("using System.Collections.Generic;");
				writer.Write(code);
			}
		}

		public static string ModifyFromJavaToCSharp(string code) {
			Contract.Requires(code != null);

			return code.Replace("skip();", "Skip();");
		}
	}
}