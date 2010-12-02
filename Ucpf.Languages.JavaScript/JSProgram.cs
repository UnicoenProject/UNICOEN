using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Ucpf.Languages.JavaScript {

    // program
    // : LT!* sourceElements LT!* EOF!

    // sourceElements
    // : sourceElement (LT!* sourceElement)*

    // sourceElement
    // : functionDeclaration
    // | statement
    public class JSProgram
    {
        private XElement _rootNode;

        public JSProgram(XElement rootNode) {
            _rootNode = rootNode;
        }

        public IEnumerable<JSFunctionDeclaration> Functions
        {
            get
            {
                return _rootNode.Element("sourceElements").Elements(
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
                return _rootNode.Element("sourceElements").Elements(
                    "sourceElement")
                    .SelectMany(e =>
                                e.Elements("statement").Select(
                                    e2 => new JSStatement(e2))
                    );
            }
        }
    }
}