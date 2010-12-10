using System.Xml.Linq;
using Ucpf.Languages.JavaScript.CodeModel;

namespace Ucpf.Languages.JavaScript.CodeModel {
	// unaryExpression
	// : postfixExpression
	// | ('delete' | 'void' | 'typeof' | '++' | '--' | '+' | '-' | '~' | '!') unaryExpression

	// postfixExpression
	// : leftHandSideExpression ('++' | '--')?
	public class JsUnaryExpression : JSExpression {
		private readonly XElement _node;

		public JsUnaryExpression(XElement expressionNode, JSOperator operatorNode)
			: base(expressionNode) {
			_node = expressionNode;
			Op = operatorNode;
		}

		public JSExpression Expression {
			get { return CreateExpression(_node); }
		}

		public JSOperator Op { private set; get; }
	}
}