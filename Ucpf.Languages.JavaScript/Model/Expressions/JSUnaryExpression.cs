using System;
using System.Xml.Linq;
using Ucpf.Common.ModelToCode;
using Ucpf.Common.OldModel;
using Ucpf.Common.OldModel.Expressions;
using Ucpf.Common.OldModel.Operators;
using Ucpf.Languages.JavaScript.Model.Operators;

namespace Ucpf.Languages.JavaScript.Model.Expressions {
	// unaryExpression
	// : postfixExpression
	// | ('delete' | 'void' | 'typeof' | '++' | '--' | '+' | '-' | '~' | '!') unaryExpression

	// postfixExpression
	// : leftHandSideExpression ('++' | '--')?

	public class JSUnaryExpression : JSExpression, IUnaryExpression {
		//properties
		public JSUnaryExpression(XElement expressionNode, JSUnaryOperator op) {
			Expression = CreateExpression(expressionNode);
			Operator = op;
		}

		public JSExpression Expression { get; private set; }
		public JSUnaryOperator Operator { get; private set; }

		//constructor

		//Common-Interface

		#region IUnaryExpression Members

		IExpression IUnaryExpression.Term {
			get { return Expression; }
			set { throw new NotImplementedException(); }
		}

		IUnaryOperator IUnaryExpression.Operator {
			get { return Operator; }
			set { throw new NotImplementedException(); }
		}

		void ICodeElement.Accept(IModelToCode conv) {
			conv.Generate(this);
		}

		#endregion

		public override void Accept(IModelToCode conv) {
			conv.Generate(this);
		}

		public override string ToString() {
			//TODO must consider prefix or postfix
			return Operator + Expression.ToString();
		}
	}
}