using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Antlr.Runtime;
using Ucpf.Common.AstGenerators;
using Ucpf.Common.Languages.Common.Antlr;

namespace Ucpf.Languages.Java {
	[Export(typeof(AstGenerator))]
	public class JavaAstGenerator : AntlrAstGenerator<JavaParser> {
		private static JavaAstGenerator _instance;

		private JavaAstGenerator() {}

		public static JavaAstGenerator Instance {
			get { return _instance ?? (_instance = new JavaAstGenerator()); }
		}

		protected override Func<JavaParser, XParserRuleReturnScope> DefaultParseFunc {
			get { return parser => parser.compilationUnit(); }
		}

		public override string ParserName {
			get { return "Java6"; }
		}

		public override IEnumerable<string> TargetExtensions {
			get { return new[] { ".java" }; }
		}

		protected override ITokenSource CreateTokenSource(ICharStream stream) {
			return new JavaLexer(stream);
		}

		protected override JavaParser CreateParser(ITokenStream tokenStream) {
			return new JavaParser(tokenStream);
		}
	}
}