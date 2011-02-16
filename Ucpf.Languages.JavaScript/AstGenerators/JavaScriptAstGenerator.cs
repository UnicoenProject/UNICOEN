using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Xml.Linq;
using Antlr.Runtime;
using Ucpf.Common.Antlr;
using Ucpf.Common.AstGenerators;

namespace Ucpf.Languages.JavaScript.AstGenerators {
	[Export(typeof(AstGenerator))]
	public class JavaScriptAstGenerator : AntlrAstGenerator<JavaScriptParser> {
		private static JavaScriptAstGenerator _instance;

		private JavaScriptAstGenerator() {}

		public static JavaScriptAstGenerator Instance {
			get { return _instance ?? (_instance = new JavaScriptAstGenerator()); }
		}

		protected override Func<JavaScriptParser, XParserRuleReturnScope>
			DefaultParseFunc {
			get { return parser => parser.program(); }
		}

		public override string ParserName {
			get { return "JavaScript"; }
		}

		public override IEnumerable<string> TargetExtensions {
			get { return new[] { ".js" }; }
		}

		protected override ITokenSource CreateTokenSource(ICharStream stream) {
			return new JavaScriptLexer(stream);
		}

		protected override JavaScriptParser CreateParser(ITokenStream tokenStream) {
			return new JavaScriptParser(tokenStream);
		}
	}
}