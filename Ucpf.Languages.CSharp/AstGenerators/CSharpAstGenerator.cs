using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Antlr.Runtime;
using Ucpf.Common.Antlr;
using Ucpf.Common.AstGenerators;

namespace Ucpf.Languages.CSharp.AstGenerators {
	[Export(typeof(AstGenerator))]
	public class CSharpAstGenerator : AntlrAstGenerator<csParser> {
		private static CSharpAstGenerator _instance;

		private CSharpAstGenerator() {}

		public static CSharpAstGenerator Instance {
			get { return _instance ?? (_instance = new CSharpAstGenerator()); }
		}

		protected override Func<csParser, XParserRuleReturnScope> DefaultParseFunc {
			get { return parser => parser.compilation_unit(); }
		}

		public override string ParserName {
			get { return "C#4.0"; }
		}

		public override IEnumerable<string> TargetExtensions {
			get { return new[] { ".cs" }; }
		}

		protected override ITokenSource CreateTokenSource(ICharStream stream) {
			return new csLexer(stream);
		}

		protected override csParser CreateParser(ITokenStream tokenStream) {
			return new csParser(tokenStream);
		}
	}
}