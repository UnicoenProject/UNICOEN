using System.Collections.Generic;

namespace Ucpf.Grammar {
	public class RepeatSymbol : ISymbol {
		private readonly ISymbol _symbol;

		public RepeatSymbol(ISymbol symbol) {
			_symbol = symbol;
		}

		#region ISymbol Members

		public int GetCount(int maxRepeat) {
			return 1 + _symbol.GetCount(maxRepeat) * maxRepeat;
		}

		public IEnumerable<Symbol> Expand(int index, int maxRepeat) {
			if (index == 0)
				yield break;
			index--;
			do {
				foreach (var symbol in _symbol.Expand(index, maxRepeat)) {
					yield return symbol;
				}
				index -= _symbol.GetCount(maxRepeat);
			} while (index >= 0);
		}

		#endregion

		public override string ToString() {
			return _symbol + "*";
		}
	}
}