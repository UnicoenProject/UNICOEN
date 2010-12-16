using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C.CodeModel
{
	public class CUnaryExpression : CExpression
	{
		// properties
		public CUnaryOperator Operator { get; private set; }
		public CExpression Expression { get; private set; }

		// constructor
		public CUnaryExpression(CUnaryOperator ope, XElement expNode)
		{
			Operator = ope;
			Expression = CExpression.Create(expNode);
		}

		public override string ToString()
		{
			return Operator.ToString() + Expression.ToString();
		}

		// acceptor
		public new void Accept(CCodeModelToCode conv)
		{
			conv.Generate(this);
		}

	}
}
