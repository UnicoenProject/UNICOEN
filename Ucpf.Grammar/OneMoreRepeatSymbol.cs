using System.Collections.Generic;

namespace Ucpf.Grammar
{
	public class OneMoreRepeatSymbol : ISymbol
	{
		private readonly ISymbol _symbol;

		public OneMoreRepeatSymbol(ISymbol symbol)
		{
			_symbol = symbol;
		}

		public int GetCount(int maxRepeat)
		{
			return _symbol.GetCount(maxRepeat) * maxRepeat;
		}

		public IEnumerable<Symbol> Expand(int index, int maxRepeat)
		{
			do {
				foreach (var symbol in _symbol.Expand(index, maxRepeat)) {
					yield return symbol;
				}
				index -= _symbol.GetCount(maxRepeat);
			} while (index >= 0);
		}

		public override string ToString()
		{
			return _symbol + "+";
		}
	}
}