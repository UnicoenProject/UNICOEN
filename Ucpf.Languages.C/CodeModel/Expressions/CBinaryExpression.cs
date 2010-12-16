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
		public CBinaryOperator Operator { get; private set; }

		// constructor
		public CBinaryExpression(XElement leftNode, CBinaryOperator ope, XElement rightNode)
		{
			LeftExpression = CExpression.Create(leftNode);
			RightExpression = CExpression.Create(rightNode);
			Operator = ope;
		}

		public override string ToString()
		{
			return LeftExpression.ToString() + Operator.ToString() + RightExpression.ToString(); ;
		}

		// acceptor
		public new void Accept(CCodeModelToCode conv)
		{
			conv.Generate(this);
		}
	}
}
