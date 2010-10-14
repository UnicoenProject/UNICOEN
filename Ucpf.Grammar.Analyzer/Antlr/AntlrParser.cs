using System;
using System.IO;
using System.Linq;
using Antlr.Runtime;
using Antlr.Runtime.Tree;

namespace Ucpf.Grammar.Analyzer.Antlr
{
	public class AntlrParser
	{
		private static readonly string[] IdentifiedTreeName = {
			"BLOCK", "ALT", "+", "?", "*",
		};

		private static readonly string[] ReplaceTreeName = {
			"=", "+=",
		};

		private static readonly string[] IgnoreTreeName = {
			"EOB", "EOA", "EOR",
		};

		private static void RemoveNode(ITree tree)
		{
			for (int i = 0; i < tree.ChildCount; i++) {
				var node = tree.GetChild(i);
				var text = node.Text;

				if (IdentifiedTreeName.Contains(text)) {
					RemoveNode(node);
					continue;
				}

				if (ReplaceTreeName.Contains(text)) {
					tree.SetChild(i--, node.GetChild(1));
					continue;
				}

				if (IgnoreTreeName.Contains(text) ||
						node.ChildCount != 0 ||
						(text[0] == '{' && text.EndsWith("}"))) {
					tree.DeleteChild(i--);
				}
			}
		}

		public void Parse(String fileName)
		{
	        // BUILD AST
	        var lex = new ANTLRv3Lexer(new ANTLRFileStream(fileName));
	        var tokens = new CommonTokenStream(lex);
	        var g = new ANTLRv3Parser(tokens);
	        var r = g.grammarDef();
	        var t = (CommonTree)r.Tree;

			var rules = t.GetChildren()
				.Where(tree => tree.Text == "RULE");

			using (var fs = new FileStream("rules_before.txt", FileMode.Create))
			using (var writer = new StreamWriter(fs)) {
				foreach (var rule in rules) {
					writer.WriteLine(rule.ToStringTree());
				}
			}

			foreach (var tree in rules) {
				RemoveNode(tree);
			}

			var ruleRightValues = rules
				.Select(tree => tree.GetChildren()
				        	.First(t2 => t2.Text == "BLOCK"));

			using (var fs = new FileStream("rules.txt", FileMode.Create))
			using (var writer = new StreamWriter(fs)) {
				foreach (var rule in rules) {
					writer.WriteLine(rule.ToStringTree());
				}
			}

			using (var fs = new FileStream("ruleRightValues.txt", FileMode.Create))
			using (var writer = new StreamWriter(fs)) {
				foreach (var ruleRightValue in ruleRightValues) {
					writer.WriteLine(ruleRightValue.ToStringTree());
				}
			}

			// WALK AST
	        var nodes = new CommonTreeNodeStream(t);
	        var walker = new ANTLRv3Tree(nodes);
	        walker.grammarDef();
		}

	}
}
