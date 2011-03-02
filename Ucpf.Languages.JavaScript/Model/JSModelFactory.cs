using System;
using System.Linq;
using System.Xml.Linq;
using Ucpf.Common.Model;

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
			var expressionList =
				node.Descendants().Where(e => {
					var c = e.Elements().Count();
					return c > 1 || (c == 1 && e.Element("Identifier") != null) ||
						   (c == 1 && e.Element("TOKEN") != null);
				});

			//Ensure that node has some expression
			if (expressionList.Count() == 0) {
				Console.Write(node);
				throw new NullReferenceException();
			}

			var topExpressionElement = expressionList.First();

			//case PrimaryExpression: Identifier or TOKEN
			if (topExpressionElement.Elements().Count() == 1) {
				return CreateLiteral(topExpressionElement);
			}

			//case CallExpression
			if (topExpressionElement.Name.LocalName == "callExpression") {
				return CreateCallExpression(topExpressionElement);
			}

			//case UnaryExpression (public UnaryExpression(XElement expression, XElement op))
			if (topExpressionElement.Name.LocalName == "unaryExpression") {
				var tempNode = topExpressionElement.Element("postfixExpression");
				if (tempNode != null && tempNode.Elements().Count() == 2) {
					//unaryExpression with postfixExpression
					return CreatePostfixUnaryExpression(tempNode);
				}
				//unaryExpression with prefixExpression
				return CreatePrefixUnaryExpression(topExpressionElement);
			}

			//case BinaryExpression
			if (binaryOperator.Contains(topExpressionElement.Elements().ElementAt(1).Value)) {
				return CreateBinaryExpression(topExpressionElement);
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
			return new UnifiedCall {
				Arguments = CreateArgumentCollection(node),
				Function = CreateExpression(node)
				//Function = new UnifiedVariable(identifier)
				//TODO consider: function identifier should to be which Variable or Literal
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

		public static UnifiedExpression CreateLiteral(XElement node) {
			return new UnifiedLiteral() {
				Value = node.Value
			};
		}

		#endregion

		#region Operator

		public static UnifiedUnaryOperator CreatePrefixUnaryOperator(XElement node) {
			var name = node.Value;
			UnifiedUnaryOperatorType type;

			//TODO implement more OperationType cases
			switch (name) {
			case "++":
					type = UnifiedUnaryOperatorType.PrefixIncrement;
					break;
			case "--":
					type = UnifiedUnaryOperatorType.PrefixDecrement;
					break;
			default:
				throw new InvalidOperationException();
			}

			return new UnifiedUnaryOperator(name, type);
		}

		public static UnifiedUnaryOperator CreatePostfixUnaryOperator(XElement node) {
			var name = node.Value;
			UnifiedUnaryOperatorType type;

			switch (name) {
			case "++":
					type = UnifiedUnaryOperatorType.PostfixIncrement;
					break;
			case "--":
					type = UnifiedUnaryOperatorType.PostfixDecrement;
					break;
			default:
				throw new InvalidOperationException();
			}

			return new UnifiedUnaryOperator(name, type);
		}

		public static UnifiedBinaryOperator CreateBinaryOperator(XElement node) {
			//TODO implement more OperatorType cases
			var name = node.Value;
			UnifiedBinaryOperatorType type;

			switch (name) {
				//Arithmetic
				case "+": type = UnifiedBinaryOperatorType.Addition; break;
				case "-": type = UnifiedBinaryOperatorType.Subtraction; break;
				case "*": type = UnifiedBinaryOperatorType.Multiplication; break;
				case "/": type = UnifiedBinaryOperatorType.Division; break;
				case "%": type = UnifiedBinaryOperatorType.Modulo; break;
				//Shift
				case "<<": type = UnifiedBinaryOperatorType.LeftShift; break;
				case ">>": type = UnifiedBinaryOperatorType.RightShift; break;
				//Comparison
				case ">": type = UnifiedBinaryOperatorType.Greater; break;
				case ">=": type = UnifiedBinaryOperatorType.GreaterEqual; break;
				case "<": type = UnifiedBinaryOperatorType.Lesser; break;
				case "<=": type = UnifiedBinaryOperatorType.LesserEqual; break;
				case "==": type = UnifiedBinaryOperatorType.Equal; break;
				case "!=": type = UnifiedBinaryOperatorType.NotEqual; break;
				//Logocal
				case "&&": type = UnifiedBinaryOperatorType.LogicalAnd; break;
				case "||": type = UnifiedBinaryOperatorType.LogicalOr; break;
				//Bit
				case "&": type = UnifiedBinaryOperatorType.BitAnd; break;
				case "|": type = UnifiedBinaryOperatorType.BitOr; break;
				case "^": type = UnifiedBinaryOperatorType.BitXor; break;
				//Assignment
				case "=": type = UnifiedBinaryOperatorType.Assignment; break;
				case "+=": type = UnifiedBinaryOperatorType.AddAssignment; break;
				case "-=": type = UnifiedBinaryOperatorType.SubAssignment; break;
				case "*=": type = UnifiedBinaryOperatorType.MulAssignment; break;
				case "/=": type = UnifiedBinaryOperatorType.DivAssignment; break;
				case "%=": type = UnifiedBinaryOperatorType.ModAssignment; break;
				default:
					throw new InvalidOperationException();
			}

			//TODO second parameter is BinaryOperatorType? UnifiedBinaryOperatorType?
			return new UnifiedBinaryOperator(name, type);
		}

		#endregion

		#region Statement

		public static UnifiedExpression CreateStatement(XElement node) {
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
			return new UnifiedBlock(
				node.Element("statementList").Elements("statement")
					.Select(CreateStatement).ToList()
				);
		}

		public static UnifiedBlock CreateFunctionBody(XElement node) {
			return new UnifiedBlock(
				node.Element("sourceElements").Elements("sourceElement")
					.SelectMany(e =>
								e.Elements("statement").Select(
									CreateStatement)
									).ToList()
					);
		}

		public static UnifiedExpression CreateIf(XElement node) {
			return new UnifiedIf {
					//TODO consider how deal with else block
					Condition = CreateExpression(node.Element("expression")),
					TrueBlock = (UnifiedBlock)CreateStatement(node.Element("statement")),
					FalseBlock =(UnifiedBlock)CreateStatement(node.Elements("statement").ElementAt(1))
				};
		}

		public static UnifiedReturn CreateReturn(XElement node) {
			return new UnifiedReturn {
				Value = CreateExpression(node.Element("expression"))
			};
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
