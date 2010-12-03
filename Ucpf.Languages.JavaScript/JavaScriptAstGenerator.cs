using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Xml.Linq;
using Antlr.Runtime;
using Ucpf.AstGenerators;
using Ucpf.Languages.Common.Antlr;
using Ucpf.Weavers;

namespace Ucpf.Languages.JavaScript
{
	[Export(typeof(AstGenerator))]
	public class JavaScriptAstGenerator : AntlrAstGenerator<JavaScriptParser>
	{
		private static JavaScriptAstGenerator _instance;
		public static JavaScriptAstGenerator Instance
		{
			get { return _instance ?? (_instance = new JavaScriptAstGenerator()); }
		}

		private JavaScriptAstGenerator() { }

		protected override Func<JavaScriptParser, XParserRuleReturnScope> DefaultParseFunc {
			get { return parser => parser.program(); }
		}

		public override string ParserName
		{
			get { return "JavaScript"; }
		}

		public override IEnumerable<string> TargetExtensions
		{
			get { return new[] { ".js" }; }
		}

		protected override void ArrangeAst(XElement ast)
		{
			var nodes = GetLackingBlockNodes(ast);
			Weaver.SafeWeaveAround(nodes,
				node => AntlrBlockGenerator.Generate(node, this));
		}

		protected override ITokenSource CreateTokenSource(ICharStream stream)
		{
			return new JavaScriptLexer(stream);
		}

		protected override JavaScriptParser CreateParser(ITokenStream tokenStream)
		{
			return new JavaScriptParser(tokenStream);
		}

		private static IEnumerable<XElement> GetLackingBlockNodes(XElement root)
		{
			var ifs = JavaScriptElements.If(root)
				.SelectMany(JavaScriptElements.IfAndElseProcesses);
			var whiles = JavaScriptElements.While(root)
				.Select(JavaScriptElements.WhileProcess);
			var dos = JavaScriptElements.DoWhile(root)
				.Select(JavaScriptElements.DoWhileProcess);
			var fors = JavaScriptElements.For(root)
				.Select(JavaScriptElements.ForProcess);
			var foreaches = JavaScriptElements.ForEach(root)
				.Select(JavaScriptElements.ForEachProcess);
			var withs = JavaScriptElements.With(root)
				.Select(JavaScriptElements.WithProcess);

			return ifs.Concat(whiles)
				.Concat(dos)
				.Concat(fors)
				.Concat(foreaches)
				.Concat(withs);
		}
	}
}
