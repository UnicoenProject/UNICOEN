using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AntlrHelper
{
	class Program
	{
		static void Main(string[] args) {
			foreach (var arg in args) {
				ParserModifier.Modify(arg);
				var suffixCount = "Parser.cs".Length;
				LexerModifier.Modify(arg.Substring(0, arg.Length - suffixCount) + "Lexer.cs");
			}
		}
	}
}
