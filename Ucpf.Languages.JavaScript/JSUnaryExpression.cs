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
        private XElement _operatorNode;
        JSExpression expression
        {
            get
            {
                return CreateExpression(_expressionNode);
            }
        }
        JSOperator op
        {
            get
            {
                //How distinguish PRE or POST?
                return new JSOperator(_operatorNode);
            }
        }
        public JsUnaryExpression(XElement eNode, XElement opNode)
            : base(eNode)
        {
            _expressionNode = eNode;
            _operatorNode = opNode;
        }
    }
}