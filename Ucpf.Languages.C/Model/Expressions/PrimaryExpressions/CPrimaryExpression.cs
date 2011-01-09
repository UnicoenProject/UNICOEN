using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Ucpf.Common.Model;
using Ucpf.Common.Model;
using Ucpf.Common.ModelToCode;

namespace Ucpf.Languages.C.Model
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
		public void Accept(IModelToCode conv)
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
	}
}
