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
	public class CPrimaryExpression : CExpression, IPrimaryExpression
	{
		// TODO :: remove the subclasses such as 'CNumber' and 'CString'

		// properties
		public string Body { get; set; }

		public CPrimaryExpression(XElement expNode) {
			Body = expNode.Value;
		}

		// acceptor
		public void Accept(IModelToCode conv)
		{
			conv.Generate(this);
		}

		public override string ToString() {
			return Body;
		}

	

		string IPrimaryExpression.Name
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

		void ICodeElement.Accept(IModelToCode conv)
		{
			conv.Generate(this);
		}
	}
}
