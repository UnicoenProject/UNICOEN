using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Ucpf.Languages.JavaScript {

    // functionBody
    // : '{' LT!* sourceElements LT!* '}'

    // sourceElements
    // : sourceElement (LT!* sourceElement)*

    // sourceElement
    // : functionDeclaration
    // | statement
    public class JSFunctionBody
    {
        private XElement _node;
        public IEnumerable<JSFunctionDeclaration> FunctionDeclarations
        {
            get
            {
                return _node.Element("sourceElements").Elements(
                    "sourceElement")
                    .SelectMany(e =>
                                e.Elements("functionDeclaration").Select(
                                    e2 => new JSFunctionDeclaration(e2))
                    );
            }
        }
        public IEnumerable<JSStatement> Statements
        {
            get
            {
                return _node.Element("sourceElements").Elements(
                    "sourceElement")
                    .SelectMany(e =>
                                e.Elements("statement").Select(
                                    e2 => JSStatement.CreateStatement(e2))
                    );
            }
        }

        public JSFunctionBody(XElement xElement)
        {
            _node = xElement;
        }
    }
}