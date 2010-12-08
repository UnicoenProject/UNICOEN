using System.Xml.Linq;
using Ucpf.Languages.JavaScript.CodeModel.Operators;

namespace Ucpf.Languages.JavaScript.CodeModel.Expressions {
    public class JSBinaryExpression : JSExpression
    {
        private XElement _lNode;
        private XElement _rNode;
        public JSExpression Lhs
        {
            get
            {
                return CreateExpression(_lNode);
            }
        }
        public JSExpression Rhs
        {
            get
            {
                return CreateExpression(_rNode);
            }
        }

        public JSOperator Operator {
            private set; get;
        }

        public JSBinaryExpression(XElement leftSideNode, JSOperator op, XElement rightSideNode)
        {
            _lNode = leftSideNode;
            _rNode = rightSideNode;
            Operator = op;
        }
    }
}