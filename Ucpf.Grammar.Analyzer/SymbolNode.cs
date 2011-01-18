using System.Collections.Generic;
using System.Windows.Forms;
using Paraiba.Collections.Generic;

namespace Ucpf.Grammar.Analyzer {
	public class SymbolNode : TreeNode {
		private readonly Symbol _symbol;

		public SymbolNode(string text)
			: base(text) {}

		public SymbolNode(Symbol symbol, IDictionary<Symbol, ISymbol> symbolTable) {
			var replaceNode = symbolTable.GetValueOrDefault(symbol);
			Text = symbol.Name +
			       (replaceNode != null ? (" := " + replaceNode) : string.Empty);
			_symbol = symbol;
		}

		public bool ChildAdded { get; set; }

		public Symbol Symbol {
			get { return _symbol; }
		}
	}
}