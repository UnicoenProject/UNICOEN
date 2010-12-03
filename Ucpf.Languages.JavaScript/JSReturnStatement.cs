using System.Xml.Linq;

namespace Ucpf.Languages.JavaScript {

    // returnStatement
    // : 'return' expression? (LT | ';')
    public class JSReturnStatement : JSStatement
    {
        private XElement _node;
        public JSExpression ReturnExpression
        {
            get
            {
                //TODO ReturnStatement may have no expression (It means "return;")
                return JSExpression.CreateExpression(_node.Element("expression"));
            }
        }
        public JSReturnStatement(XElement xElement)
            : base(xElement)
        {
            _node = xElement;
        }
    }
}