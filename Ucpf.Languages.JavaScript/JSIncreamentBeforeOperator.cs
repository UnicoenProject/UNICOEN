using System;
using System.Xml.Linq;

namespace Ucpf.Languages.JavaScript {
    public class JSIncreamentBeforeOperator : JSOperator
    {
        public String OperatorName
        {
            get
            {
                return "++";
            }
        }
        public JSIncreamentBeforeOperator(XElement _node) : base(_node) { }
    }
}