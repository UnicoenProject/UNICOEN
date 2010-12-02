using System;
using System.Xml.Linq;

namespace Ucpf.Languages.JavaScript {
    public class JSOperator
    {
        XElement _node;
        String operatorName
        {
            get { return _node.Value; }
        }
        public JSOperator(XElement xElement)
        {
            _node = xElement;
        }

        protected JSOperator()
        {
            throw new NotImplementedException();
        }
    }
}