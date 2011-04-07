using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using Code2Xml.Languages.JavaScript.XmlGenerators;
using Ucpf.Core.Model;



namespace Ucpf.Languages.JavaScript.Model {
	public class JSModelFactory {
		#region Expression

		public static IUnifiedExpression CreateExpression(XElement node) {
			Contract.Requires(node != null);

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
					return UnifiedVariable.Create(topExpressionElement.Value);
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
			return UnifiedBinaryExpression.Create(CreateExpression(node.Elements().ElementAt(0)), CreateBinaryOperator(node.Elements().ElementAt(1)), CreateExpression(node.Elements().ElementAt(2)));
		}

		public static UnifiedCall CreateCallExpression(XElement node) {
			return UnifiedCall.Create(
					CreateExpression(node),
					CreateArgumentCollection(node));
			//Function = new UnifiedVariable(identifier)
			//TODO consider: function identifier should to be which Variable or Literal
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
				return UnifiedIntegerLiteral.Create(i);
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

			return UnifiedUnaryOperator.Create(name, type);
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

			return UnifiedUnaryOperator.Create(name, type);
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

			return UnifiedBinaryOperator.Create(name, type);
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

			var element = node.Elements().First();

			switch (element.Name.LocalName) {
				case "statementBlock": return CreateBlock(element);
				case "variableStatement": return CreateVariableStatementList(element);
				case "ifStatement": return CreateIf(element);
				case "returnStatement": return CreateReturn(element);
				case "iterationStatement": return CreateIteration(element);
				case "switchStatement": return CreateSwitch(element);
				default: throw new NotImplementedException();
			}
		}

		private static IUnifiedExpression CreateIteration(XElement element) {
			Contract.Requires(element != null);
			Contract.Requires(element.Name.LocalName.EndsWith("iterationStatement"));
			/*
			 * iterationStatement
				: doWhileStatement
				| whileStatement
				| forStatement
				| forInStatement 
			 */

			var child = element.Elements().First();
			switch (child.Name.LocalName) {
				case "whileStatement": return CreateWhile(child);
				case "forStatement": return CreateFor(child);
				case "forInStatement": return CreateForeach(child);
				case "doWhileStatement": return CreateDoWhile(child);
				default: throw new NotImplementedException();
			}
		}

		public static UnifiedFor CreateFor(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name.LocalName.EndsWith("forStatement"));
			/* 
			 * forStatement
				: 'for' LT!* '(' (LT!* forStatementInitialiserPart)? LT!* ';' (LT!* expression)? LT!* ';' (LT!* expression)? LT!* ')' LT!* statement 
			 */
			/*
			 * forStatementInitialiserPart
				: expressionNoIn
				| 'var' LT!* variableDeclarationListNoIn
			 */

			//TODO 途中のexpressionがない場合を考慮しないといけない
			//TODO Initializerをどう実装するか考える
			return UnifiedFor.Create(
					null,	
					CreateExpression(node.Elements("expression").ElementAt(0)),
					CreateExpression(node.Elements("expression").ElementAt(1)),
					UnifiedBlock.Create(
						CreateStatement(node.Element("statement"))
					)
			);
		}

