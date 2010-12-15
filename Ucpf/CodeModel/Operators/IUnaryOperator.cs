using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ucpf.CodeModel
{
	public interface IUnaryOperator : ICodeElement
	{
		string Sign { get; }
		UnaryOperatorType Type { get; }
	}
}
