using System.Collections.Generic;

namespace Ucpf.Common.Model {
	public interface IBlock : ICodeElement {
		IList<IStatement> Statements { get; }
	}
}