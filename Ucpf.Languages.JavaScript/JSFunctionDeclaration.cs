using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Ucpf.Languages.JavaScript {

    // functionDeclaration
    // : 'function' LT!* Identifier LT!* formalParameterList LT!* functionBody

    // formalParameterList
    // : '(' (LT!* Identifier (LT!* ',' LT!* Identifier)*)? LT!* ')'

    // callExpression
    // : memberExpression LT!* arguments (LT!* callExpressionSuffix)*
    public class JSFunctionDeclaration
    {
        private XElement _node;
        public String Identifier
        {
            get
            {
                return _node.Element("Identifier").Value;
            }
        }
        public IEnumerable<JSVariable> Parameters
        {
            get
            {
                return _node.Element("formalParameterList").Elements("Identifier").Select(e => new JSVariable(e));
            }
        }
        public JSFunctionBody FunctionBody
        {
            get
            {
                return new JSFunctionBody(_node.Element("functionBody"));
            }
        }
        public JSFunctionDeclaration(XElement xElement)
        {
            _node = xElement;
        }
    }
}