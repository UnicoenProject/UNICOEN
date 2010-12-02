using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Paraiba.Text;

namespace AntlrHelper
{
	public class Modifier
	{
		private static readonly Regex NonTerminalRegex = new Regex(@"adaptor\.AddChild\(([^,]*), (.*)\.Tree\)");
		private static readonly Regex TerminalRegex = new Regex(@"adaptor\.Create\(([^)]*)\)");

		public static void Modify(string path) {
			string code;
			using (var reader = new StreamReader(path, XEncoding.SJIS)) {
				code = reader.ReadToEnd();
				code = ModifyForNonTerminalNode(code);
				code = ModifyForTerminalNode(code);
			}
			using (var writer = new StreamWriter(path, false, XEncoding.SJIS)) {
				writer.Write(code);
			}
		}

		public static string ModifyForNonTerminalNode(string code) {
			return NonTerminalRegex.Replace(code, @"adaptor.AddChild($1, $2.Tree, $2, retval)");
		}

		public static string ModifyForTerminalNode(string code) {
			Contract.Requires<InvalidOperationException>(!new Regex(@"adaptor\.Create\(([^)]*),").IsMatch(code));
			return TerminalRegex.Replace(code, @"adaptor.Create($1, retval)");
		}
	}
}
