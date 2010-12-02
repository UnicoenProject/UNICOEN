using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C
{
	public class CUnaryExpression : CExpression
	{
		private XElement _ope;
		private XElement _exp;

		public COperator Operator
		{
			get
			{
				return new COperator(_ope);
			}
		}
		public CExpression Expression
		{
			get
			{
				return CExpression.CreateExpression(_exp);
			}
		}

		public override string ToString()
		{
			return Operator.ToString() + Expression.ToString();
		}

		// constructor
		public CUnaryExpression(XElement ope, XElement exp)
			: base(null, "unary")
		{
			_ope = ope;
			_exp = exp;
		}
	}
}
