using System;
using System.Xml.Linq;

namespace Ucpf.Languages.JavaScript.CodeModel.Expressions {
    public class JSPrimaryExpression : JSExpression
    {
        private XElement _node;
        public String Identifier
        {
            get
            {
                return _node.Value;
            }
        }
        public JSPrimaryExpression(XElement xElement)
        {
            _node = xElement;
        }
    }
}