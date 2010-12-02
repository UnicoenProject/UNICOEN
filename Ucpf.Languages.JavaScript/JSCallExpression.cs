using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Ucpf.Languages.JavaScript {
    public class JSCallExpression : JSExpression
    {
        private XElement _node;
        String Identifier;
        IEnumerable<JSExpression> Arguments;
        public JSCallExpression(XElement xElement)
            : base(xElement)
        {
            _node = xElement;
        }
    }
}