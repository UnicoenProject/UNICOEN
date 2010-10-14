using System;
using System.Windows.Forms;
using Antlr.Runtime;
using Ucpf.Grammar.Analyzer.Antlr;
using Ucpf.Grammar.Analyzer.Antlr2;

namespace Ucpf.Grammar.Analyzer
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
	        var lex = new NewANTLRv3Lexer(new ANTLRFileStream("../OCPF.Grammar.Analyzer/Antlr/ANTLRv3.g"));
	        var tokens = new CommonTokenStream(lex);
	        var g = new NewANTLRv3Parser(tokens);
	        var r = g.grammarDef();

			var ast = AntlrAstGenerator.Instance.GenerateFromFile("../OCPF.Grammar.Analyzer/Antlr/ANTLRv3.g");

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainWindow());
		}
	}
}
