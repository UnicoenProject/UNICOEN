using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Antlr.Runtime;
using Ucpf.Common.Antlr;
using Ucpf.Common.AstGenerators;

namespace Ucpf.Languages.C.AstGenerators {
	[Export(typeof(AstGenerator))]
	public class CAstGenerator : AntlrAstGenerator<CParser> {
		private static CAstGenerator _instance;

		private CAstGenerator() {}

		public static CAstGenerator Instance {
			get { return _instance ?? (_instance = new CAstGenerator()); }
		}

		protected override Func<CParser, XParserRuleReturnScope> DefaultParseFunc {
			get { return parser => parser.translation_unit(); }
		}

		public override string ParserName {
			get { return "C"; }
		}

		public override IEnumerable<string> TargetExtensions {
			get { return new[] { ".c" }; }
		}

		protected override ITokenSource CreateTokenSource(ICharStream stream) {
			return new CLexer(stream);
		}

		protected override CParser CreateParser(ITokenStream tokenStream) {
			return new CParser(tokenStream);
		}


	}
}