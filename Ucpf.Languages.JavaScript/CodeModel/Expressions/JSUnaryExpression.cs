using System;
using System.Xml.Linq;
using Ucpf.Common.CodeModel.Expressions;
using Ucpf.Common.CodeModel.Operators;

namespace Ucpf.Languages.JavaScript.CodeModel {
	// unaryExpression
	// : postfixExpression
	// | ('delete' | 'void' | 'typeof' | '++' | '--' | '+' | '-' | '~' | '!') unaryExpression

	// postfixExpression
	// : leftHandSideExpression ('++' | '--')?
	public class JSUnaryExpression : JSExpression, IUnaryExpression {

		//constructor
		public JSUnaryExpression(XElement expressionNode, JSUnaryOperator op) {
			Expression = JSExpression.CreateExpression(expressionNode);
			Operator = op;
		}

		//field
		public JSExpression Expression { get; private set;}
		public JSUnaryOperator Operator {  get; private set; }

		IExpression IUnaryExpression.Term {
			get {
				return Expression;
			}
			set {
				throw new NotImplementedException();
			}
		}

		IUnaryOperator IUnaryExpression.Operator {
			get {
				return Operator;
			}
			set {
				throw new NotImplementedException();
			}
		}

		//function
		public override void Accept(JSCodeModelToCode conv)
		{
			conv.Generate(this);
		}

		public override string ToString()
		{
			//TODO must consider prefix or postfix
			return Operator.ToString() + Expression.ToString();
		}
	
	}
}