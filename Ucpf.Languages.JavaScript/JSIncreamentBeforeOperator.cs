using System;
using System.Xml.Linq;

namespace Ucpf.Languages.JavaScript {
    public class IncreamentBeforeOperator : JSOperator
    {
        private String _operatorName
        {
            get
            {
                return "++";
            }
        }
        public IncreamentBeforeOperator(XElement _node) : base(_node) { }
    }
}