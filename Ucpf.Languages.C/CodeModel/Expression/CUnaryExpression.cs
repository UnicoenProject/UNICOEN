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
		private COperator _ope;
		private XElement _exp;

		public CExpression Expression
		{
			get
			{
				return CExpression.CreateExpression(_exp);
			}
		}

		public override string ToString()
		{
			return _ope.ToString() + Expression.ToString();
		}

		// constructor
		public CUnaryExpression(COperator ope, XElement exp)
			: base(null, "unary")
		{
			_ope = ope;
			_exp = exp;
		}
	}
}
