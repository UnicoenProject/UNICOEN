using System;
using System.Linq;
using System.Xml.Linq;
using Ucpf.Common.OldModel.Expressions;

using Ucpf.Common.Visitors;
using Ucpf.Languages.JavaScript.Model.Operators;

namespace Ucpf.Languages.JavaScript.Model.Expressions {
	// expression
	// : assignmentExpression (LT!* ',' LT!* assignmentExpression)*

	public class JSExpression : IExpression {
		//constructor
		protected JSExpression() {}

		//function

		#region IExpression Members

		public virtual void Accept(IModelToCode conv) {
			conv.Generate(this);
		}

		#endregion

		public static JSExpression CreateExpression(XElement node) {
			String[] binaryOperator = {
				"+", "-", "*", "/", "%", "<", ">"
			};

			var tmp =
				node.Descendants().Where(e => {
					var c = e.Elements().Count();
					return c > 1 || (c == 1 && e.Element("Identifier") != null) ||
					       (c == 1 && e.Element("TOKEN") != null);
				});

			//sometime, tmp may be empty list...?
			if (tmp.Count() == 0) {
				Console.Write(node);
				throw new NullReferenceException();
			}

			var targetElement = tmp.First();

			//case TOKEN
			if (targetElement.Elements().Count() == 1) {
				return new JSPrimaryExpression(targetElement);
			}

			//case CallExpression
			if (targetElement.Name.LocalName == "callExpression") {
				return new JSCallExpression(targetElement);
			}

			//case UnaryExpression (public UnaryExpression(XElement expression, XElement op))
			if (targetElement.Name.LocalName == "unaryExpression") {
				var tempNode = targetElement.Element("postfixExpression");
				if (tempNode != null && tempNode.Elements().Count() == 2) {
					//unaryExpression with postfixExpression
					return
						new JSUnaryExpression(
							tempNode.Elements().ElementAt(0),
							JSUnaryOperator.CreatePostfixOperator(tempNode.Elements().ElementAt(1)));
				}
				//unaryExpression with prefixExpression
				return
					new JSUnaryExpression(
						targetElement.Elements().ElementAt(1),
						JSUnaryOperator.CreatePrefixOperator(targetElement.Elements().ElementAt(0)));
			}

			//case BinaryExpression
			if (binaryOperator.Contains(targetElement.Elements().ElementAt(1).Value)) {
				return
					new JSBinaryExpression(
						targetElement.Elements().ElementAt(0),
						JSBinaryOperator.Create(targetElement.Elements().ElementAt(1)),
						targetElement.Elements().ElementAt(2));
			}

			//TODO implement other cases
			throw new NotImplementedException();
		}

		public override string ToString() {
			// return _node.Value;
			throw new NotImplementedException("Create :: ToString");
		}
	}
}