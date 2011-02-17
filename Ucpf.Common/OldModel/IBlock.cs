using System.Collections.Generic;
using Ucpf.Common.OldModel.Statements;

namespace Ucpf.Common.OldModel {
	public interface IBlock : ICodeElement {
		IList<IStatement> Statements { get; }
	}
}