using System;
using System.Xml.Linq;
using Ucpf.Common.Model;
using Ucpf.Common.ModelToCode;

namespace Ucpf.Languages.C.Model {
	public class CBinaryExpression : CExpression, IBinaryExpression {
		// properties
		public CBinaryExpression(XElement leftNode, CBinaryOperator ope,
		                         XElement rightNode) {
			LeftExpression = Create(leftNode);
			RightExpression = Create(rightNode);
			Operator = ope;
		}

		public CExpression LeftExpression { get; private set; }
		public CExpression RightExpression { get; private set; }
		public CBinaryOperator Operator { get; private set; }

		// constructor

		// acceptor

		#region IBinaryExpression Members

		public override void Accept(IModelToCode conv) {
			conv.Generate(this);
		}

		#endregion

		#region IBinaryExpression メンバー

		IBinaryOperator IBinaryExpression.Operator {
			get { return Operator; }
			set { throw new NotImplementedException(); }
		}

		IExpression IBinaryExpression.LeftHandSide {
			get { return LeftExpression; }
			set { throw new NotImplementedException(); }
		}

		IExpression IBinaryExpression.RightHandSide {
			get { return RightExpression; }
			set { throw new NotImplementedException(); }
		}

		#endregion

		public override string ToString() {
			return LeftExpression.ToString() + Operator + RightExpression;
		}
	}
}