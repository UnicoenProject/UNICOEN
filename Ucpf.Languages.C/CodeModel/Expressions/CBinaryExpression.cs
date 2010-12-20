using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Ucpf.CodeModel;

namespace Ucpf.Languages.C.CodeModel
{
	public class CBinaryExpression : CExpression, IBinaryExpression
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

		#region IBinaryExpression メンバー

		IBinaryOperator IBinaryExpression.Operator
		{
			get
			{
				return Operator;
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		IExpression IBinaryExpression.LeftHandSide
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		IExpression IBinaryExpression.RightHandSide
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		#endregion

		#region ICodeElement メンバー

		void ICodeElement.Accept(CodeModelToCode.ICodeModelToCode conv)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
