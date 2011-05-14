#region License

// Copyright (C) 2011 The Unicoen Project
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Code2Xml.Languages.JavaScript.CodeToXmls;
using Unicoen.Core.Model;

namespace Unicoen.Languages.JavaScript.Model {
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
					node.Descendants().Where(
							e => {
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
				if (Regex.IsMatch(topExpressionElement.Value, @"[a-zA-Z]{1}[a-zA-Z0-9]*")) {
					return UnifiedIdentifier.CreateUnknown(topExpressionElement.Value);
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
			if (
					binaryOperator.Contains(topExpressionElement.Elements().ElementAt(1).Value)) {
				return CreateBinaryExpression(topExpressionElement);
			}

			//TODO implement other cases
			throw new NotImplementedException();
		}

		public static UnifiedBinaryExpression CreateBinaryExpression(XElement node) {
			return
					UnifiedBinaryExpression.Create(
							CreateExpression(node.Elements().ElementAt(0)),
							CreateBinaryOperator(node.Elements().ElementAt(1)),
							CreateExpression(node.Elements().ElementAt(2)));
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
			if (Int32.TryParse(node.Value, NumberStyles.Any, null, out i)) {
				return UnifiedIntegerLiteral.Create(i);
			}

			//TODO IMPLEMENT: other literal cases
			throw new NotImplementedException();
		}

		#endregion

		#region Operator

		public static UnifiedUnaryOperator CreatePrefixUnaryOperator(XElement node) {
			var name = node.Value;
			UnifiedUnaryOperatorKind kind;

			//TODO implement more OperationType cases
			switch (name) {
			case "++":
				kind = UnifiedUnaryOperatorKind.PreIncrementAssign;
				break;
			case "--":
				kind = UnifiedUnaryOperatorKind.PreDecrementAssign;
				break;
			default:
				throw new InvalidOperationException();
			}

			return UnifiedUnaryOperator.Create(name, kind);
		}

		public static UnifiedUnaryOperator CreatePostfixUnaryOperator(XElement node) {
			var name = node.Value;
			UnifiedUnaryOperatorKind kind;

			switch (name) {
			case "++":
				kind = UnifiedUnaryOperatorKind.PostIncrementAssign;
				break;
			case "--":
				kind = UnifiedUnaryOperatorKind.PostDecrementAssign;
				break;
			default:
				throw new InvalidOperationException();
			}

			return UnifiedUnaryOperator.Create(name, kind);
		}

		public static UnifiedBinaryOperator CreateBinaryOperator(XElement node) {
			//TODO implement more OperatorType cases
			var name = node.Value;
			UnifiedBinaryOperatorKind kind;

			switch (name) {
				//Arithmetic
			case "+":
				kind = UnifiedBinaryOperatorKind.Add;
				break;
			case "-":
				kind = UnifiedBinaryOperatorKind.Subtract;
				break;
			case "*":
				kind = UnifiedBinaryOperatorKind.Multiply;
				break;
			case "/":
				kind = UnifiedBinaryOperatorKind.Divide;
				break;
			case "%":
				kind = UnifiedBinaryOperatorKind.Modulo;
				break;
				//Shift
			case "<<":
				kind = UnifiedBinaryOperatorKind.ArithmeticLeftShift;
				break;
			case ">>":
				kind = UnifiedBinaryOperatorKind.ArithmeticRightShift;
				break;
				//Comparison
			case ">":
				kind = UnifiedBinaryOperatorKind.GreaterThan;
				break;
			case ">=":
				kind = UnifiedBinaryOperatorKind.GreaterThanOrEqual;
				break;
			case "<":
				kind = UnifiedBinaryOperatorKind.LessThan;
				break;
			case "<=":
				kind = UnifiedBinaryOperatorKind.LessThanOrEqual;
				break;
			case "==":
				kind = UnifiedBinaryOperatorKind.Equal;
				break;
			case "!=":
				kind = UnifiedBinaryOperatorKind.NotEqual;
				break;
				//Logocal
			case "&&":
				kind = UnifiedBinaryOperatorKind.AndAlso;
				break;
			case "||":
				kind = UnifiedBinaryOperatorKind.OrElse;
				break;
				//Bit
			case "&":
				kind = UnifiedBinaryOperatorKind.And;
				break;
			case "|":
				kind = UnifiedBinaryOperatorKind.Or;
				break;
			case "^":
				kind = UnifiedBinaryOperatorKind.ExclusiveOr;
				break;
				//Assignment
			case "=":
				kind = UnifiedBinaryOperatorKind.Assign;
				break;
			case "+=":
				kind = UnifiedBinaryOperatorKind.AddAssign;
				break;
			case "-=":
				kind = UnifiedBinaryOperatorKind.SubtractAssign;
				break;
			case "*=":
				kind = UnifiedBinaryOperatorKind.MultiplyAssign;
				break;
			case "/=":
				kind = UnifiedBinaryOperatorKind.DivideAssign;
				break;
			case "%=":
				kind = UnifiedBinaryOperatorKind.ModuloAssign;
				break;
			default:
				throw new InvalidOperationException();
			}

			return UnifiedBinaryOperator.Create(name, kind);
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
			case "statementBlock":
				return CreateBlock(element);
			case "variableStatement":
				return CreateVariableStatementList(element);
			case "ifStatement":
				return CreateIf(element);
			case "returnStatement":
				return CreateReturn(element);
			case "iterationStatement":
				return CreateIteration(element);
			case "switchStatement":
				return CreateSwitch(element);
			default:
				throw new NotImplementedException();
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
			case "whileStatement":
				return CreateWhile(child);
			case "forStatement":
				return CreateFor(child);
			case "forInStatement":
				return CreateForeach(child);
			case "doWhileStatement":
				return CreateDoWhile(child);
			default:
				throw new NotImplementedException();
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
					UnifiedBlock.Create(
							new[] {
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

			if (false /*TODO 以下にfunctionExpressionを持つ場合はクラスを返す*/) {
				return
						UnifiedClassDefinition.Create(UnifiedClassKind.Class, null, UnifiedIdentifier.CreateType(
								node.Element("Identifier").Value), null, null, null);
			}
			return UnifiedVariableDefinition.CreateSingle(
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
							.SelectMany(
									e =>
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
					(UnifiedBlock)CreateStatement(node.Element("statement")),
					(UnifiedBlock)CreateStatement(node.Elements("statement").ElementAt(1)));
		}

		public static UnifiedWhile CreateWhile(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name.LocalName == "whileStatement");
			/*
			 * whileStatement
				: 'while' LT!* '(' LT!* expression LT!* ')' LT!* statement
			 */

			return UnifiedWhile.Create(
					CreateExpression(node.Element("expression")), UnifiedBlock.Create(
							new[] {
									CreateStatement(node.Element("statement"))
							}));
		}

		public static UnifiedSwitch CreateSwitch(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name.LocalName == "switchStatement");
			/*
			 * switchStatement
				: 'switch' LT!* '(' LT!* expression LT!* ')' LT!* caseBlock 
			 */

			return UnifiedSwitch.Create(
					CreateExpression(node.Element("expression")),
					CreateCaseCollection(node.Element("caseBlock")));
		}

		public static UnifiedCaseCollection CreateCaseCollection(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name.LocalName == "caseBlock");
			/*
			 * caseBlock
				: '{' (LT!* caseClause)* (LT!* defaultClause (LT!* caseClause)*)? LT!* '}'
			 */

			return UnifiedCaseCollection.Create(node.Elements().Select(CreateCase));
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

			var body = UnifiedBlock.Create(
					node
							.Element("statementList")
							.Elements("statement")
							.Select(CreateStatement).ToList()
					);

			if (node.Name.LocalName == "caseClause") {
				return UnifiedCase.Create(
						CreateExpression(node.Element("expression")), body);
			}
			//else
			return UnifiedCase.Create(body);
		}

		public static UnifiedSpecialExpression CreateReturn(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name.LocalName == "returnStatement");
			/*
			 * returnStatement
				: 'return' expression? (LT | ';') 
			 */

			if (node.Element("expression") != null) {
				return
						UnifiedSpecialExpression.CreateReturn(
								CreateExpression(node.Element("expression")));
			} else {
				return UnifiedSpecialExpression.CreateReturn();
			}
		}

		#endregion

		#region Function

		public static UnifiedFunctionDefinition CreateFunction(XElement node) {
			return UnifiedFunctionDefinition.CreateFunction(
					node.Element("Identifier").Value,
					CreateParameterCollection(node),
					CreateFunctionBody(node.Element("functionBody")));
		}

		public static UnifiedArgumentCollection CreateArgumentCollection(
				XElement node) {
			return UnifiedArgumentCollection.Create(
					node.Element("arguments")
							.Elements()
							.Where(e => e.Name.LocalName != "TOKEN")
							.Select(e2 => CreateArgument(e2))
					);
		}

		public static UnifiedArgument CreateArgument(XElement node) {
			return UnifiedArgument.Create(CreateExpression(node));
		}

		public static UnifiedParameterCollection CreateParameterCollection(
				XElement node) {
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
			case "functionDeclaration":
				return CreateFunction(node.Elements().First());
			case "statement":
				return CreateStatement(node.Elements().First());
			default:
				throw new InvalidOperationException();
			}
		}

		public static UnifiedProgram CreateModel(string source) {
			Contract.Requires(source != null);
			var ast = JavaScriptCodeToXml.Instance.Generate(source);
			return CreateProgram(ast);
		}
	}
}