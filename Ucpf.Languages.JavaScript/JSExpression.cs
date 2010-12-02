using System;
using System.Linq;
using System.Xml.Linq;

namespace Ucpf.Languages.JavaScript {
    
    // expression
    // : assignmentExpression (LT!* ',' LT!* assignmentExpression)*
    public class JSExpression
    {
        private XElement _node;
        public JSExpression(XElement eNode)
        {
            _node = eNode;
        }

        protected JSExpression()
        {
            throw new NotImplementedException();
        }

        public static JSExpression CreateExpression(XElement xElement)
        {
            String[] binaryOperator = {
                "+", "-", "*", "/", "%"
            };

            var element = xElement.Element("expression").Elements().First();
            var targetElement =
                element.Descendants().Where(e =>
                {
                    var c = e.Elements().Count();
                    return c > 1 || (c == 1 && e.Element("TOKEN") != null);
                }).First();

            //case TOKEN
            if (targetElement.Elements().Count() == 1)
            {
                return new JSPrimaryExpression(targetElement);
            }

            //case Unary
            // public UnaryExpression(XElement expression, XElement op)
            if (targetElement.Name.LocalName == "UnaryExpression")
            {
                var tempNode = targetElement.Element("postfixExpression");
                if (tempNode != null && tempNode.Elements().Count() == 2)
                {
                    return
                        new JsUnaryExpression(
                            tempNode.Elements().ElementAt(0),
                            JSOperator.CreatePostOperator(tempNode.Elements().ElementAt(1)));
                }
                return
                    new JsUnaryExpression(
                        targetElement.Elements().ElementAt(1),
                        JSOperator.CreatePreOperator(targetElement.Elements().ElementAt(0)));
            }

            //case Binary
            if (binaryOperator.Contains(targetElement.Elements().ElementAt(1).Value))
            {
                return
                    new JSBinaryExpression(
                        targetElement.Elements().ElementAt(0),
                        JSOperator.CreateOperator(targetElement.Elements().ElementAt(1)),
                        targetElement.Elements().ElementAt(2));
            }

            return null;
        }
    }
}