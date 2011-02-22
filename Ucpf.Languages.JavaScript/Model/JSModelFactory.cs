using System;
using System.Linq;
using System.Xml.Linq;
using Ucpf.Common.Model;
using Ucpf.Common.OldModel.Operators;

namespace Ucpf.Languages.JavaScript.Model {
	public class JSModelFactory {
		#region Expression

		public static UnifiedExpression CreateExpression(XElement node) {

			String[] binaryOperator = {
				"+", "-", "*", "/", "%", "<", ">"
			};

			/* 
			 * in descendants of <expression> node, if
			 * it has more than 2 child-node OR
			 * it has only one child whose name is <Identifier> OR
			 * it has only one child whose name is <TOKEN> 
			 * these are some actual expression
			*/
			var tmp =
				node.Descendants().Where(e => {
					var c = e.Elements().Count();
					return c > 1 || (c == 1 && e.Element("Identifier") != null) ||
						   (c == 1 && e.Element("TOKEN") != null);
				});

			//Ensure that node has some expression
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

			return new UnifiedCall {
				Arguments = CreateArgumentCollection(node),
				Function = new UnifiedVariable(identifier)
			};
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
			}
			else {
				throw new InvalidOperationException();
			}

			return new UnifiedUnaryOperator(name, type);
		}

		public static UnifiedUnaryOperator CreatePostfixUnaryOperator(XElement node) {
			var name = node.Value;
			UnaryOperatorType type;

			if (name == "++") {
				type = UnaryOperatorType.PostfixIncrement;
			}
			else {
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

		public static UnifiedStatement CreateStatement(XElement node) {
			var element = node.Elements().First();

			//case statementBlock
			if (element.Name.LocalName == "statementBlock")
				return CreateBlock(element);

			//case ifStatement
			if (element.Name.LocalName == "ifStatement")
				return CreateIf(element);

			//case returnStatement
			if (element.Name.LocalName == "returnStatement")
				return CreateReturn(element);

			//case error
			throw new NotImplementedException();
		}

		public static UnifiedBlock CreateBlock(XElement node) {
			//TODO null check
			return new UnifiedBlock(
				node.Element("statementList").Elements("statement")
					.Select(e => CreateStatement(e)).ToList()
				);
		}

		public static UnifiedBlock CreateFunctionBody(XElement node) {
			return new UnifiedBlock(
				node.Element("sourceElements").Elements("sourceElement")
					.SelectMany(e =>
								e.Elements("statement").Select(
									e2 => CreateStatement(e2))
									).ToList()
					);
		}

		public static UnifiedExpressionStatement CreateIf(XElement node) {
			return new UnifiedExpressionStatement(
				new UnifiedIf {
					//TODO UnifiedBlock isn't extended UnifiedStatement
					//TODO consider how deal with else block
					//TODO consider this cast is OK?
					Condition = CreateExpression(node.Element("expression")),
					TrueBlock = (UnifiedBlock)CreateStatement(node.Element("statement")),
					FalseBlock =
						(UnifiedBlock)CreateStatement(node.Elements("statement").ElementAt(1))
				});
		}

		public static UnifiedReturn CreateReturn(XElement node) {
			return new UnifiedReturn {
				Value = CreateExpression(node.Element("expression"))
			};
			//return new UnifiedReturn {
			//	Value = CreateExpression(node.Element("expression"))
			//};
		}

		#endregion

		#region Function

		public static UnifiedFunctionDefinition CreateFunction(XElement node) {
			return new UnifiedFunctionDefinition {
				Name = node.Element("Identifier").Value,
				Block = CreateFunctionBody(node.Element("functionBody")),
				Parameters = CreateParameterCollection(node)
			};
		}

		public static UnifiedArgumentCollection CreateArgumentCollection(XElement node) {
			return new UnifiedArgumentCollection(
				node.Element("arguments").Elements().Where(e => e.Name.LocalName != "TOKEN")
					.Select(e2 => CreateArgument(e2))
			);
		}

		public static UnifiedArgument CreateArgument(XElement node) {
			return new UnifiedArgument {
				Value = CreateExpression(node)
			};
		}

		public static UnifiedParameterCollection CreateParameterCollection(XElement node) {
			return new UnifiedParameterCollection(
				node.Element("formalParameterList").Elements("Identifier")
				.Select(e => CreateParameter(e))
				);
		}

		public static UnifiedParameter CreateParameter(XElement node) {
			return new UnifiedParameter { Name = node.Value };
		}

		#endregion
	}
}
