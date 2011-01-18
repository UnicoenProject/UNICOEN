using System.Collections.Generic;
using System.Linq;

namespace Ucpf.Grammar {
	public class OptionSymbol : ISymbol {
		private readonly ISymbol _symbol;

		public OptionSymbol(ISymbol symbol) {
			_symbol = symbol;
		}

		#region ISymbol Members

		public int GetCount(int maxRepeat) {
			return _symbol.GetCount(maxRepeat) + 1;
		}

		public IEnumerable<Symbol> Expand(int index, int maxRepeat) {
			return index == 0
			       	? Enumerable.Empty<Symbol>()
			       	: _symbol.Expand(index - 1, maxRepeat);
		}

		#endregion

		public override string ToString() {
			return _symbol + "?";
		}
	}
}