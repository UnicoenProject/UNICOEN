using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ucpf.CodeModel;

namespace Ucpf.Languages.C.CodeModel
{
	public abstract class CPrimaryExpression : CExpression, ITernaryExpression
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

		string ITernaryExpression.Body
		{
			get
			{
				return Body;
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		void ICodeElement.Accept(CodeModelToCode.ICodeModelToCode conv)
		{
			conv.Generate(this);
		}
	}
}
