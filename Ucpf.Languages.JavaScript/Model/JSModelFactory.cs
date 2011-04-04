using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using Ucpf.Core.Model;



namespace Ucpf.Languages.JavaScript.Model {
	public class JSModelFactory {
		#region Expression

		public static IUnifiedExpression CreateExpression(XElement node) {

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
				//TODO CONSIDER: TOKEN consisted of only [a-Z]* is always variable?
				if (System.Text.RegularExpressions.Regex.IsMatch(topExpressionElement.Value, @"[a-zA-Z]{1}[a-zA-Z0-9]*")) {
					return new UnifiedVariable {
						Name = topExpressionElement.Value
					};
				}
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

		public static IUnifiedExpression CreatePostfixUnaryExpression(XElement node) {
			//node.Elements().ElementAt(0),
			//CreateUnaryOperator.CreatePostfixOperator(node.Elements().ElementAt(1)));
			return null;
		}

		public static IUnifiedExpression CreatePrefixUnaryExpression(XElement node) {
			//node.Elements().ElementAt(1),
			//CreateUnaryOperator.CreatePrefixOperator(node.Elements().ElementAt(0)));
			return null;
		}

		public static IUnifiedExpression CreateLiteral(XElement node) {
			int i;
			if( Int32.TryParse(node.Value,NumberStyles.Any, null, out i) )
			{
				return new UnifiedIntegerLiteral {
					Value = i
				};
			}

			//TODO IMPLEMENT: other literal cases
			throw new NotImplementedException();
		}

		#endregion

		#region Operator

		public static UnifiedUnaryOperator CreatePrefixUnaryOperator(XElement node) {
			var name = node.Value;
			UnifiedUnaryOperatorType type;

			//TODO implement more OperationType cases
			switch (name) {
			case "++":
					type = UnifiedUnaryOperatorType.PreIncrementAssign;
					break;
			case "--":
					type = UnifiedUnaryOperatorType.PreDecrementAssign;
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
					type = UnifiedUnaryOperatorType.PostIncrementAssign;
					break;
			case "--":
					type = UnifiedUnaryOperatorType.PostDecrementAssign;
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
				case "+": type = UnifiedBinaryOperatorType.Add; break;
				case "-": type = UnifiedBinaryOperatorType.Subtract; break;
				case "*": type = UnifiedBinaryOperatorType.Multiply; break;
				case "/": type = UnifiedBinaryOperatorType.Divide; break;
				case "%": type = UnifiedBinaryOperatorType.Modulo; break;
				//Shift
				case "<<": type = UnifiedBinaryOperatorType.ArithmeticLeftShift; break;
				case ">>": type = UnifiedBinaryOperatorType.ArithmeticRightShift; break;
				//Comparison
				case ">": type = UnifiedBinaryOperatorType.GreaterThan; break;
				case ">=": type = UnifiedBinaryOperatorType.GreaterThanOrEqual; break;
				case "<": type = UnifiedBinaryOperatorType.LessThan; break;
				case "<=": type = UnifiedBinaryOperatorType.LessThanOrEqual; break;
				case "==": type = UnifiedBinaryOperatorType.Equal; break;
				case "!=": type = UnifiedBinaryOperatorType.NotEqual; break;
				//Logocal
				case "&&": type = UnifiedBinaryOperatorType.AndAlso; break;
				case "||": type = UnifiedBinaryOperatorType.OrElse; break;
				//Bit
				case "&": type = UnifiedBinaryOperatorType.And; break;
				case "|": type = UnifiedBinaryOperatorType.Or; break;
				case "^": type = UnifiedBinaryOperatorType.ExclusiveOr; break;
				//Assignment
				case "=": type = UnifiedBinaryOperatorType.Assign; break;
				case "+=": type = UnifiedBinaryOperatorType.AddAssign; break;
				case "-=": type = UnifiedBinaryOperatorType.SubtractAssign; break;
				case "*=": type = UnifiedBinaryOperatorType.MultiplyAssign; break;
				case "/=": type = UnifiedBinaryOperatorType.DivideAssign; break;
				case "%=": type = UnifiedBinaryOperatorType.ModuloAssign; break;
				default:
					throw new InvalidOperationException();
			}

			return new UnifiedBinaryOperator(name, type);
		}

		#endregion

		#region Statement

		public static IUnifiedExpression CreateStatement(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name.LocalName.EndsWith("statement"));
			/* 
			 * statement
				: statementBlock
				| variableStatement
				| emptyStatement
				| expressionStatement
				| ifStatement
				| iterationStatement
				| continueStatement
				| breakStatement
				| returnStatement
				| withStatement
				| labelledStatement
				| switchStatement
				| throwStatement
				| tryStatement
			 */

			Contract.Requires(node != null);
			Contract.Requires(node.Name.LocalName.EndsWith("statement"));
			/* 
			 * statement
				: statementBlock
				| variableStatement
				| emptyStatement
				| expressionStatement
				| ifStatement
				| iterationStatement
				| continueStatement
				| breakStatement
				| returnStatement
				| withStatement
				| labelledStatement
				| switchStatement
				| throwStatement
				| tryStatement
			 */

			var element = node.Elements().First();

			switch (element.Name.LocalName) {
				case "statementBlock": return CreateBlock(element);
				case "variableStatement": return CreateVariableStatementList(element);
				case "ifStatement": return CreateIf(element);
				case "returnStatement": return CreateReturn(element);
				default: throw new NotImplementedException();
			}
		}

		public static UnifiedBlock CreateVariableStatementList(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name.LocalName.EndsWith("variableStatement"));
			/*
			 * variableStatement
				: 'var' LT!* variableDeclarationList (LT | ';')

			 * variableDeclarationList
				: variableDeclaration (LT!* ',' LT!* variableDeclaration)*	

			 * variableDeclaration
				: Identifier LT!* initialiser? 
			 */
			return new UnifiedBlock(
				node.Element("variableDeclarationList")
				.Elements("variableDeclaration")
				.Select(CreateVariableDefinition));
		}

		public static IUnifiedExpression CreateVariableDefinition(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name.LocalName.EndsWith("variableDeclaration"));

			if(false /*TODO 以下にfunctionExpressionを持つ場合はクラスを返す*/) {
				return new UnifiedClassDefinition() {
						Name = node.Element("Identifier").Value,
						Body = null,
						Modifiers = null
				};
			}
			return new UnifiedVariableDefinition {
					Modifiers = null,
					Type = null,
					Name = node.Element("Identifier").Value,
					InitialValue = CreateExpression(node.Element("initialiser"))
			};
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

		public static IUnifiedExpression CreateIf(XElement node) {
			return new UnifiedIf {
					//TODO consider how deal with else block
					Condition = CreateExpression(node.Element("expression")),
					TrueBody = (UnifiedBlock)CreateStatement(node.Element("statement")),
					FalseBody =(UnifiedBlock)CreateStatement(node.Elements("statement").ElementAt(1))
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
				Body = CreateFunctionBody(node.Element("functionBody")),
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
