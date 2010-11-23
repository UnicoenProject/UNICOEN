using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Antlr.Runtime;
using Ucpf.AstGenerators;
using Ucpf.Languages.Common.Antlr;

namespace Ucpf.Languages.Lua
{
	[Export(typeof(AstGenerator))]
	public class LuaAstGeneratorOld : AntlrAstGeneratorOld<LuaParser>
	{
		private static LuaAstGeneratorOld _instance;
		public static LuaAstGeneratorOld Instance
		{
			get { return _instance ?? (_instance = new LuaAstGeneratorOld()); }
		}

		private LuaAstGeneratorOld() { }

		protected override Action<LuaParser> DefaultParseAction
		{
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


