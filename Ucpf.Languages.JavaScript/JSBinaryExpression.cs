using System.Xml.Linq;

namespace Ucpf.Languages.JavaScript {
    public class JSBinaryExpression : JSExpression
    {
        XElement _opNode;
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
        JSOperator op
        {
            get
            {
                return CreateOperator(_opNode);
            }
        }

        public static JSOperator CreateOperator(XElement opNode)
        {
            if (opNode.Value == "+")
            {
                return new JSPlusOperator(opNode);
            }
            return null;
        }

        public JSBinaryExpression(XElement firstExpression, XElement operaterName, XElement secondExpression)
        {
            _lNode = firstExpression;
            _rNode = secondExpression;
            _opNode = operaterName;
        }
    }
}