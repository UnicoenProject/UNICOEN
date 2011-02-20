using System;
using System.Linq;
using System.Xml.Linq;
using Ucpf.Common.Model;
using Ucpf.Common.OldModel.Operators;

namespace Ucpf.Languages.JavaScript.Model
{
	public class JSModelFactory
	{
		#region Expression

		public static UnifiedExpression CreateExpression(XElement node) {
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
				//TODO change -> literal?
				return CreatePrimaryExpression(targetElement);
			}

			//case CallExpression
			if (targetElement.Name.LocalName == "callExpression") {
				return CreateCallExpression(targetElement);
			}

			//case UnaryExpression (public UnaryExpression(XElement expression, XElement op))
			if (targetElement.Name.LocalName == "unaryExpression") {
				var tempNode = targetElement.Element("postfixExpression");
				if (tempNode != null && tempNode.Elements().Count() == 2) {
					//unaryExpression with postfixExpression
					return CreatePostfixUnaryExpression(tempNode);
				}
				//unaryExpression with prefixExpression
				return CreatePrefixUnaryExpression(targetElement);
			}

			//case BinaryExpression
			if (binaryOperator.Contains(targetElement.Elements().ElementAt(1).Value)) {
				return CreateBinaryExpression(targetElement);
			}

			//TODO implement other cases
			throw new NotImplementedException();
		}

		public static UnifiedBinaryExpression CreateBinaryExpression(XElement node) {
			return new UnifiedBinaryExpression {
				LeftHandSide = CreateExpression(node.Elements().ElementAt(0)),
				Operator = CreateBinaryOperator(node.Elements().ElementAt(1)),
				RightHandSide = CreateExpression(node.Elements().ElementAt(2))
			};
		}

		public static UnifiedCall CreateCallExpression(XElement node) {
			//TODO consider UnifiedCall has Expression. Isn't it Identifier?
			var identifier =
				node.Descendants().Where(
				e => { return e.Name.LocalName == "Identifier"; }).First().Value;
			var arguments =
				node.Element("arguments").Elements().Where(e => e.Name.LocalName != "TOKEN")
					.Select(e2 => CreateExpression(e2)).ToList();
			return new UnifiedCall();
		}

		public static UnifiedExpression CreatePostfixUnaryExpression(XElement node) {
			//node.Elements().ElementAt(0),
			//CreateUnaryOperator.CreatePostfixOperator(node.Elements().ElementAt(1)));
			return null;
		}

		public static UnifiedExpression CreatePrefixUnaryExpression(XElement node) {
			//node.Elements().ElementAt(1),
			//CreateUnaryOperator.CreatePrefixOperator(node.Elements().ElementAt(0)));
			return null;
		}

		//TODO consider Primaryexpression: change to Literal?
		public static UnifiedExpression CreatePrimaryExpression(XElement node) {
			return new UnifiedLiteral() {
				Value = node.Value
			};
		}

		#endregion

		#region Operator

		public static UnifiedUnaryOperator CreatePrefixUnaryOperator(XElement node) {
			var name = node.Value;
			UnaryOperatorType type;

			//TODO implement more OperationType cases
			if (name == "++") {
				type = UnaryOperatorType.PrefixIncrement;
			} else {
				throw new InvalidOperationException();
			}

			return new UnifiedUnaryOperator(name, type);
		}

		public static UnifiedUnaryOperator CreatePostfixUnaryOperator(XElement node) {
			var name = node.Value;
			UnaryOperatorType type;

			if (name == "++") {
				type = UnaryOperatorType.PostfixIncrement;
			} else {
				throw new InvalidOperationException();
			}

			return new UnifiedUnaryOperator(name, type);
		}

		public static UnifiedBinaryOperator CreateBinaryOperator(XElement node) {
			//TODO implement more OperatorType cases
			var name = node.Value;
			UnifiedBinaryOperatorType type;

			switch (name) {
			case "+":
				type = UnifiedBinaryOperatorType.Addition;
				break;
			case "-":
				type = UnifiedBinaryOperatorType.Subtraction;
				break;
			case "<":
				type = UnifiedBinaryOperatorType.Lesser;
				break;
			default:
				throw new InvalidOperationException();
			}

			//TODO second parameter is BinaryOperatorType? UnifiedBinaryOperatorType?
			return new UnifiedBinaryOperator(name, (BinaryOperatorType)type);
		}

		#endregion

		#region Statement

		public static  UnifiedBlock CreateBlock(XElement node) {
			return null;
		}

		public static  UnifiedIf CreateIf(XElement node) {
			return null;
		}

		public static  UnifiedReturn CreateReturn(XElement node) {
			return null;
		}

		#endregion

		#region Function

		public static UnifiedDefineFunction CreateFunction(XElement node) {
			return null;
		}

		//TODO or Argument?
		public static UnifiedVariable CreateVariable(XElement node) {
			return null;
		}
	
		#endregion
	}
}
