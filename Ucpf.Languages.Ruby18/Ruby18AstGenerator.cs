using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Ucpf.Common.AstGenerators;
using Ucpf.Common.Weavers;

namespace Ucpf.Languages.Ruby18 {
	[Export(typeof(AstGenerator))]
	public class Ruby18AstGenerator : AstGenerator {
		private static Ruby18AstGenerator _instance;
		private Ruby18AstGenerator() {}

		public static Ruby18AstGenerator Instance {
			get { return _instance ?? (_instance = new Ruby18AstGenerator()); }
		}

		public override string ParserName {
			get { return "Ruby18"; }
		}

		public override IEnumerable<string> TargetExtensions {
			get { return new[] { ".rb" }; }
		}

		public override XElement Generate(TextReader reader) {
			return Generate(reader.ReadToEnd());
		}

		public override XElement Generate(string code) {
			var ast = IronRubyParser.ParseCodeFromString(code);
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
			return ast;
		}

		public IEnumerable<XElement> GetLackingBlockNodesAround(XElement root) {
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

		public IEnumerable<XElement> GetLackingBlockNodesAfter(XElement root) {
			var fors = RubyElements.SimpleFor(root)
				.Select(RubyElements.ForProcessBefore);
			var iters = RubyElements.SimpleIterator(root)
				.Select(RubyElements.IteratorProcessBefore);

			return fors.Concat(iters);
		}
	}
}