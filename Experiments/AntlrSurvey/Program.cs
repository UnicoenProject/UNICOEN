using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr.Runtime;

namespace AntlrSurvey
{
	class Program {
		static void Main(string[] args) {
			var expression = "1+2+3 //comment";

			var input = new ANTLRStringStream(expression);
			var lexer = new E1Lexer(input);
			var tokens = new CommonTokenStream(lexer);

			for(var i = 0; i < 10; i++) {
				Console.WriteLine("" + i + tokens.LT(i));
			}

			Console.WriteLine(tokens.Count);

			/*
			var parser = new E1Parser(tokens);

			var result = parser.prog();

			Console.Write(result);
			 * */
		}
	}
}
