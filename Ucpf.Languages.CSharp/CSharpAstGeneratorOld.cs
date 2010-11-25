using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Xml.Linq;
using Antlr.Runtime;
using Ucpf.AstGenerators;
using Ucpf.Languages.Common.Antlr;
using Ucpf.Weavers;

namespace Ucpf.Languages.CSharp
{
	[Export(typeof(AstGenerator))]
	public class CSharpAstGeneratorOld : AntlrAstGeneratorOld<csParser>
	{
		private static CSharpAstGeneratorOld _instance;
		public static CSharpAstGeneratorOld Instance
		{
			get { return _instance ?? (_instance = new CSharpAstGeneratorOld()); }
		}

		private CSharpAstGeneratorOld() { }

		protected override Action<csParser> DefaultParseAction
		{
			get { return parser => parser.compilation_unit(); }
		}

		public override string ParserName
		{
			get { return "C#4.0"; }
		}

		public override IEnumerable<string> TargetExtensions
		{
			get { return new[] { ".cs" }; }
		}

		protected override void ArrangeAst(XElement ast)
		{
			var nodes = GetLackingBlockNodes(ast);
			Weaver.SafeWeaveAround(nodes,
				node => AntlrBlockGenerator.Generate(node, this));
		}

		protected override ITokenSource CreateTokenSource(ICharStream stream)
		{
			return new csLexer(stream);
		}

		protected override csParser CreateParser(ITokenStream tokenStream)
		{
			return new csParser(tokenStream);
		}

		private static IEnumerable<XElement> GetLackingBlockNodes(XElement root)
		{
			var ifs = CSharpElements.If(root)
				.Select(CSharpElements.IfProcess);
			var whiles = CSharpElements.While(root)
				.Select(CSharpElements.WhileProcess);
			var dos = CSharpElements.DoWhile(root)
				.Select(CSharpElements.DoWhileProcess);
			var fors = CSharpElements.For(root)
				.Select(CSharpElements.ForProcess);
			var foreaches = CSharpElements.ForEach(root)
				.Select(CSharpElements.ForEachProcess);

			return ifs.Concat(whiles)
				.Concat(dos)
				.Concat(fors)
				.Concat(foreaches);
		}
	}
}