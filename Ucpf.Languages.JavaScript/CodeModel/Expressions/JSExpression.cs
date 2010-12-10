using System;
using System.Linq;
using System.Xml.Linq;
using Ucpf.Languages.JavaScript.CodeModel;

namespace Ucpf.Languages.JavaScript.CodeModel {
	// expression
	// : assignmentExpression (LT!* ',' LT!* assignmentExpression)*
	public class JSExpression {
		private XElement _node;

		public JSExpression(XElement xElement) {
			_node = xElement;
		}

		protected JSExpression() {
			//TODO How deal with super class constructor
			throw new NotImplementedException();
		}

		public static JSExpression CreateExpression(XElement xElement) {
			String[] binaryOperator = {
				"+", "-", "*", "/", "%"
			};

			//TODO this statement obtains which <expression> or <assimentExpression>?
			var element = xElement.Element("expression").Elements().First();
			var targetElement =
				element.Descendants().Where(e => {
					var c = e.Elements().Count();
					return c > 1 || (c == 1 && e.Element("TOKEN") != null);
				}).First();

			//case TOKEN
			if (targetElement.Elements().Count() == 1) {
				return new JSPrimaryExpression(targetElement);
			}

			//case Unary
			// public UnaryExpression(XElement expression, XElement op)
			if (targetElement.Name.LocalName == "UnaryExpression") {
				var tempNode = targetElement.Element("postfixExpression");
				if (tempNode != null && tempNode.Elements().Count() == 2) {
					//unaryExpression with postfixExpression
					return
						new JsUnaryExpression(
							tempNode.Elements().ElementAt(0),
							JSOperator.CreatePostfixOperator(tempNode.Elements().ElementAt(1)));
				}
				//unaryExpression with prefixExpression
				return
					new JsUnaryExpression(
						targetElement.Elements().ElementAt(1),
						JSOperator.CreatePrefixOperator(targetElement.Elements().ElementAt(0)));
			}

			//case Binary
			if (binaryOperator.Contains(targetElement.Elements().ElementAt(1).Value)) {
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