using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ucpf.Common.Model
{
	public interface IPrimaryExpression : IExpression
	{
		string Name { get; set; }
	}
}
