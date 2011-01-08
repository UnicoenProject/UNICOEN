using System.Collections.Generic;
using Ucpf.Common.CodeModel;

namespace Ucpf.Common.CodeModel
{
	public interface IBlock : ICodeElement
	{
		IList<IStatement> Statements { get; }
	}
}
