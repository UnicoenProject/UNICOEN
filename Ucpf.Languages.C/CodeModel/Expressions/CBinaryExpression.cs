using System.Xml.Linq;
using Ucpf.Languages.C.CodeModel.Operators;

namespace Ucpf.Languages.C.CodeModel.Expressions
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
