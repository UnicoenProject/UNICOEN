using System;
using System.Xml.Linq;
using Ucpf.Common.CodeModel;
using Ucpf.Common.CodeModel.Expressions;
using Ucpf.Common.CodeModel.Operators;
using Ucpf.Common.CodeModelToCode;

namespace Ucpf.Languages.JavaScript.CodeModel {

	public class JSBinaryExpression : JSExpression, IBinaryExpression 
	{
		//properties
		public JSExpression Lhs { get; private set; }
		public JSExpression Rhs { get; private set; }
		public JSBinaryOperator Operator { get; private set; }

		//constructor
		public JSBinaryExpression(XElement leftSideNode, JSBinaryOperator op, XElement rightSideNode)
		{
			Lhs = JSExpression.CreateExpression(leftSideNode);
			Rhs = JSExpression.CreateExpression(rightSideNode);
			Operator = op;
		}

		//function
		public override void Accept(JSCodeModelToCode conv)
		{
			conv.Generate(this);
		}

		public override string ToString() {
			return Lhs.ToString() + Operator.Sign + Rhs.ToString();
		}
		
		//Common-Interface
		IExpression IBinaryExpression.LeftHandSide {
			get {
				return Lhs;
			}
			set {
				throw new NotImplementedException();
			}
		}

		IExpression IBinaryExpression.RightHandSide {
			get {
				return Rhs;
			}
			set {
				throw new NotImplementedException();
			}
		}

		IBinaryOperator IBinaryExpression.Operator {
			get {
				return Operator;
			}
			set {
				throw new NotImplementedException();
			}
		}

		void ICodeElement.Accept(ICodeModelToCode conv) {
			conv.Generate(this);
		}

	}
}