using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Ucpf.Grammar
{
	[ContractClass(typeof(ISymbolContract))]
	public interface ISymbol
	{
		int GetCount(int maxRepeat);

		IEnumerable<Symbol> Expand(int index, int maxRepeat);
	}
}
