using System;
using System.Xml.Linq;
using Ucpf.Common.ModelToCode;
using Ucpf.Common.OldModel.Expressions;
using Ucpf.Common.OldModel.Operators;
using Ucpf.Languages.JavaScript.Model.Operators;

namespace Ucpf.Languages.JavaScript.Model.Expressions {
	public class JSBinaryExpression : JSExpression, IBinaryExpression {
		//properties
		public JSBinaryExpression(XElement leftSideNode, JSBinaryOperator op,
		                          XElement rightSideNode) {
			Lhs = CreateExpression(leftSideNode);
			Rhs = CreateExpression(rightSideNode);
			Operator = op;
		}

		public JSExpression Lhs { get; private set; }
		public JSExpression Rhs { get; private set; }
		public JSBinaryOperator Operator { get; private set; }

		//constructor

		//function

		#region IBinaryExpression Members

		public override void Accept(IModelToCode conv) {
			conv.Generate(this);
		}

		//Common-Interface
		IExpression IBinaryExpression.LeftHandSide {
			get { return Lhs; }
			set { throw new NotImplementedException(); }
		}

		IExpression IBinaryExpression.RightHandSide {
			get { return Rhs; }
			set { throw new NotImplementedException(); }
		}

		IBinaryOperator IBinaryExpression.Operator {
			get { return Operator; }
			set { throw new NotImplementedException(); }
		}

		#endregion

		public override string ToString() {
			return Lhs + Operator.Sign + Rhs;
		}
	}
}