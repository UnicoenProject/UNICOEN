using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Antlr.Runtime;
using Ucpf.AstGenerators;
using Ucpf.Languages.Common.Antlr;

namespace Ucpf.Languages.Lua
{
	[Export(typeof(IAstGenerator))]
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
			get { return GlobalInformation.LuaLanguage; }
		}

		public override IEnumerable<string> TargetExtensions
		{
			get { return GlobalInformation.LuaExtensions; }
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