		public static UnifiedForeach CreateForeach(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name.LocalName.EndsWith("forInStatement"));
			/* 
			 * forInStatement
				: 'for' LT!* '(' LT!* forInStatementInitialiserPart LT!* 'in' LT!* expression LT!* ')' LT!* statement 
			 */
			//TODO Initializerをどう実装するか考える
			return UnifiedForeach.Create(
					null,
					CreateExpression(node.Element("expression")),
					UnifiedBlock.Create(
						CreateStatement(node.Element("statement"))
					)
			);
		}

		public static UnifiedDoWhile CreateDoWhile(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name.LocalName.EndsWith("doWhileStatement"));
			/* 
			 * doWhileStatement
				: 'do' LT!* statement LT!* 'while' LT!* '(' expression ')' (LT | ';') 
			 */
			return UnifiedDoWhile.Create(
					UnifiedBlock.Create(new IUnifiedExpression[] {
						CreateStatement(node.Element("statement"))
					}),
					CreateExpression(node.Element("expression"))
			);
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
			return UnifiedBlock.Create(
				node.Element("variableDeclarationList")
				.Elements("variableDeclaration")
				.Select(CreateVariableDefinition));
		}

		public static IUnifiedExpression CreateVariableDefinition(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name.LocalName.EndsWith("variableDeclaration"));

			if(false /*TODO 以下にfunctionExpressionを持つ場合はクラスを返す*/) {
				return UnifiedClassDefinition.Create(
						node.Element("Identifier").Value,
						null,
						null
				);
			}
			return UnifiedVariableDefinition.Create(
				null,
				null,
				CreateExpression(node.Element("initialiser")),
				node.Element("Identifier").Value
			);
		}

		public static UnifiedBlock CreateBlock(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name.LocalName == "statementBlock");
			/*
			 * statementBlock
				: '{' LT!* statementList? LT!* '}' 
			 */

			return UnifiedBlock.Create(
				node.Element("statementList").Elements("statement")
					.Select(CreateStatement).ToList()
				);
		}

		public static UnifiedBlock CreateFunctionBody(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name.LocalName == "functionBody");
			/*
			 * functionBody
				: '{' LT!* sourceElements LT!* '}' 
			 */

			//TODO 関数内の関数宣言をどう扱うか
			return UnifiedBlock.Create(
				node.Element("sourceElements").Elements("sourceElement")
					.SelectMany(e =>
								e.Elements("statement").Select(
									CreateStatement)
									).ToList()
					);
		}

		public static IUnifiedExpression CreateIf(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name.LocalName == "ifStatement");
			/*
			 * ifStatement
				: 'if' LT!* '(' LT!* expression LT!* ')' LT!* statement (LT!* 'else' LT!* statement)? 
			 */
			return UnifiedIf.Create(
					//TODO consider how deal with else block
					CreateExpression(node.Element("expression")),
				(UnifiedBlock)CreateStatement(node.Element("statement")), (UnifiedBlock)CreateStatement(node.Elements("statement").ElementAt(1)));
		}

		public static UnifiedWhile CreateWhile(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name.LocalName == "whileStatement");
			/*
			 * whileStatement
				: 'while' LT!* '(' LT!* expression LT!* ')' LT!* statement
			 */

			return UnifiedWhile.Create(
					UnifiedBlock.Create(new IUnifiedExpression[] {
						CreateStatement(node.Element("statement"))
					}),
					CreateExpression(node.Element("expression"))
			);
		}

		public static UnifiedSwitch CreateSwitch(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name.LocalName == "switchStatement");
			/*
			 * switchStatement
				: 'switch' LT!* '(' LT!* expression LT!* ')' LT!* caseBlock 
			 */

			return new UnifiedSwitch {
					Cases = CreateCaseCollection(node.Element("caseBlock")),
					Value = CreateExpression(node.Element("expression"))
			};
		}

		public static UnifiedCaseCollection CreateCaseCollection(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name.LocalName == "caseBlock");
			/*
			 * caseBlock
				: '{' (LT!* caseClause)* (LT!* defaultClause (LT!* caseClause)*)? LT!* '}'
			 */

			return new UnifiedCaseCollection(node.Elements().Select(CreateCase));
		}

		public static UnifiedCase CreateCase(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name.LocalName.EndsWith("Clause"));
			/*
			 * caseClause
				: 'case' LT!* expression LT!* ':' LT!* statementList?

			 * defaultClause
				: 'default' LT!* ':' LT!* statementList? 
			 */

			var body = UnifiedBlock.Create(node
				.Element("statementList")
				.Elements("statement")
				.Select(CreateStatement).ToList()
				);

			if(node.Name.LocalName == "caseClause") {
				return UnifiedCase.Create(CreateExpression(node.Element("expression")), body);
			}
			//else
			return UnifiedCase.Create(body);
		}

		public static UnifiedJump CreateReturn(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name.LocalName == "returnStatement");
			/*
			 * returnStatement
				: 'return' expression? (LT | ';') 
			 */

			if(node.Element("expression") != null) {
				return UnifiedJump.CreateReturn(CreateExpression(node.Element("expression")));
			}
			else {
				return UnifiedJump.CreateReturn();
			}
		}

		#endregion

		#region Function

		public static UnifiedFunctionDefinition CreateFunction(XElement node) {
			return UnifiedFunctionDefinition.Create(
					node.Element("Identifier").Value,
					CreateParameterCollection(node),
					CreateFunctionBody(node.Element("functionBody")));
		}

		public static UnifiedArgumentCollection CreateArgumentCollection(XElement node) {
			return new UnifiedArgumentCollection(
				node.Element("arguments").Elements().Where(e => e.Name.LocalName != "TOKEN")
					.Select(e2 => CreateArgument(e2))
			);
		}

		public static UnifiedArgument CreateArgument(XElement node) {
			return UnifiedArgument.Create(CreateExpression(node));
		}

		public static UnifiedParameterCollection CreateParameterCollection(XElement node) {
			return UnifiedParameterCollection.Create(
				node.Element("formalParameterList").Elements("Identifier")
				.Select(e => CreateParameter(e))
				);
		}

		public static UnifiedParameter CreateParameter(XElement node) {
			return UnifiedParameter.Create(node.Value);
		}

		#endregion

		public static UnifiedProgram CreateProgram(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name.LocalName == "program");

			var elements = node.Element("sourceElements")
					.Elements("sourceElement");
			return UnifiedProgram.Create(elements.Select(CreateSourceElement));
		}

		public static IUnifiedExpression CreateSourceElement(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name.LocalName == "sourceElement");

			switch (node.Elements().First().Name.LocalName) {
				case "functionDeclaration": return CreateFunction(node.Elements().First());
				case "statement": return CreateStatement(node.Elements().First());
				default: throw new InvalidOperationException();
			}
		}

		public static UnifiedProgram CreateModel(string source) {
			Contract.Requires(source != null);
			var ast = JavaScriptXmlGenerator.Instance.Generate(source);
			return CreateProgram(ast);
		}

	}
}
