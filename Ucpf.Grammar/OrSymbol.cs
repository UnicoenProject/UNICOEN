using System.Collections.Generic;
using System.Linq;
using Paraiba.Core;

namespace Ucpf.Grammar {
	public class OrSymbol : ISymbol {
		private readonly IEnumerable<ISymbol> _symbols;

		public OrSymbol(IEnumerable<ISymbol> symbols) {
			_symbols = symbols;
		}

		public OrSymbol(params ISymbol[] symbols)
			: this((IEnumerable<ISymbol>)symbols) {}

		#region ISymbol Members

		public int GetCount(int maxRepeat) {
			return _symbols.Sum(s => s.GetCount(maxRepeat));
		}

		public IEnumerable<Symbol> Expand(int index, int maxRepeat) {
			foreach (var symbol in _symbols) {
				var count = symbol.GetCount(maxRepeat);
				if (index < count) {
					return symbol.Expand(index, maxRepeat);
				}
				index -= count;
			}
			return null;
		}

		#endregion

		public override string ToString() {
			return "(" + _symbols.JoinString(" | ") + ")";
		}
	}
}