using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ucpf.CodeModel
{
	public interface IElseIfBlock : IBlock
	{
		IExpression ConditionalExpression { get; set; }
	}
}
