using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ucpf.Languages.C.CodeModel
{
	public abstract class CPrimaryExpression : CExpression
	{
		// properties
		public abstract string Body { get; set; }

		public CPrimaryExpression()
		{
		}

		// acceptor
		public new void Accept(CCodeModelToCode conv)
		{
			conv.Generate(this);
		}
	}
}
