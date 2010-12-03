using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C
{
	public class CBinaryExpression : CExpression
	{
		private COperator _ope;
		private XElement _left;
		private XElement _right;

		public CExpression LeftExpression
		{
			get
			{
				return CExpression.CreateExpression(_left);
			}
		}
		public CExpression RightExpression
		{
			get
			{
				return CExpression.CreateExpression(_right);
			}
		}
		public COperator Operator
		{
			get
			{
				return _ope;
			}
		}


		public override string ToString()
		{
			string res = LeftExpression.ToString() + _ope.ToString() + RightExpression.ToString();
			return res;
		}

		// constructor
		public CBinaryExpression(XElement left, COperator ope, XElement right)
			: base(null, "binary")
		{
			_left = left;
			_ope = ope;
			_right = right;
		}
	}
}
