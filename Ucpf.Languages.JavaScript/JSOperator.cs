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

        public static JSOperator CreateOperator(XElement xElement) {
            if(xElement.Value == "+") {
                return new JSPlusOperator(xElement);
            }
            //TODO implement when false.
            return null;
        }

        public static JSOperator CreatePreOperator(XElement xElement) {
            if(xElement.Value == "++") {
                return new JSIncreamentBeforeOperator(xElement);
            }
            //TODO implement when false.
            return null;
        }

        public static JSOperator CreatePostOperator(XElement xElement) {
            if(xElement.Value == "++") {
                return null;
            }
            //TODO implement when false.
            return null;
        }
    }
}