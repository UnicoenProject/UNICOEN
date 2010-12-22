using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ucpf.CodeModel
{
	public interface IExpressionStatement : IStatement
	{
		IExpression Expression { get; set; }
	}
}
