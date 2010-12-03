using System.Xml.Linq;

namespace Ucpf.Languages.JavaScript {

    // unaryExpression
	// : postfixExpression
	// | ('delete' | 'void' | 'typeof' | '++' | '--' | '+' | '-' | '~' | '!') unaryExpression

    // postfixExpression
	// : leftHandSideExpression ('++' | '--')?
    public class JsUnaryExpression : JSExpression
    {
        private XElement _node;
        public JSExpression Expression
        {
            get
            {
                return CreateExpression(_node);
            }
        }
        
        public JSOperator Op {
            private set; get;
        }
        public JsUnaryExpression(XElement expressionNode, JSOperator operatorNode)
            : base(expressionNode)
        {
            _node = expressionNode;
            Op = operatorNode;
        }
    }
}