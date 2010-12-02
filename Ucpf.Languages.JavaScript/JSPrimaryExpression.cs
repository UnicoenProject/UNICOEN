using System;
using System.Xml.Linq;

namespace Ucpf.Languages.JavaScript {
    public class JSPrimaryExpression : JSExpression
    {
        private XElement _node;
        String Identifier
        {
            get
            {
                return _node.Value;
            }
        }
        public JSPrimaryExpression(XElement value)
        {
            _node = value;
        }
    }
}