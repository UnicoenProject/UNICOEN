using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Paraiba.Text;

namespace AntlrHelper
{
	public static class LexerModifier {

		public static void Modify(string path) {
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
			return code.Replace("skip();", "Skip();");
		}
	}
}
