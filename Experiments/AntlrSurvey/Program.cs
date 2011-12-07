using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr.Runtime;

namespace AntlrSurvey
{
	class Program {
		static void Main(string[] args) {
			var expression = @"1+3 //addition\n
							   5*6 //multiply";

			var input = new ANTLRStringStream(expression);
			var lexer = new E1Lexer(input);

			var tokens = new CommonTokenStream(lexer);

			Console.WriteLine("-----Lexer---------------");

			//on channelな要素のみを出力
			Console.WriteLine("-----on channel---------------");
			var i = 1;
			while(!tokens.LT(i).Text.Equals("<EOF>")) {
				Console.WriteLine("tokens[" + i + "]= " + tokens.LT(i).Text);
				i++;
			}
			Console.WriteLine();

			//HIDDENな要素のみを出力
			Console.WriteLine("-----Hidden channel---------------");
			i = 0;
			while(!tokens.Get(i).Text.Equals("<EOF>")) {
				var t = tokens.Get(i);
				if(t.Channel == TokenChannels.Hidden)
					Console.WriteLine("tokens[" + i + "]= " + tokens.Get(i).Text);
				i++;
			}
			Console.WriteLine();

			Console.WriteLine("-----Parser---------------");
			var parser = new E1Parser(tokens);
			parser.prog();
		}
	}
}
