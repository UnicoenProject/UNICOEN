using System.Xml.Linq;

namespace Ucpf.Languages.JavaScript {

    // unaryExpression
	// : postfixExpression
	// | ('delete' | 'void' | 'typeof' | '++' | '--' | '+' | '-' | '~' | '!') unaryExpression

    // postfixExpression
	// : leftHandSideExpression ('++' | '--')?
    public class JsUnaryExpression : JSExpression
    {
        private XElement _expressionNode;
        public JSExpression Expression
        {
            get
            {
                return CreateExpression(_expressionNode);
            }
        }
        
        public JSOperator Op {
            private set; get;
        }
        public JsUnaryExpression(XElement eNode, JSOperator op)
            : base(eNode)
        {
            _expressionNode = eNode;
            this.Op = op;
        }
    }
}