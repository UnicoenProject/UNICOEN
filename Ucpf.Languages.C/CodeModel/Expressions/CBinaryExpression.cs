using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C.CodeModel
{
	public class CBinaryExpression : CExpression
	{
		// properties
		public CExpression LeftExpression { get; private set; }
		public CExpression RightExpression { get; private set; }
		public COperator Operator { get; private set; }


		// constructor
		public CBinaryExpression(XElement leftNode, COperator ope, XElement rightNode)
		{
			LeftExpression = CExpression.Create(leftNode);
			RightExpression = CExpression.Create(rightNode);
			Operator = ope;
		}


		public override string ToString()
		{
			string res = LeftExpression.ToString() + Operator.ToString() + RightExpression.ToString();
			return res;
		}

		// acceptor
		public new void Accept(CCodeModelToCode conv)
		{
			conv.Generate(this);
		}
	}
}
