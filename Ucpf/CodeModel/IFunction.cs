using System.Collections.Generic;

namespace Ucpf.CodeModel
{
	public interface IFunction
	{
		IType ReturnType { get; set; }
		string Name { get; set; }
		IList<IVariable> Parameters { get; set; }
		IBlock Body { get; set; }
	}
}
