using System.Collections.Generic;

namespace Ucpf.CodeModel
{
	public interface IVariable
	{
		string Name { get; set; }
		IType Type { get; set; }
	}
}
