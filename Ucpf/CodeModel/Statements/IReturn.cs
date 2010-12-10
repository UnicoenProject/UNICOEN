using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ucpf.CodeModel.Expressions;

namespace Ucpf.CodeModel.Statements
{
	public interface IReturn : IStatement
	{
		IExpression Return { get; }
	}
}
