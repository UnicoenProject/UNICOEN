using System.Collections.Generic;
using Ucpf.CodeModel.Statements;

namespace Ucpf.CodeModel
{
	public interface IBlock : ICodeElement {
		IList<IStatement> Statements { get; }
	}
}
