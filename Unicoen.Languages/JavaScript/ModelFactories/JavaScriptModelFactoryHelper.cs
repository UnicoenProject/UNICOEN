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
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Xml.Linq;
using Mocomoco.Xml.Linq;
using Unicoen.Core.Model;
using Unicoen.Core.Processor;

// ReSharper disable InvocationIsSkipped

namespace Unicoen.Languages.JavaScript.ModelFactories {
	public static class JavaScriptModelFactoryHelper {
		public static Dictionary<string, UnifiedBinaryOperator> Sign2BinaryOperator;

		public static Dictionary<string, UnifiedUnaryOperator>
				Sign2PrefixUnaryOperator;

		static JavaScriptModelFactoryHelper() {
			Sign2BinaryOperator =
					ModelFactoryHelper.CreateBinaryOperatorDictionary();
			Sign2PrefixUnaryOperator =
					ModelFactoryHelper.CreatePrefixUnaryOperatorDictionaryForJava();
		}

		public static UnifiedProgram CreateProgram(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "program");
			/*
			 * program
			 *  	: LT!* sourceElements LT!* EOF!
			 */

			return UnifiedProgram.Create(
					CreateSourceElements(node.Element("sourceElements")).ToBlock());
		}

		public static IEnumerable<IUnifiedExpression> CreateSourceElements(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "sourceElements");
			/*
			 * sourceElements
			 *  	: sourceElement (LT!* sourceElement)*
			 */

