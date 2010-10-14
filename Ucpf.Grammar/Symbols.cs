using System.Collections.Generic;
using System.Linq;
using Paraiba.Core;

namespace Ucpf.Grammar
{
	public class Symbols : ISymbol
	{
		private readonly IEnumerable<ISymbol> _symbols;

		public Symbols(IEnumerable<ISymbol> symbols)
		{
			_symbols = symbols;
		}

		public Symbols(params ISymbol[] symbols)
			: this((IEnumerable<ISymbol>)symbols)
		{
		}

		public int GetCount(int maxRepeat)
		{
			return _symbols.Aggregate(1, (v, s) => v * s.GetCount(maxRepeat));
		}

		public IEnumerable<Symbol> Expand(int index, int maxRepeat)
		{
			foreach (var symbol in _symbols) {
				var count = symbol.GetCount(maxRepeat);
				var rest = index % count;
				index /= count;
				foreach (var s in symbol.Expand(rest, maxRepeat)) {
					yield return s;
				}
			}
		}

		public override string ToString()
		{
			return "(" + _symbols.JoinString(" ") + ")";
		}
	}
}
