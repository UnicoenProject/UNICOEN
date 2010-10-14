using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Antlr.Runtime;
using OpenCodeProcessorFramework.Languages.Common.Antlr;
using Ucpf.AstGenerators;

namespace OpenCodeProcessorFramework.Languages.Antlr
{
	[Export(typeof(IAstGenerator))]
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
			get { return GlobalInformation.AntlrLanguage; }
		}

		public override IEnumerable<string> TargetExtensions
		{
			get { return GlobalInformation.AntlrExtensions; }
		}

		protected override ITokenSource CreateTokenSource(ICharStream stream)
		{
			return new JavaLexer(stream);
		}

		protected override ANTLRv3Parser CreateParser(ITokenStream tokenStream)
		{
			return new ANTLRv3Parser(tokenStream);
		}
	}
}


