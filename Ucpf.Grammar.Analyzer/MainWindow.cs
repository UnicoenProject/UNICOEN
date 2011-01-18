using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Paraiba.Collections.Generic;
using Paraiba.Core;

namespace Ucpf.Grammar.Analyzer {
	public partial class MainWindow : Form {
		private const int MaxRepeat = 2;
		private IDictionary<Symbol, ISymbol> _symbolTable;

		public MainWindow() {
			InitializeComponent();
		}

		public void PrintGrammar(IDictionary<Symbol, ISymbol> symbolTable) {
			_symbolTable = symbolTable;
			foreach (var symbol in symbolTable.Keys) {
				var node = new SymbolNode(symbol, _symbolTable);
				tvGrammar.Nodes.Add(node);
				AddChild(null, node);
			}
		}

		private void GrammarAnalyzer_Load(object sender, EventArgs ea) {
			var a = new Symbol("A");
			var b = new Symbol("B");
			var c = new Symbol("C");
			var d = new Symbol("D");
			var e = new Symbol("E");
			var f = new Symbol("F");
			var g = new Symbol("G");
			var h = new Symbol("H");
			var i = new Symbol("I");
			var j = new Symbol("J");
			var exp = new Symbols(
				new OrSymbol(b, new OptionSymbol(c), d),
				new OrSymbol(e, f)
				);
			var table = new Dictionary<Symbol, ISymbol> {
				{ a, exp },
			};
			PrintGrammar(table);
		}

		private void AddChild(SymbolNode parent, SymbolNode node) {
			node.ChildAdded = true;

			if (node.Symbol != null) {
				var symbol = _symbolTable.GetValueOrDefault(node.Symbol);
				if (symbol == null)
					return;
				var count = symbol.GetCount(MaxRepeat);
				var replaceSymbol = _symbolTable[node.Symbol];
				for (int i = 0; i < count; i++) {
					var text = replaceSymbol.Expand(i, MaxRepeat)
						.JoinString(" ");
					node.Nodes.Add(new SymbolNode(text));
				}
			} else {
				var replaceSymbol = _symbolTable[parent.Symbol];
				var symbols = replaceSymbol.Expand(node.Index, MaxRepeat);
				foreach (var symbol in symbols) {
					node.Nodes.Add(new SymbolNode(symbol, _symbolTable));
				}
			}
		}

		private void tvGrammar_BeforeExpand(object sender, TreeViewCancelEventArgs e) {
			var node = (SymbolNode)e.Node;
			foreach (SymbolNode child in node.Nodes) {
				if (child.ChildAdded)
					continue;
				AddChild(node, child);
			}
		}
	}
}