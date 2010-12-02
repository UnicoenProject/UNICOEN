using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Xml.Linq;
using Antlr.Runtime;
using Ucpf.AstGenerators;
using Ucpf.Languages.Common.Antlr;
using Ucpf.Weavers;

namespace Ucpf.Languages.C
{
	[Export(typeof(AstGenerator))]
	public class CAstGenerator : AntlrAstGenerator<CParser>
	{
		private static CAstGenerator _instance;
		public static CAstGenerator Instance
		{
			get { return _instance ?? (_instance = new CAstGenerator()); }
		}

		private CAstGenerator() { }

		protected override Func<CParser, XParserRuleReturnScope> DefaultParseFunc {
			get { return parser => parser.translation_unit(); }
		}

		public override string ParserName
		{
			get { return "C"; }
		}

		public override IEnumerable<string> TargetExtensions
		{
			get { return new[] { ".c" }; }
		}

		protected override void ArrangeAst(XElement ast)
		{
			var nodes = GetLackingBlockNodes(ast);
			Weaver.SafeWeaveAround(nodes,
				node => AntlrBlockGenerator.Generate(node, this));
		}

		protected override ITokenSource CreateTokenSource(ICharStream stream)
		{
			return new CLexer(stream);
		}

		protected override CParser CreateParser(ITokenStream tokenStream)
		{
			return new CParser(tokenStream);
		}

		private static IEnumerable<XElement> GetLackingBlockNodes(XElement root)
		{
			var loops = CElements.Loop(root)
				.Select(CElements.LoopProcess);
			var selections = CElements.Selection(root)
				.SelectMany(CElements.SelectionProcesses);

			return loops.Concat(selections);
		}
	}
}


