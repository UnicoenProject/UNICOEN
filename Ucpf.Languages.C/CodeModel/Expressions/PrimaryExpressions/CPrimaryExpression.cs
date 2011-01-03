using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
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

		public new static CPrimaryExpression Create(XElement expNode) {
			if(expNode.Element("IDENTIFIER") != null) {
				return new CString(expNode);
			}
			else if(expNode.Element("constant") != null) {
				return new CNumber(expNode);
			}
			else {
				throw new InvalidOperationException();
			}
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
