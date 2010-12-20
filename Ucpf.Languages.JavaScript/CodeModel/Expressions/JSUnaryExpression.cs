using System.Xml.Linq;
using Ucpf.Languages.JavaScript.CodeModel;

namespace Ucpf.Languages.JavaScript.CodeModel {
	// unaryExpression
	// : postfixExpression
	// | ('delete' | 'void' | 'typeof' | '++' | '--' | '+' | '-' | '~' | '!') unaryExpression

	// postfixExpression
	// : leftHandSideExpression ('++' | '--')?
	public class JSUnaryExpression : JSExpression {

		//constructor
		public JSUnaryExpression(XElement expressionNode, JSUnaryOperator op) {
			Expression = JSExpression.CreateExpression(expressionNode);
			Operator = op;
		}

		//field
		public JSExpression Expression { get; private set;}
		public JSUnaryOperator Operator {  get; private set; }

		//function
		public new void Accept(JSCodeModelToCode conv)
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