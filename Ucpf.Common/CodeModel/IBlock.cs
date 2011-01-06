using System.Collections.Generic;
using Ucpf.Common.CodeModel.Statements;

namespace Ucpf.Common.CodeModel
{
	public interface IBlock : ICodeElement
	{
		IList<IStatement> Statements { get; }
	}
}
