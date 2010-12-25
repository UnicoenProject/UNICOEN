using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;


namespace Ucpf.Languages.Java.CodeModel
{
    public class JavaFunction
    {
        private XElement _node;
        public IEnumerable<String> Modifiers
        {
            get
            {
                return _node.Element("modifiers").Elements().Select(e => e.Value);
            }
        }

        public String Identifier
        {
            get
            {
                return _node.Element("IDENTIFIER").Value;
            }
        }
        public String ReturnType
        {
            get
            {
                return _node.Element("Type").Elements().ElementAt(0).Value;
            }
        }

        IEnumerable<Variable> Parameters
        {
            get
            {
                return _node.Element("formalParameterList").Elements("Identifier").Select(e => new Variable(e));
            }
        }
        Block block
        {
            get
            {
                return new Block(_node.Element("block"));
            }
        }

        public JavaFunction(XElement node)
        {
            _node = node;
        }
    }
}
