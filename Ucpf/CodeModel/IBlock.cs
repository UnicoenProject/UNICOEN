using System.Collections.Generic;

namespace Ucpf.CodeModel
{
	public interface IBlock : ICodeElement {
		IList<IStatement> Statements { get; }
	}
}
