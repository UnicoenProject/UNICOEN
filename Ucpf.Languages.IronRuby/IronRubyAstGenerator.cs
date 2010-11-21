using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Xml.Linq;
using Ucpf.AstGenerators;
using Ucpf.Weavers;

namespace Ucpf.Languages.IronRuby
{
	[Export(typeof(IAstGenerator))]
	public class IronRubyAstGenerator : AstGeneratorStringBase
	{
		private static IronRubyAstGenerator _instance;
		public static IronRubyAstGenerator Instance
		{
			get { return _instance ?? (_instance = new IronRubyAstGenerator()); }
		}

		public override string ParserName
		{
			get { return "Ruby1.8"; }
		}

		public override IEnumerable<string> TargetExtensions
		{
			get { return new[] { ".rb" }; }
		}

		private IronRubyAstGenerator() { }

		public override XElement GenerateFromText(string text, bool ignoreArrange = false)
		{
			var ast = IronRubyParser.ParseCodeFromString(text);
			if (!ignoreArrange) {
				Weaver.SafeWeaveAround(GetLackingBlockNodesAround(ast),
					node => {
						if (node.Name.LocalName == "block")
							return node;
						return node.Name.LocalName != "Nil"
							? new XElement("block", node)
							: new XElement("block");
					});
				Weaver.WeaveAfter(GetLackingBlockNodesAfter(ast),
					node => new XElement("block"));
			}
			return ast;
		}

		public IEnumerable<XElement> GetLackingBlockNodesAround(XElement root)
		{
			var ifs = RubyElements.If(root)
				.SelectMany(e => new[] {
					RubyElements.IfProcess(e),
					RubyElements.ElseProcess(e),
				});
			var untils = RubyElements.WhileUntil(root)
				.Select(RubyElements.WhileUntilProcess);
			var fors = RubyElements.For(root)
				.Select(RubyElements.ForProcess)
				.Where(e => e != null);
			var iters = RubyElements.Iterator(root)
				.Select(RubyElements.IteratorProcess)
				.Where(e => e != null);

			return ifs.Concat(untils).Concat(fors).Concat(iters);
		}

		public IEnumerable<XElement> GetLackingBlockNodesAfter(XElement root)
		{
			var fors = RubyElements.SimpleFor(root)
				.Select(RubyElements.ForProcessBefore);
			var iters = RubyElements.SimpleIterator(root)
				.Select(RubyElements.IteratorProcessBefore);

			return fors.Concat(iters);
		}
	}
}