			return node.Elements("sourceElement")
					.SelectMany(CreateSourceElement);
		}

		public static IEnumerable<IUnifiedExpression> CreateSourceElement(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "sourceElement");
			/*
			 * sourceElement
			 *		: functionDeclaration
			 *		| statement
			 */

			var first = node.NthElement(0);
			switch (first.Name()) {
			case "functionDeclaration":
				yield return CreateFunctionDeclaration(first);
				break;
			case "statement":
				foreach (var stmt in CreateStatement(first)) {
					yield return stmt;
				}
				break;
			default:
				throw new InvalidOperationException();
			}
		}

		public static UnifiedFunctionDefinition CreateFunctionDeclaration(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "functionDeclaration");
			/*
			 * functionDeclaration
			 *		: 'function' LT!* Identifier LT!* formalParameterList LT!* functionBody
			 */

			var name = node.Element("Identifier").Value;
			var parameters =
					CreateFormalParameterList(node.Element("formalParameterList"));
			var body = CreateFunctionBody(node.Element("functionBody"));

			return UnifiedFunctionDefinition.Create(
					null, UnifiedModifierCollection.Create(), null, null,
					UnifiedVariableIdentifier.Create(name), parameters,
					null, body);
			//関数定義をnewするとオブジェクトが生成されるが、
			//定義段階ではオブジェクトとして宣言されたのか関数として定義されたのか判別できないため、
			//共通コードモデルではUnifiedFunctionとして扱う
		}

		public static IUnifiedExpression CreateFunctionExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "functionExpression");
			/*
			 * functionExpression
			 *		: 'function' LT!* Identifier? LT!* formalParameterList LT!* functionBody
			 */

			//名前をつけられるが、無名関数として定義する場合にその識別子で参照はできない
			var name = node.Element("Identifier") != null
			           		? node.Element("Identifier").Value : null;
			var parameters =
					CreateFormalParameterList(node.Element("formalParameterList"));
			var body = CreateFunctionBody(node.Element("functionBody"));

			return UnifiedLambda.Create(
					null, null,
					UnifiedVariableIdentifier.Create(name), parameters,
					body);
		}

		public static UnifiedParameterCollection CreateFormalParameterList(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "formalParameterList");
			/*
			 * formalParameterList
			 *		: '(' (LT!* Identifier (LT!* ',' LT!* Identifier)*)? LT!* ')'
			 */

			var parameters =
					node.Elements("Identifier").Select(
							e => UnifiedParameter.Create(
									null,
									null, null,
									UnifiedVariableIdentifier.Create(e.Value).
											ToCollection(),
									null)).
							ToCollection();
			return parameters;
		}

		public static UnifiedBlock CreateFunctionBody(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "functionBody");
			/*
			 * functionBody
			 *		: '{' LT!* sourceElements? LT!* '}'
			 */

			var sourceElementsNode = node.Element("sourceElements");
			return sourceElementsNode != null
			       		? UnifiedBlock.Create(
			       				CreateSourceElements(sourceElementsNode))
			       		: UnifiedBlock.Create();
		}

		public static IEnumerable<IUnifiedExpression> CreateStatement(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "statement");
			/*
			 * statement
			 *		: statementBlock
			 *		| variableStatement
			 *		| emptyStatement
			 *		| expressionStatement
			 *		| ifStatement
			 *		| iterationStatement
			 *		| continueStatement
			 *		| breakStatement
			 *		| returnStatement
			 *		| withStatement
			 *		| labelledStatement
			 *		| switchStatement
			 *		| throwStatement
			 *		| tryStatement
			 */

			var first = node.NthElement(0);
			switch (first.Name()) {
			case "statementBlock":
				yield return CreateStatementBlock(first);
				break;
			case "variableStatement":
				yield return CreateVariableStatement(first);
				break;
			case "emptyStatement":
				yield return CreateEmptyStatement(first);
				break;
			case "expressionStatement":
				yield return CreateExpressionStatement(first);
				break;
			case "ifStatement":
				yield return CreateIfStatement(first);
				break;
			case "iterationStatement":
				yield return CreateIterationStatement(first);
				break;
			case "continueStatement":
				yield return CreateContinueStatement(first);
				break;
			case "breakStatement":
				yield return CreateBreakStatement(first);
				break;
			case "returnStatement":
				yield return CreateReturnStatement(first);
				break;
			case "withStatement":
				yield return CreateWithStatement(first);
				break;
			case "labelledStatement":
				foreach (var stmt in CreateLabelledStatement(first)) {
					yield return stmt;
				}
				break;
			case "switchStatement":
				yield return CreateSwitchStatement(first);
				break;
			case "throwStatement":
				yield return CreateThrowStatement(first);
				break;
			case "tryStatement":
				yield return CreateTryStatement(first);
				break;
			default:
				throw new InvalidOperationException();
			}
		}

		public static UnifiedBlock CreateStatementBlock(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "statementBlock");
			/*
			 * statementBlock
			 *		: '{' LT!* statementList? LT!* '}'
			 */

			var statementList = node.Element("statementList") != null
			                    		? CreateStatementList(node.Element("statementList"))
			                    		: null;
			return UnifiedBlock.Create(statementList);
		}

		public static IEnumerable<IUnifiedExpression> CreateStatementList(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "statementList");
			/*
			 * statementList
			 *		: statement (LT!* statement)*
			 */
			return node.Elements("statement").SelectMany(CreateStatement);
		}

		public static IUnifiedExpression CreateVariableStatement(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "variableStatement");
			/*
			 * variableStatement
			 *		: 'var' LT!* variableDeclarationList statementEnd
			 */

			return CreateVariableDeclarationList(node.Element("variableDeclarationList"));
		}

		public static UnifiedVariableDefinitionList
				CreateVariableDeclarationList(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "variableDeclarationList");
			/*
			 * variableDeclarationList
			 *		: variableDeclaration (LT!* ',' LT!* variableDeclaration)*
			 */

			var declarators =
					node.Elements("variableDeclaration").Select(CreateVariableDeclaration);

			return UnifiedVariableDefinitionList.Create(declarators);
		}

		public static UnifiedVariableDefinitionList
				CreateVariableDeclarationListNoIn(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "variableDeclarationListNoIn");
			/*
			 * variableDeclarationListNoIn
			 *		: variableDeclarationNoIn (LT!* ',' LT!* variableDeclarationNoIn)*
			 */
			var declarators =
					node.Elements("variableDeclarationNoIn").Select(
							CreateVariableDeclarationNoIn);

			return UnifiedVariableDefinitionList.Create(declarators);
		}

		public static UnifiedVariableDefinition
				CreateVariableDeclaration(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "variableDeclaration");
			/*
			 * variableDeclaration
			 *		: Identifier LT!* initialiser?
			 */

			var name = UnifiedVariableIdentifier.Create(node.NthElement(0).Value);
			var init = node.Element("initialiser") != null
			           		? CreateInitialiser(node.Element("initialiser")) : null;

			return UnifiedVariableDefinition.Create(
					name: name,
					initialValue: init
					);
		}

		public static UnifiedVariableDefinition
				CreateVariableDeclarationNoIn(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "variableDeclarationNoIn");
			/*
			 * variableDeclarationNoIn
			 *		: Identifier LT!* initialiserNoIn?
			 */

			var name = UnifiedVariableIdentifier.Create(node.NthElement(0).Value);
			var init = node.Element("initialiserNoIn") != null
			           		? CreateInitialiserNoIn(node.Element("initialiserNoIn")) : null;

			return UnifiedVariableDefinition.Create(
					name: name,
					initialValue: init
					);
		}

		public static IUnifiedExpression CreateInitialiser(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "initialiser");
			/*
			 * initialiser
			 *		: '=' LT!* assignmentExpression
			 */

			return CreateAssignmentExpression(node.Element("assignmentExpression"));
		}

		public static IUnifiedExpression CreateInitialiserNoIn(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "initialiserNoIn");
			/*
			 * initialiserNoIn
			 *		: '=' LT!* assignmentExpressionNoIn
			 */

			return CreateAssignmentExpressionNoIn(
					node.Element("assignmentExpressionNoIn"));
		}

		public static IUnifiedExpression CreateEmptyStatement(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "emptyStatement");
			/*
			 * emptyStatement
			 *		: ';'
			 */

			return UnifiedBlock.Create();
		}

		public static IUnifiedExpression CreateExpressionStatement(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "expressionStatement");
			/*
			 * expressionStatement
			 * : expression statementEnd
			 */

			//var first = node.FirstElement();
			//if (first.Name() == "expression")
			return CreateExpression(node.NthElement(0));
			//return CreateExpressionStatement(node.NthElement(1));
		}

		public static UnifiedIf CreateIfStatement(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "ifStatement");
			/*
			 * ifStatement
			 *		: 'if' LT!* '(' LT!* expression LT!* ')' LT!* statement (LT!* 'else' LT!* statement)?
			 */

			var cond = CreateExpression(node.Element("expression"));
			var trueBody = UnifiedBlock.Create(
					CreateStatement(node.Element("statement")));
			var falseBody = node.Elements("statement").Count() == 2
			                		? UnifiedBlock.Create(
			                				CreateStatement(node.Elements("statement").ElementAt(1)))
			                		: null;

			return UnifiedIf.Create(cond, trueBody, falseBody);
		}

		public static IUnifiedExpression CreateIterationStatement(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "iterationStatement");
			/*
			 * iterationStatement
			 *		: doWhileStatement
			 *		| whileStatement
			 *		| forStatement
			 *		| forInStatement
			 */

			var first = node.NthElement(0);
			switch (first.Name()) {
			case "doWhileStatement":
				return CreateDoWhileStatement(first);
			case "whileStatement":
				return CreateWhileStatement(first);
			case "forStatement":
				return CreateForStatement(first);
			case "forInStatement":
				return CreateForInStatement(first);
			default:
				throw new InvalidOperationException();
			}
		}

		public static UnifiedDoWhile CreateDoWhileStatement(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "doWhileStatement");
			/*
			 * doWhileStatement
			 *		: 'do' LT!* statement LT!* 'while' LT!* '(' expression ')' statementEnd
			 */

			var body = UnifiedBlock.Create(CreateStatement(node.Element("statement")));
			var cond = CreateExpression(node.Element("expression"));

			return UnifiedDoWhile.Create(body, cond);
		}

		public static UnifiedWhile CreateWhileStatement(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "whileStatement");
			/*
			 * whileStatement
			 *		: 'while' LT!* '(' LT!* expression LT!* ')' LT!* statement
			 */

			var body = UnifiedBlock.Create(CreateStatement(node.Element("statement")));
			var cond = CreateExpression(node.Element("expression"));

			return UnifiedWhile.Create(cond, body);
		}

		public static UnifiedFor CreateForStatement(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "forStatement");
			/*
			 * forStatement
			 *		: 'for' LT!* '(' (LT!* forStatementInitialiserPart)? LT!* ';' (LT!* expression)? LT!* ';' (LT!* expression)? LT!* ')' LT!* statement
			 */

			var init = node.HasElement("forStatementInitialiserPart")
			           		? CreateForStatementInitialiserPart(
			           				node.Element("forStatementInitialiserPart")) : null;

			//expressionを区別できないので、セミコロンの位置から条件なのかステップなのかを判断
			var semicolons = node.Elements().Where(e => e.Value == ";");
			var first = semicolons.ElementAt(0).NextElement();
			var second = semicolons.ElementAt(1).NextElement();

			var cond = first.Name() == "expression" ? CreateExpression(first) : null;
			var step = second.Name() == "expression" ? CreateExpression(second) : null;
			var body = UnifiedBlock.Create(CreateStatement(node.Element("statement")));

			return UnifiedFor.Create(init, cond, step, body);
		}

		public static IUnifiedExpression CreateForStatementInitialiserPart(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "forStatementInitialiserPart");
			/*
			 * forStatementInitialiserPart
			 *		: expressionNoIn
			 *		| 'var' LT!* variableDeclarationListNoIn
			 */

			if (node.NthElement(0).Name() == "expressionNoIn")
				return CreateExpressionNoIn(node.NthElement(0));
			if (node.HasElement("variableDeclarationListNoIn"))
				return
						CreateVariableDeclarationListNoIn(
								node.Element("variableDeclarationListNoIn"));
			throw new InvalidOperationException();
		}

		public static UnifiedForeach CreateForInStatement(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "forInStatement");
			/*
			 * forInStatement
			 *		: 'for' LT!* '(' LT!* forInStatementInitialiserPart LT!* 'in' LT!* expression LT!* ')' LT!* statement
			 */

			var element =
					CreateForInStatementInitialiserPart(
							node.Element("forInStatementInitialiserPart"));
			var set = CreateExpression(node.Element("expression"));
			var body = UnifiedBlock.Create(CreateStatement(node.Element("statement")));

			return UnifiedForeach.Create(element, set, body);
		}

		public static IUnifiedExpression CreateForInStatementInitialiserPart(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "forInStatementInitialiserPart");
			/*
			 * forInStatementInitialiserPart
			 *		: leftHandSideExpression
			 *		| 'var' LT!* variableDeclarationNoIn
			 */

			//左辺がCall or Newになる場合のコードはまだ未確認
			if (node.NthElement(0).Name() == "leftHandSideExpression")
				return CreateLeftHandSideExpression(node.NthElement(0));

			if (node.HasElement("variableDeclarationNoIn"))
				return CreateVariableDeclarationNoIn(
						node.Element("variableDeclarationNoIn"));
			throw new InvalidOperationException();
		}

		public static IUnifiedExpression CreateContinueStatement(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "continueStatement");
			/*
			 * continueStatement
			 *		: 'continue' Identifier? statementEnd
			 */

			var identifier = node.HasElement("Identifier")
			                 		? UnifiedVariableIdentifier.Create(
			                 				node.Element("Identifier").Value) : null;

			return UnifiedContinue.Create(identifier);
		}

		public static IUnifiedExpression CreateBreakStatement(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "breakStatement");
			/*
			 * breakStatement
			 *		: 'break' Identifier? statementEnd
			 */
			var identifier = node.HasElement("Identifier")
			                 		? UnifiedVariableIdentifier.Create(
			                 				node.Element("Identifier").Value) : null;

			return UnifiedBreak.Create(identifier);
		}

		public static IUnifiedExpression CreateReturnStatement(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "returnStatement");
			/*
			 * returnStatement
			 *		: 'return' expression? statementEnd
			 */
			var expression = node.HasElement("expression")
			                 		? CreateExpression(node.Element("expression")) : null;

			return UnifiedReturn.Create(expression);
		}

		public static IUnifiedExpression CreateWithStatement(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "withStatement");
			/*
			 * withStatement
			 *		: 'with' LT!* '(' LT!* expression LT!* ')' LT!* statement
			 */
			var exp = CreateExpression(node.Element("expression"));
			var body = UnifiedBlock.Create(CreateStatement(node.Element("statement")));

			return UnifiedWith.Create(exp, body);
		}

		public static IEnumerable<IUnifiedExpression> CreateLabelledStatement(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "labelledStatement");
			/*
			 * labelledStatement	
			 *		: Identifier LT!* ':' LT!* statement
			 */
			yield return UnifiedLabel.Create(node.NthElement(0).Value);
			foreach (var stmt in CreateStatement(node.Element("statement"))) {
				yield return stmt;
			}
		}

		public static IUnifiedExpression CreateSwitchStatement(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "switchStatement");
			/*
			 * switchStatement
			 *		: 'switch' LT!* '(' LT!* expression LT!* ')' LT!* caseBlock
			 */

			var value = CreateExpression(node.Element("expression"));
			var cases = CreateCaseBlock(node.Element("caseBlock"));

			return UnifiedSwitch.Create(value, cases);
		}

		public static UnifiedCaseCollection CreateCaseBlock(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "caseBlock");
			/*
			 * caseBlock
			 *		: '{' (LT!* caseClause)* (LT!* defaultClause (LT!* caseClause)*)? LT!* '}'
			 */

			var cases = UnifiedCaseCollection.Create();

			foreach (
					var e in
							node.Elements().Where(e => e.Name().EndsWith("Clause"))
					) {
				cases.Add(
						e.Name() == "caseClause" ? CreateCaseClause(e) : CreateDefaultClause(e));
			}
			return cases;
		}

		public static UnifiedCase CreateCaseClause(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "caseClause");
			/*
			 * caseClause
			 *		: 'case' LT!* expression LT!* ':' LT!* statementList?
			 */
			var cond = CreateExpression(node.Element("expression"));
			var body = node.HasElement("statementList")
			           		? CreateStatementList(node.Element("statementList")) : null;

			return UnifiedCase.Create(cond, UnifiedBlock.Create(body));
		}

		public static UnifiedCase CreateDefaultClause(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "defaultClause");
			/*
			 * defaultClause
			 *		: 'default' LT!* ':' LT!* statementList?
			 */
			var body = node.HasElement("statementList")
			           		? CreateStatementList(node.Element("statementList")) : null;

			return UnifiedCase.Create(null, UnifiedBlock.Create(body));
		}

		public static IUnifiedExpression CreateThrowStatement(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "throwStatement");
			/*
			 * throwStatement
			 *		: 'throw' expression statementEnd
			 */

			return UnifiedThrow.Create(
					CreateExpression(node.Element("expression")));
		}

		public static IUnifiedExpression CreateTryStatement(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "tryStatement");
			/*
			 * tryStatement
			 *		: 'try' LT!* statementBlock LT!* (finallyClause | catchClause (LT!* finallyClause)?)
			 */

			var body = CreateStatementBlock(node.Element("statementBlock"));
			var catches = node.HasElement("catchClause")
			              		? CreateCatchClause(node.Element("catchClause")) : null;
			var finallyBody = node.HasElement("finallyClause")
			                  		? CreateFinallyClause(node.Element("finallyClause"))
			                  		: null;

			return UnifiedTry.Create(body, catches, null, finallyBody);
		}

		public static UnifiedCatchCollection CreateCatchClause(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "catchClause");
			/*
			 * catchClause
			 *		: 'catch' LT!* '(' LT!* Identifier LT!* ')' LT!* statementBlock
			 */

			var matchers =
					UnifiedMatcher.Create(
							null, null,
							UnifiedVariableIdentifier.Create(node.Element("Identifier").Value), null)
							.ToCollection();
			var body = CreateStatementBlock(node.Element("statementBlock"));
			var catchClause = UnifiedCatch.Create(matchers, body);

			return catchClause.ToCollection();
		}

		public static UnifiedBlock CreateFinallyClause(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "finallyClause");
			/*
			 * finallyClause
			 *		: 'finally' LT!* statementBlock
			 */

			return CreateStatementBlock(node.Element("statementBlock"));
		}

		public static IUnifiedExpression CreateExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "expression");
			/*
			 * expression
			 *		: assignmentExpression (LT!* ',' LT!* assignmentExpression)*
			 */
			var expressions = node.Elements("assignmentExpression")
					.Select(CreateAssignmentExpression)
					.ToList();
			// 式が１つの場合はIUnifiedExpressionとして、複数の場合はUnifiedBlockとして返す
			if (expressions.Count == 1)
				return expressions[0];
			return UnifiedBlock.Create(expressions);
		}

		public static IUnifiedExpression CreateExpressionNoIn(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "expressionNoIn");
			/*
			 * expressionNoIn
			 *		: assignmentExpressionNoIn (LT!* ',' LT!* assignmentExpressionNoIn)*
			 */
			var expressions = node.Elements("assignmentExpressionNoIn")
					.Select(CreateAssignmentExpressionNoIn)
					.ToList();
			// 式が１つの場合はIUnifiedExpressionとして、複数の場合はUnifiedBlockとして返す
			if (expressions.Count == 1)
				return expressions[0];
			return UnifiedBlock.Create(expressions);
		}

		public static IUnifiedExpression CreateAssignmentExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "assignmentExpression");
			/*
			 * assignmentExpression
			 *		: conditionalExpression
			 *		| leftHandSideExpression LT!* assignmentOperator LT!* assignmentExpression
			 */

			var first = node.NthElement(0);
			switch (first.Name()) {
			case "conditionalExpression":
				return CreateConditionalExpression(first);
			case "leftHandSideExpression":
				return UnifiedBinaryExpression.Create(
						CreateLeftHandSideExpression(first),
						CreateAssignmentOperator(node.Element("assignmentOperator")),
						CreateAssignmentExpression(node.Element("assignmentExpression")));
			default:
				throw new InvalidOperationException();
			}
		}

		public static IUnifiedExpression CreateAssignmentExpressionNoIn(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "assignmentExpressionNoIn");
			/*
			 * assignmentExpressionNoIn
			 *		: conditionalExpressionNoIn
			 *		| leftHandSideExpression LT!* assignmentOperator LT!* assignmentExpressionNoIn
			 */

			var first = node.NthElement(0);
			switch (first.Name()) {
			case "conditionalExpressionNoIn":
				return CreateConditionalExpressionNoIn(first);
			case "leftHandSideExpression":
				return UnifiedBinaryExpression.Create(
						CreateLeftHandSideExpression(first),
						CreateAssignmentOperator(node.Element("assignmentOperator")),
						CreateAssignmentExpressionNoIn(node.Element("assignmentExpressionNoIn")));
			default:
				throw new InvalidOperationException();
			}
		}

		public static IUnifiedExpression CreateLeftHandSideExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "leftHandSideExpression");
			/*
			 * leftHandSideExpression
			 *		: callExpression
			 *		| newExpression
			 */

			var first = node.NthElement(0);
			switch (first.Name()) {
			case "callExpression":
				return CreateCallExpression(first);
			case "newExpression":
				return CreateNewExpression(first);
			default:
				throw new InvalidOperationException();
			}
		}

		public static IUnifiedExpression CreateNewExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "newExpression");
			/*
			 * newExpression
			 *		: memberExpression
			 *		| 'new' LT!* newExpression
			 */

			/* コード例
			 *	function r() {
			 *		this.f = function() {
			 *			return 3;
			 *		}
			 *	}
			 *	new new r().f
			 */

			if (node.NthElement(0).Name() == "memberExpression")
				return CreateMemberExpression(node.NthElement(0));

			return
					UnifiedNew.Create(
							UnifiedType.Create(
									CreateNewExpression(node.Element("newExpression"))));
		}

		public static IUnifiedExpression CreateMemberExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "memberExpression");
			/*
			 * memberExpression
			 *		: (primaryExpression
			 *			| functionExpression
			 *			| 'new' LT!* memberExpression LT!* arguments)
			 *		  (LT!* memberExpressionSuffix)*
			 */

			IUnifiedExpression exp = null;
			var first = node.NthElement(0);

			switch (first.Name()) {
			case "primaryExpression":
				exp = CreatePrimaryExpression(first);
				break;
			case "functionExpression":
				exp = CreateFunctionExpression(first);
				break;
			case "TOKEN": //case 'new'
				exp =
						UnifiedNew.Create(
								CreateMemberExpression(node.Element("memberExpression")),
								CreateArguments(node.Element("arguments")));
				break;
			default:
				throw new InvalidOperationException();
			}

			//TODO Javaを参考に移行しただけなので、要確認
			exp = node.Elements("memberExpressionSuffix").Aggregate(
					exp, CreateMemberExpressionSuffix);
			return exp;
		}

		public static IUnifiedExpression CreateMemberExpressionSuffix(
				IUnifiedExpression prefix, XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "memberExpressionSuffix");
			/*
			 * memberExpressionSuffix
			 *		: indexSuffix
			 *		| propertyReferenceSuffix
			 */
			var first = node.NthElement(0);
			switch (first.Name()) {
			case "indexSuffix":
				return CreateIndexSuffix(prefix, first);
			case "propertyReferenceSuffix":
				return CreatePropertyReferenceSuffix(prefix, first);
			default:
				throw new InvalidOperationException();
			}
		}

		public static IUnifiedExpression CreateCallExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "callExpression");
			/*
			 * callExpression
			 *		: memberExpression LT!* arguments (LT!* callExpressionSuffix)*
			 */

			//実際のUnifiedCallインスタンスの生成はCreateArguments内で行われる
			IUnifiedExpression exp =
					UnifiedCall.Create(
							CreateMemberExpression(node.Element("memberExpression")),
							CreateArguments(
									node.Element("arguments")));
			exp = node.Elements("callExpressionSuffix").Aggregate(
					exp, CreateCallExpressionSuffix);
			return exp;
		}

		public static IUnifiedExpression CreateCallExpressionSuffix(
				IUnifiedExpression prefix, XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "callExpressionSuffix");
			/*
			 * callExpressionSuffix
			 *		: arguments
			 *		| indexSuffix
			 *		| propertyReferenceSuffix
			 */
			var first = node.NthElement(0);
			switch (first.Name()) {
			case "arguments":
				return UnifiedCall.Create(prefix, CreateArguments(first));
			case "indexSuffix":
				return CreateIndexSuffix(prefix, first);
			case "propertyReferenceSuffix":
				return CreatePropertyReferenceSuffix(prefix, first);
			default:
				throw new InvalidOperationException();
			}
		}

		public static UnifiedArgumentCollection CreateArguments(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "arguments");
			/*
			 * arguments
			 *		: '(' (LT!* assignmentExpression (LT!* ',' LT!* assignmentExpression)*)? LT!* ')'
			 */

			var arguments = node.Elements("assignmentExpression").Select(
					e => UnifiedArgument.Create(null, null, CreateAssignmentExpression(e))).
					ToCollection();
			return arguments.ToCollection();
		}

		public static UnifiedIndexer CreateIndexSuffix(
				IUnifiedExpression prefix, XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "indexSuffix");
			/*
			 * indexSuffix
			 *		: '[' LT!* expression LT!* ']'
			 */

			return UnifiedIndexer.Create(
					prefix,
					UnifiedArgument.Create(
							null, null, CreateExpression(node.Element("expression"))).
							ToCollection());
		}

		public static UnifiedProperty CreatePropertyReferenceSuffix(
				IUnifiedExpression prefix, XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "propertyReferenceSuffix");
			/*
			 * propertyReferenceSuffix
			 *		: '.' LT!* Identifier
			 */
			return UnifiedProperty.Create(
					".", prefix,
					UnifiedVariableIdentifier.Create(node.Element("Identifier").Value));
		}

		public static UnifiedBinaryOperator CreateAssignmentOperator(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "assignmentOperator");
			/*
			 * assignmentOperator
			 *		: '=' | '*=' | '/=' | '%=' | '+=' | '-=' | '<<=' | '>>=' | '>>>=' | '&=' | '^=' | '|='
			 */

			var name = node.Value;
			UnifiedBinaryOperatorKind kind;
			switch (name) {
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
			case "&=":
				kind = UnifiedBinaryOperatorKind.AndAssign;
				break;
			case "|=":
				kind = UnifiedBinaryOperatorKind.OrAssign;
				break;
			case "^=":
				kind = UnifiedBinaryOperatorKind.ExclusiveOrAssign;
				break;
			case "%=":
				kind = UnifiedBinaryOperatorKind.ModuloAssign;
				break;
			case "<<=":
				kind = UnifiedBinaryOperatorKind.LogicalLeftShiftAssign;
				break;
			case ">>>=":
				kind = UnifiedBinaryOperatorKind.LogicalRightShiftAssign;
				break;
			case ">>=":
				kind = UnifiedBinaryOperatorKind.ArithmeticRightShiftAssign;
				break;
			default:
				throw new IndexOutOfRangeException();
			}
			return UnifiedBinaryOperator.Create(name, kind);
		}

		public static IUnifiedExpression CreateConditionalExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "conditionalExpression");
			/*
			 * conditionalExpression
			 *		: logicalORExpression (LT!* '?' LT!* assignmentExpression LT!* ':' LT!* assignmentExpression)?
			 */
			if (node.HasElement("assignmentExpression")) {
				return UnifiedTernaryExpression.Create(
						CreateLogicalORExpression(node.Element("logicalORExpression")),
						CreateAssignmentExpression(node.Element("assignmentExpression")),
						CreateAssignmentExpression(
								node.Elements("assignmentExpression").ElementAt(1)));
			}
			return CreateLogicalORExpression(node.NthElement(0));
		}

		public static IUnifiedExpression CreateConditionalExpressionNoIn(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "conditionalExpressionNoIn");
			/*
			 * conditionalExpressionNoIn
			 *		: logicalORExpressionNoIn (LT!* '?' LT!* assignmentExpressionNoIn LT!* ':' LT!* assignmentExpressionNoIn)?
			 */
			if (node.HasElement("assignmentExpressionNoIn")) {
				return UnifiedTernaryExpression.Create(
						CreateLogicalORExpressionNoIn(node.Element("logicalORExpressionNoIn")),
						CreateAssignmentExpressionNoIn(node.Element("assignmentExpressionNoIn")),
						CreateAssignmentExpressionNoIn(
								node.Elements("assignmentExpressionNoIn").ElementAt(1)));
			}
			return CreateLogicalORExpressionNoIn(node.NthElement(0));
		}

		public static IUnifiedExpression CreateLogicalORExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "logicalORExpression");
			/*
			 * logicalORExpression
			 *		: logicalANDExpression (LT!* '||' LT!* logicalANDExpression)*
			 */
			return ModelFactoryHelper.CreateBinaryExpression(
					node, CreateLogicalANDExpression, Sign2BinaryOperator);
		}

		public static IUnifiedExpression CreateLogicalORExpressionNoIn(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "logicalORExpressionNoIn");
			/*
			 * logicalORExpressionNoIn
			 *		: logicalANDExpressionNoIn (LT!* '||' LT!* logicalANDExpressionNoIn)*
			 */
			return ModelFactoryHelper.CreateBinaryExpression(
					node, CreateLogicalANDExpressionNoIn, Sign2BinaryOperator);
		}

		public static IUnifiedExpression CreateLogicalANDExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "logicalANDExpression");
			/*
			 * logicalANDExpression
			 *		: bitwiseORExpression (LT!* '&&' LT!* bitwiseORExpression)*
			 */
			return ModelFactoryHelper.CreateBinaryExpression(
					node, CreateBitwiseORExpression, Sign2BinaryOperator);
		}

		public static IUnifiedExpression CreateLogicalANDExpressionNoIn(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "logicalANDExpressionNoIn");
			/*
			 * logicalANDExpressionNoIn
			 *		: bitwiseORExpressionNoIn (LT!* '&&' LT!* bitwiseORExpressionNoIn)*
			 */
			return ModelFactoryHelper.CreateBinaryExpression(
					node, CreateBitwiseORExpressionNoIn, Sign2BinaryOperator);
		}

		public static IUnifiedExpression CreateBitwiseORExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "bitwiseORExpression");
			/*
			 * bitwiseORExpression
			 *		: bitwiseXORExpression (LT!* '|' LT!* bitwiseXORExpression)*
			 */
			return ModelFactoryHelper.CreateBinaryExpression(
					node, CreateBitwiseXORExpression, Sign2BinaryOperator);
		}

		public static IUnifiedExpression CreateBitwiseORExpressionNoIn(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "bitwiseORExpressionNoIn");
			/*
			 * bitwiseORExpressionNoIn
			 *		: bitwiseXORExpressionNoIn (LT!* '|' LT!* bitwiseXORExpressionNoIn)*
			 */
			return ModelFactoryHelper.CreateBinaryExpression(
					node, CreateBitwiseXORExpressionNoIn, Sign2BinaryOperator);
		}

		public static IUnifiedExpression CreateBitwiseXORExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "bitwiseXORExpression");
			/*
			 * bitwiseXORExpression
			 *		: bitwiseANDExpression (LT!* '^' LT!* bitwiseANDExpression)*
			 */
			return ModelFactoryHelper.CreateBinaryExpression(
					node, CreateBitwiseANDExpression, Sign2BinaryOperator);
		}

		public static IUnifiedExpression CreateBitwiseXORExpressionNoIn(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "bitwiseXORExpressionNoIn");
			/*
			 * bitwiseXORExpressionNoIn
			 *		: bitwiseANDExpressionNoIn (LT!* '^' LT!* bitwiseANDExpressionNoIn)*
			 */
			return ModelFactoryHelper.CreateBinaryExpression(
					node, CreateBitwiseANDExpressionNoIn, Sign2BinaryOperator);
		}

		public static IUnifiedExpression CreateBitwiseANDExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "bitwiseANDExpression");
			/*
			 * bitwiseANDExpression
			 *		: equalityExpression (LT!* '&' LT!* equalityExpression)*
			 */
			return ModelFactoryHelper.CreateBinaryExpression(
					node, CreateEqualityExpression, Sign2BinaryOperator);
		}

		public static IUnifiedExpression CreateBitwiseANDExpressionNoIn(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "bitwiseANDExpressionNoIn");
			/*
			 * bitwiseANDExpressionNoIn
			 *		: equalityExpressionNoIn (LT!* '&' LT!* equalityExpressionNoIn)*
			 */
			return ModelFactoryHelper.CreateBinaryExpression(
					node, CreateEqualityExpressionNoIn, Sign2BinaryOperator);
		}

		public static IUnifiedExpression CreateEqualityExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "equalityExpression");
			/*
			 * equalityExpression
			 *		: relationalExpression (LT!* ('==' | '!=' | '===' | '!==') LT!* relationalExpression)*
			 */
			//TODO ===演算子などを加える
			return ModelFactoryHelper.CreateBinaryExpression(
					node, CreateRelationalExpression, Sign2BinaryOperator);
		}

		public static IUnifiedExpression CreateEqualityExpressionNoIn(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "equalityExpressionNoIn");
			/*
			 * equalityExpressionNoIn
			 *		: relationalExpressionNoIn (LT!* ('==' | '!=' | '===' | '!==') LT!* relationalExpressionNoIn)*
			 */
			return ModelFactoryHelper.CreateBinaryExpression(
					node, CreateRelationalExpressionNoIn, Sign2BinaryOperator);
		}

		public static IUnifiedExpression CreateRelationalExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "relationalExpression");
			/*
			 * relationalExpression
			 *		: shiftExpression (LT!* ('<' | '>' | '<=' | '>=' | 'instanceof' | 'in') LT!* shiftExpression)*
			 */
			return ModelFactoryHelper.CreateBinaryExpression(
					node, CreateShiftExpression, Sign2BinaryOperator);
		}

		public static IUnifiedExpression CreateRelationalExpressionNoIn(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "relationalExpressionNoIn");
			/*
			 * relationalExpressionNoIn
			 *		: shiftExpression (LT!* ('<' | '>' | '<=' | '>=' | 'instanceof') LT!* shiftExpression)*
			 */
			return ModelFactoryHelper.CreateBinaryExpression(
					node, CreateShiftExpression, Sign2BinaryOperator);
		}

		public static IUnifiedExpression CreateShiftExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "shiftExpression");
			/*
			 * shiftExpression
			 *		: additiveExpression (LT!* ('<<' | '>>' | '>>>') LT!* additiveExpression)*
			 */
			return ModelFactoryHelper.CreateBinaryExpression(
					node, CreateAdditiveExpression, Sign2BinaryOperator);
		}

		public static IUnifiedExpression CreateAdditiveExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "additiveExpression");
			/*
			 * additiveExpression
			 *		: multiplicativeExpression (LT!* ('+' | '-') LT!* multiplicativeExpression)*
			 */
			return ModelFactoryHelper.CreateBinaryExpression(
					node, CreateMultiplicativeExpression, Sign2BinaryOperator);
		}

		public static IUnifiedExpression CreateMultiplicativeExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "multiplicativeExpression");
			/*
			 * multiplicativeExpression
			 *		: unaryExpression (LT!* ('*' | '/' | '%') LT!* unaryExpression)*
			 */
			return ModelFactoryHelper.CreateBinaryExpression(
					node, CreateUnaryExpression, Sign2BinaryOperator);
		}

		public static IUnifiedExpression CreateUnaryExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "unaryExpression");
			/*
			 * unaryExpression
			 *		: postfixExpression
			 *		| ('delete' | 'void' | 'typeof' | '++' | '--' | '+' | '-' | '~' | '!') unaryExpression
			 */
			var first = node.NthElement(0);
			if (first.Name() == "postfixExpression")
				return CreatePostfixExpression(first);
			return
					UnifiedUnaryExpression.Create(
							CreateUnaryExpression(node.NthElement(1)),
							CreatePrefixUnaryOperator(first.Value));
		}

		public static IUnifiedExpression CreatePostfixExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "postfixExpression");
			/*
			 * postfixExpression
			 *		: leftHandSideExpression ('++' | '--')?
			 */

			if (node.Elements().Count() == 2) {
				var ope = node.NthElement(1).Value == "++"
				          		? UnifiedUnaryOperator.Create(
				          				"++", UnifiedUnaryOperatorKind.PostIncrementAssign)
				          		: UnifiedUnaryOperator.Create(
				          				"--", UnifiedUnaryOperatorKind.PostDecrementAssign);
				return
						UnifiedUnaryExpression.Create(
								CreateLeftHandSideExpression(node.NthElement(0)), ope);
			}
			return CreateLeftHandSideExpression(node.NthElement(0));
		}

		public static IUnifiedExpression CreatePrimaryExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "primaryExpression");
			/*
			 * primaryExpression
			 *		: 'this'
			 *		| Identifier
			 *		| literal
			 *		| arrayLiteral
			 *		| objectLiteral
			 *		| '(' LT!* expression LT!* ')'
			 */
			var first = node.NthElement(0);
			if (first.Value == "this")
				return UnifiedVariableIdentifier.Create("this");
			if (first.Value == "(")
				return CreateExpression(node.Element("expression"));

			switch (first.Name()) {
			case "Identifier":
				return UnifiedVariableIdentifier.Create(first.Value);
			case "literal":
				return CreateLiteral(first);
			case "arrayLiteral":
				return CreateArrayLiteral(first);
			case "objectLiteral":
				return CreateObjectLiteral(first);
			default:
				throw new InvalidOperationException();
			}
		}

		public static UnifiedNew CreateArrayLiteral(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "arrayLiteral");
			/*
			 * arrayLiteral
			 *		: '[' LT!* assignmentExpression? (LT!* ',' (LT!* assignmentExpression)?)* LT!* ']'
			 */
			//コード例：var array = [1, 2, 3];
			var list = node.Elements("assignmentExpression")
					.Select(CreateAssignmentExpression)
					.ToArrayLiteral();
			return UnifiedNew.Create(
					UnifiedType.Create(),
					null,
					null,
					list);
		}

		public static UnifiedDictionary CreateObjectLiteral(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "objectLiteral");
			/*
			 * objectLiteral
			 *		: '{' LT!* propertyNameAndValue? (LT!* ',' (LT!* propertyNameAndValue)?)* LT!* '}'
			 */

			//例えばJSONなど
			var keyValues = node.Elements("propertyNameAndValue")
					.Select(CreatePropertyNameAndValue);
			return UnifiedDictionary.Create(keyValues);
		}

		public static UnifiedKeyValue CreatePropertyNameAndValue(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "propertyNameAndValue");
			/*
			 * propertyNameAndValue
			 *		: propertyName LT!* ':' LT!* assignmentExpression
			 */
			// e.g. a : 1, b : function() { }

			//プロパティ宣言をKeyAndValueで代用
			return UnifiedKeyValue.Create(
					CreatePropertyName(node.Element("propertyName")),
					CreateAssignmentExpression(node.Element("assignmentExpression"))
					);
		}

		public static UnifiedIdentifier CreatePropertyName(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "propertyName");
			/*
			 * propertyName
			 *		: Identifier
			 *		| stringLiteral
			 *		| numericLiteral
			 */
			return UnifiedVariableIdentifier.Create(node.NthElement(0).Value);
		}

		public static UnifiedLiteral CreateLiteral(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "literal");
			/*
			 * literal
			 *		: 'null'
			 *		| 'true'
			 *		| 'false'
			 *		| stringliteral
			 *		| numericliteral
			 *		| regularExpressionLiteral
			 */
			var first = node.NthElement(0);
			if (first.Value == "null")
				return UnifiedNullLiteral.Create();
			if (first.Value == "true")
				return UnifiedBooleanLiteral.Create(true);
			if (first.Value == "false")
				return UnifiedBooleanLiteral.Create(false);

			switch (first.Name()) {
			case "stringliteral":
				return CreateStringliteral(first);
			case "numericliteral":
				return CreateNumericliteral(first);
			case "regularExpressionLiteral":
				return CreateRegularExpressionLiteral(first);
			default:
				throw new InvalidOperationException();
			}
		}

		public static UnifiedLiteral CreateRegularExpressionLiteral(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "regularExpressionLiteral");
			/*
			 * regularExpressionLiteral
			 *	: RegularExpressionLiteral
			 * RegularExpressionLiteral
			 *	: '/' RegularExpressionFirstChar RegularExpressionChar* '/' IdentifierPart*
			 */
			// e.g. /abc/g -> value:abc, options:g
			var value = node.Value;
			var lastIndex = value.LastIndexOf('/');
			return
					UnifiedRegularExpressionLiteral.Create(
							value.Substring(1, lastIndex - 1), value.Substring(lastIndex + 1));
		}

		public static UnifiedLiteral CreateNumericliteral(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "numericliteral");
			/*
			 * numericliteral
			 *		: DecimalLiteral
			 *		| HexIntegerLiteral
			 */
			var value = node.Value;
			if (value.StartsWith("0x") || value.Contains("0X"))
				return UnifiedIntegerLiteral.Create(
						BigInteger.Parse(value.Substring(2), NumberStyles.HexNumber),
						UnifiedIntegerLiteralKind.BigInteger);
			if (value.Contains(".") || value.Contains("e") || value.Contains("E"))
				return double.Parse(value).ToLiteral();
			return UnifiedIntegerLiteral.Create(
					BigInteger.Parse(value),
					UnifiedIntegerLiteralKind.BigInteger);
		}

		public static UnifiedLiteral CreateStringliteral(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "stringliteral");
			/*
			 * stringliteral
			 */
			return UnifiedStringLiteral.Create(node.Value);
		}

		private static UnifiedUnaryOperator CreatePrefixUnaryOperator(string name) {
			Contract.Requires(name != null);
			UnifiedUnaryOperatorKind kind;
			switch (name) {
			case "+":
				kind = UnifiedUnaryOperatorKind.UnaryPlus;
				break;
			case "-":
				kind = UnifiedUnaryOperatorKind.Negate;
				break;
			case "++":
				kind = UnifiedUnaryOperatorKind.PreIncrementAssign;
				break;
			case "--":
				kind = UnifiedUnaryOperatorKind.PreDecrementAssign;
				break;
			case "~":
				kind = UnifiedUnaryOperatorKind.OnesComplement;
				break;
			case "!":
				kind = UnifiedUnaryOperatorKind.Not;
				break;
			case "delete":
				kind = UnifiedUnaryOperatorKind.Delete;
				break;
			case "void":
				kind = UnifiedUnaryOperatorKind.Void;
				break;
			case "typeof":
				kind = UnifiedUnaryOperatorKind.Typeof;
				break;
			default:
				throw new InvalidOperationException();
			}
			return UnifiedUnaryOperator.Create(name, kind);
		}
	}
}