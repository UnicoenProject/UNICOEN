using System.Xml.Linq;
using Ucpf.Languages.C.CodeModel.Operators;

namespace Ucpf.Languages.C.CodeModel.Expressions
{
	public class CUnaryExpression : CExpression
	{
		private COperator _ope;
		private XElement _exp;

		public CExpression Expression
		{
			get
			{
				return CExpression.Create(_exp);
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
