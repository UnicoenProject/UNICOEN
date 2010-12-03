using System.Xml.Linq;

namespace Ucpf.Languages.JavaScript {
    public class JSBinaryExpression : JSExpression
    {
        XElement _lNode;
        XElement _rNode;
        JSExpression lhs
        {
            get
            {
                return CreateExpression(_lNode);
            }
        }
        JSExpression rhs
        {
            get
            {
                return CreateExpression(_rNode);
            }
        }

        public JSOperator op {
            private set; get;
        }

        public JSBinaryExpression(XElement firstExpression, JSOperator op, XElement secondExpression)
        {
            _lNode = firstExpression;
            _rNode = secondExpression;
            this.op = op;
        }
    }
}