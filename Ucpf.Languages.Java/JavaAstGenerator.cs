using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Xml.Linq;
using Antlr.Runtime;
using Ucpf.AstGenerators;
using Ucpf.Languages.Common.Antlr;
using Ucpf.Weavers;

namespace Ucpf.Languages.Java
{
	[Export(typeof(AstGenerator))]
	public class JavaAstGenerator : AntlrAstGenerator<JavaParser>
	{
		private static JavaAstGenerator _instance;
		public static JavaAstGenerator Instance
		{
			get { return _instance ?? (_instance = new JavaAstGenerator()); }
		}

		private JavaAstGenerator() { }

		protected override Func<JavaParser, XParserRuleReturnScope> DefaultParseFunc
		{
			get { return parser => parser.compilationUnit(); }
		}

		public override string ParserName
		{
			get { return "Java6"; }
		}

		public override IEnumerable<string> TargetExtensions
		{
			get { return new[] { ".java" }; }
		}

		protected override ITokenSource CreateTokenSource(ICharStream stream)
		{
			return new JavaLexer(stream);
		}

		protected override JavaParser CreateParser(ITokenStream tokenStream)
		{
			return new JavaParser(tokenStream);
		}
	}
}


