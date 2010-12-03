﻿using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Ucpf.Languages.JavaScript {

    // ifStatement
    // : 'if' LT!* '(' LT!* expression LT!* ')' LT!* statement (LT!* 'else' LT!* statement)?
    public class JSIfStatement : JSStatement
    {
        //TODO Is it need that the declaration of field of "_node" when this class inherit the "Statement" class?
        private XElement _node;
        public JSExpression ConditionalExpression
        {
            get
            {
                return JSExpression.CreateExpression(_node.Element("expression"));
            }
        }
        public JSStatement TrueBlock
        {
            get
            {
                return new JSStatement(_node.Element("statement"));
            }
        }
        public IEnumerable<JSStatement> ElseBlock
        {
            get
            {
                return _node.Elements("statement").Skip(1).Select(e => new JSStatement(e));
            }
        }

        public JSIfStatement(XElement xElement)
            : base(xElement)
        {
            _node = xElement;
        }
    }
}