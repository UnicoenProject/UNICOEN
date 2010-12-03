﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Paraiba.Text;

namespace AntlrHelper
{
	public static class ParserModifier
	{
		private static readonly Regex SystemOutRegex = new Regex(@"System\.out\.println[^;]+;");
		private static readonly Regex NonTerminalRegex = new Regex(@"adaptor\.AddChild\(([^,]*), (.*)\.Tree\)");
		private static readonly Regex TerminalRegex = new Regex(@"adaptor\.Create\(([^),]*)\)");
		private static readonly Regex MatchRegex = new Regex(@"Match\(input,([^\d][^,]*),[^)]*\)");

		public static void Modify(string path) {
			string code;
			using (var reader = new StreamReader(path, XEncoding.SJIS)) {
				code = reader.ReadToEnd();
				code = ModifyFromJavaToCSharp(code);
				code = ModifyCommonTreeAdaptorRegex(code);
				code = ModifyReturnScope(code);
				code = ModifyForNonTerminalNode(code);
				code = ModifyForTerminalNode(code);
			}
			using (var writer = new StreamWriter(path, false, XEncoding.SJIS)) {
				writer.WriteLine("using Ucpf.Languages.Common.Antlr;");
				writer.WriteLine("using System.Collections.Generic;");
				writer.Write(code);
			}
		}

		public static string ModifyFromJavaToCSharp(string code) {
			return SystemOutRegex.Replace(code, "");
		}

		public static string ModifyCommonTreeAdaptorRegex(string code) {
			return code
				.Replace("ITreeAdaptor", "XmlTreeAdaptor")
				.Replace("CommonTreeAdaptor", "XmlTreeAdaptor");
		}

		public static string ModifyReturnScope(string code) {
			return code.Replace(": ParserRuleReturnScope", ": XParserRuleReturnScope");
		}

		public static string ModifyForNonTerminalNode(string code) {
			return NonTerminalRegex.Replace(code, @"adaptor.AddChild($1, $2.Tree, $2, retval)");
		}

		public static string ModifyForTerminalNode(string code) {
			Contract.Requires<InvalidOperationException>(!new Regex(@"adaptor\.Create\(([^)]*),").IsMatch(code));
			code = MatchRegex.Replace(code, "new XToken((IToken)$0, \"$1\")");
			return TerminalRegex.Replace(code, @"adaptor.Create($1, retval)");
		}
	}
}