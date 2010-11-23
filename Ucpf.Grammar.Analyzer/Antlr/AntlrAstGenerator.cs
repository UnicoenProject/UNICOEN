using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Antlr.Runtime;
using Ucpf.AstGenerators;
using Ucpf.Languages;
using Ucpf.Languages.Common.Antlr;

namespace Ucpf.Grammar.Analyzer.Antlr
{
	[Export(typeof(AstGenerator))]
	public class AntlrAstGenerator : AntlrAstGenerator<ANTLRv3Parser>
	{
		private static AntlrAstGenerator _instance;
		public static AntlrAstGenerator Instance
		{
			get { return _instance ?? (_instance = new AntlrAstGenerator()); }
		}

		private AntlrAstGenerator() { }

		protected override Func<ANTLRv3Parser, XParserRuleReturnScope> DefaultParseFunc
		{
			get { return parser => parser.grammarDef(); }
		}

		public override string ParserName
		{
			get { return "Antlr"; }
		}

		public override IEnumerable<string> TargetExtensions
		{
			get { return new[] { ".g" }; }
		}

		protected override ITokenSource CreateTokenSource(ICharStream stream)
		{
			return new ANTLRv3Lexer(stream);
		}

		protected override ANTLRv3Parser CreateParser(ITokenStream tokenStream)
		{
			return new ANTLRv3Parser(tokenStream);
		}
	}
}


