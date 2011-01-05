using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Antlr.Runtime;
using Ucpf.Common.AstGenerators;
using Ucpf.Common.Languages.Common.Antlr;

namespace Ucpf.Languages.Lua
{
	[Export(typeof(AstGenerator))]
	public class LuaAstGenerator : AntlrAstGenerator<LuaParser>
	{
		private static LuaAstGenerator _instance;
		public static LuaAstGenerator Instance
		{
			get { return _instance ?? (_instance = new LuaAstGenerator()); }
		}

		private LuaAstGenerator() { }

		protected override Func<LuaParser, XParserRuleReturnScope> DefaultParseFunc {
			get { return parser => parser.chunk(); }
		}

		public override string ParserName
		{
			get { return "Lua5.1"; }
		}

		public override IEnumerable<string> TargetExtensions
		{
			get { return new[] { ".lua" }; }
		}

		protected override ITokenSource CreateTokenSource(ICharStream stream)
		{
			return new LuaLexer(stream);
		}

		protected override LuaParser CreateParser(ITokenStream tokenStream)
		{
			return new LuaParser(tokenStream);
		}
	}
}


