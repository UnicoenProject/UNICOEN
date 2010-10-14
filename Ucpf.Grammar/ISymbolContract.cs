using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Ucpf.Grammar
{
	[ContractClassFor(typeof(ISymbol))]
	sealed class ISymbolContract : ISymbol
	{
		int ISymbol.GetCount(int maxRepeat)
		{
			Contract.Ensures(0 <= Contract.Result<int>());
			return 0;
		}

		IEnumerable<Symbol> ISymbol.Expand(int index, int maxRepeat)
		{
			Contract.Requires(0 <= index);
			Contract.Requires(index < ((ISymbol)this).GetCount(maxRepeat));
			return null;
		}

		public override string ToString()
		{
			Contract.Ensures(Contract.Result<string>() != null);
			return null;
		}
	}
}