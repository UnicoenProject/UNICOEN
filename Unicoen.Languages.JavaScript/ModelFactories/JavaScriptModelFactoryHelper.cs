using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Numerics;
using System.Xml.Linq;
using Code2Xml.Languages.JavaScript.CodeToXmls;
using Mocomoco.Xml.Linq;
using Paraiba.Linq;
using Unicoen.Core.Model;

namespace Unicoen.Languages.JavaScript.ModelFactories {
	public static class JavaScriptModelFactoryHelper {
		public static UnifiedProgram CreateProgram(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "program");
			/*
			 * program
			 *  	: LT!* sourceElements LT!* EOF!
			 */

			return UnifiedProgram.Create(
				CreateSourceElements(node.Element("sourceElements")));
		}

		public static IEnumerable<IUnifiedExpression> CreateSourceElements(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "sourceElements");
			/*
			 * sourceElements
 			 *  	: sourceElement (LT!* sourceElement)*
			 */

			var sourceElements =
					node.Elements("sourceElement").Select(CreateSourceElement);
			return sourceElements;
		}

		public static IUnifiedExpression CreateSourceElement(XElement node)
		{
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
					return CreateFunctionDeclaration(first);
				case "statement":
					return CreateStatement(first);
				default:
					throw new InvalidOperationException();
			}
		}

		public static UnifiedFunctionDefinition CreateFunctionDeclaration(XElement node)
		{
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

			return UnifiedFunctionDefinition.CreateFunction(name, parameters, body);
			//関数定義をnewするとオブジェクトが生成されるが、
			//定義段階ではオブジェクトとして宣言されたのか関数として定義されたのか判別できないため、
			//共通コードモデルではUnifiedFunctionDefinitionとして扱う
		}

		//TODO FunctionExpressionをどう扱うか
		//-> 名前がない場合、祖先をたどって左辺の名前を使うのか
		public static IUnifiedExpression CreateFunctionExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "functionExpression");
			/*
			 * functionExpression
			 *		: 'function' LT!* Identifier? LT!* formalParameterList LT!* functionBody
			 */

			var name = node.Element("Identifier") != null
			           		? node.Element("Identifier").Value : null;
			var parameters =
					CreateFormalParameterList(node.Element("formalParameterList"));
			var body = CreateFunctionBody(node.Element("functionBody"));

			return UnifiedFunctionDefinition.CreateFunction(name, parameters, body);
		}

		public static UnifiedParameterCollection CreateFormalParameterList(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "formalParameterList");
			/*
			 * formalParameterList
			 *		: '(' (LT!* Identifier (LT!* ',' LT!* Identifier)*)? LT!* ')'
			 */

			var parameters =
					node.Elements("Identifier").Select(e => UnifiedParameter.Create(e.Value)).
							ToCollection();
			return parameters;
		}

		public static UnifiedBlock CreateFunctionBody(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "functionBody");
			/*
			 * functionBody
			 *		: '{' LT!* sourceElements LT!* '}'
			 */

			return UnifiedBlock.Create(
				CreateSourceElements(node.Element("sourceElements")));
		}

		public static IUnifiedExpression CreateStatement(XElement node)
		{
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
					return CreateStatementBlock(first);
				case "variableStatement":
					return CreateVariableStatement(first);
				case "emptyStatement":
					return CreateEmptyStatement(first);
				case "expressionStatement":
					return CreateExpressionStatement(first);
				case "ifStatement":
					return CreateIfStatement(first);
				case "iterationStatement":
					return CreateIterationStatement(first);
				case "continueStatement":
					return CreateContinueStatement(first);
				case "breakStatement":
					return CreateBreakStatement(first);
				case "returnStatement":
					return CreateReturnStatement(first);
				case "withStatement":
					return CreateWithStatement(first);
				case "labelledStatement":
					return CreateLabelledStatement(first);
				case "switchStatement":
					return CreateSwitchStatement(first);
				case "throwStatement":
					return CreateThrowStatement(first);
				case "tryStatement":
					return CreateTryStatement(first);
				default:
					throw new InvalidOperationException();
			}
		}

		public static UnifiedBlock CreateStatementBlock(XElement node)
		{
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

		public static IEnumerable<IUnifiedExpression> CreateStatementList(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "statementList");
			/*
			 * statementList
			 *		: statement (LT!* statement)*
			 */

			//TODO ToList()して返却したほうがいいのか？
			return node.Elements("statement").Select(CreateStatement);
		}

		public static IUnifiedExpression CreateVariableStatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "variableStatement");
			/*
			 * variableStatement
			 *		: 'var' LT!* variableDeclarationList (LT | ';')
			 */

			var bodys =
					CreateVariableDeclarationList(node.Element("variableDeclarationList"));

			return UnifiedVariableDefinition.Create(null, null, bodys);
		}

		public static UnifiedVariableDefinitionBodyCollection CreateVariableDeclarationList(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "variableDeclarationList");
			/*
			 * variableDeclarationList
			 *		: variableDeclaration (LT!* ',' LT!* variableDeclaration)*
			 */

			return node.Elements("variableDeclaration")
					.Select(CreateVariableDeclaration)
					.ToCollection();
		}

		public static UnifiedVariableDefinitionBodyCollection CreateVariableDeclarationListNoIn(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "variableDeclarationListNoIn");
			/*
			 * variableDeclarationListNoIn
			 *		: variableDeclarationNoIn (LT!* ',' LT!* variableDeclarationNoIn)*
			 */
			return node.Elements("variableDeclarationNoIn")
					.Select(CreateVariableDeclarationNoIn)
					.ToCollection();
		}

		public static UnifiedVariableDefinitionBody CreateVariableDeclaration(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "variableDeclaration");
			/*
			 * variableDeclaration
			 *		: Identifier LT!* initialiser?
			 */

			var name = UnifiedIdentifier.CreateVariable(node.NthElement(0).Value);
			var init = node.Element("initialiser") != null
			           		? CreateInitialiser(node.Element("initialiser")) : null;

			return UnifiedVariableDefinitionBody.Create(name, null, init, null, null);
		}

		public static UnifiedVariableDefinitionBody CreateVariableDeclarationNoIn(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "variableDeclarationNoIn");
			/*
			 * variableDeclarationNoIn
			 *		: Identifier LT!* initialiserNoIn?
			 */

			var name = UnifiedIdentifier.CreateVariable(node.NthElement(0).Value);
			var init = node.Element("initialiserNoIn") != null
			           		? CreateInitialiserNoIn(node.Element("initialiserNoIn")) : null;

			return UnifiedVariableDefinitionBody.Create(name, null, init, null, null);
		}

		public static IUnifiedExpression CreateInitialiser(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "initialiser");
			/*
			 * initialiser
			 *		: '=' LT!* assignmentExpression
			 */

			return CreateAssignmentExpression(node.Element("assignmentExpression"));
		}

		public static IUnifiedExpression CreateInitialiserNoIn(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "initialiserNoIn");
			/*
			 * initialiserNoIn
			 *		: '=' LT!* assignmentExpressionNoIn
			 */

			return CreateAssignmentExpressionNoIn(
				node.Element("assignmentExpressionNoIn"));
		}

		public static IUnifiedExpression CreateEmptyStatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "emptyStatement");
			/*
			 * emptyStatement
			 *		: ';'
			 */

			return UnifiedBlock.Create();
		}

		public static IUnifiedExpression CreateExpressionStatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "expressionStatement");
			/*
			 * expressionStatement
			 *		: expression (LT | ';')
			 */

			return CreateExpression(node.NthElement(0));
		}

		public static UnifiedIf CreateIfStatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "ifStatement");
			/*
			 * ifStatement
			 *		: 'if' LT!* '(' LT!* expression LT!* ')' LT!* statement (LT!* 'else' LT!* statement)?
			 */

			var cond = CreateExpression(node.Element("expression"));
			var trueBody = UnifiedBlock.Create(CreateStatement(node.Element("statement")));
			var falseBody = node.HasContent("else")
			        		? UnifiedBlock.Create(
			        				CreateStatement(node.Elements("statement").ElementAt(1))) : null;

			return UnifiedIf.Create(cond, trueBody, falseBody);
		}

		public static IUnifiedExpression CreateIterationStatement(XElement node)
		{
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
			switch(first.Name()) {
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

		public static UnifiedDoWhile CreateDoWhileStatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "doWhileStatement");
			/*
			 * doWhileStatement
			 *		: 'do' LT!* statement LT!* 'while' LT!* '(' expression ')' (LT | ';')
			 */

			var body = UnifiedBlock.Create(CreateStatement(node.Element("statement")));
			var cond = CreateExpression(node.Element("expression"));

			return UnifiedDoWhile.Create(body, cond);
		}

		public static UnifiedWhile CreateWhileStatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "whileStatement");
			/*
			 * whileStatement
			 *		: 'while' LT!* '(' LT!* expression LT!* ')' LT!* statement
			 */

			var body = UnifiedBlock.Create(CreateStatement(node.Element("statement")));
			var cond = CreateExpression(node.Element("expression"));

			return UnifiedWhile.Create(body, cond);
		}

		public static UnifiedFor CreateForStatement(XElement node)
		{
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
			var step = second.Name() == "expression" ? CreateExpression(first) : null;
			var body = UnifiedBlock.Create(CreateStatement(node.Element("statement")));

			return UnifiedFor.Create(init, cond, step, body);
		}

		public static IUnifiedExpression CreateForStatementInitialiserPart(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "forStatementInitialiserPart");
			/*
			 * forStatementInitialiserPart
			 *		: expressionNoIn
			 *		| 'var' LT!* variableDeclarationListNoIn
			 */

			if(node.NthElement(0).Name() == "expressionNoIn")
				return CreateExpressionNoIn(node.NthElement(0));
			if(node.HasElement("variableDeclarationListNoIn"))
				return UnifiedVariableDefinition.Create(
						null, null,
						CreateVariableDeclarationListNoIn(
								node.Element("variableDeclarationListNoIn")));
			throw new InvalidOperationException();
		}

		public static UnifiedForeach CreateForInStatement(XElement node)
		{
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

		public static UnifiedVariableDefinition CreateForInStatementInitialiserPart(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "forInStatementInitialiserPart");
			/*
			 * forInStatementInitialiserPart
			 *		: leftHandSideExpression
			 *		| 'var' LT!* variableDeclarationNoIn
			 */

			//TODO さすがに左辺がcallになるってことはないと思われるが。。。
			//if(node.NthElement(0).Name() == "leftHandSideExpression")
			//	  return CreateLeftHandSideExpression(node.NthElement(0));
			
			if(node.HasElement("variableDeclarationNoIn"))
				return UnifiedVariableDefinition.Create(
						null, null,
						CreateVariableDeclarationNoIn(node.Element("variableDeclarationNoIn")).
								ToCollection());
			throw new InvalidOperationException();
		}

		public static UnifiedSpecialExpression CreateContinueStatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "continueStatement");
			/*
			 * continueStatement
			 *		: 'continue' Identifier? (LT | ';')
			 */

			var identifier = node.HasElement("Identifier")
			                 		? UnifiedIdentifier.CreateUnknown(
			                 				node.Element("Identifier").Value) : null;

			return UnifiedSpecialExpression.CreateContinue(identifier);
		}

		public static UnifiedSpecialExpression CreateBreakStatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "breakStatement");
			/*
			 * breakStatement
			 *		: 'break' Identifier? (LT | ';')
			 */
			var identifier = node.HasElement("Identifier")
			                 		? UnifiedIdentifier.CreateUnknown(
			                 				node.Element("Identifier").Value) : null;

			return UnifiedSpecialExpression.CreateBreak(identifier);
		}

		public static IUnifiedExpression CreateReturnStatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "returnStatement");
			/*
			 * returnStatement
			 *		: 'return' expression? (LT | ';')
			 */
			var expression = node.HasElement("expression")
			                 		? CreateExpression(node.Element("expression")) : null;

			return UnifiedSpecialExpression.CreateReturn(expression);
		}

		public static IUnifiedExpression CreateWithStatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "withStatement");
			/*
			 * withStatement
			 *		: 'with' LT!* '(' LT!* expression LT!* ')' LT!* statement
			 */
			//TODO 対応する共通コードモデルを作成する	
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedExpression CreateLabelledStatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "labelledStatement");
			/*
			 * labelledStatement	
			 *		: Identifier LT!* ':' LT!* statement
			 */

			var list = UnifiedExpressionList.Create();
			list.Add(UnifiedLabel.Create(node.NthElement(0).Value));
			list.Add(CreateStatement(node.Element("statement")));

			return list;
		}

		public static IUnifiedExpression CreateSwitchStatement(XElement node)
		{
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

		public static UnifiedCaseCollection CreateCaseBlock(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "caseBlock");
			/*
			 * caseBlock
			 *		: '{' (LT!* caseClause)* (LT!* defaultClause (LT!* caseClause)*)? LT!* '}'
			 */

			var cases = UnifiedCaseCollection.Create();
			foreach (var e in node.Elements("caseClause")) {
				cases.Add(CreateCaseClause(e));
			}
			if(node.HasElement("defaultClause"))
				cases.Add(CreateDefaultClause(node.Element("defaultClause")));

			//TODO default文を常に最後にしてしまって大丈夫か
			return cases;
		}

		public static UnifiedCase CreateCaseClause(XElement node)
		{
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

		public static UnifiedCase CreateDefaultClause(XElement node)
		{
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

		public static UnifiedSpecialExpression CreateThrowStatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "throwStatement");
			/*
			 * throwStatement
			 *		: 'throw' expression (LT | ';')
			 */

			return UnifiedSpecialExpression.Create(
					UnifiedSpecialExpressionKind.Throw,
					CreateExpression(node.Element("expression")));
		}

		public static IUnifiedExpression CreateTryStatement(XElement node)
		{
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

			return UnifiedTry.Create(body, catches, finallyBody);
		}

		public static UnifiedCatchCollection CreateCatchClause(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "catchClause");
			/*
			 * catchClause
			 *		: 'catch' LT!* '(' LT!* Identifier LT!* ')' LT!* statementBlock
			 */

			var parameters =
					UnifiedParameter.Create(node.Element("Identifier").Value).ToCollection();
			var body = CreateStatementBlock(node.Element("statementBlock"));
			var catchClause = UnifiedCatch.Create(parameters, body);

			return catchClause.ToCollection();
		}

		public static UnifiedBlock CreateFinallyClause(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "finallyClause");
			/*
			 * finallyClause
			 *		: 'finally' LT!* statementBlock
			 */

			return CreateStatementBlock(node.Element("statementBlock"));
		}

		public static UnifiedExpressionList CreateExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "expression");
			/*
			 * expression
			 *		: assignmentExpression (LT!* ',' LT!* assignmentExpression)*
			 */

			return node.Elements("assignmentExpression")
					.Select(CreateAssignmentExpression)
					.ToExpressionList();
		}

		public static UnifiedExpressionList CreateExpressionNoIn(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "expressionNoIn");
			/*
			 * expressionNoIn
			 *		: assignmentExpressionNoIn (LT!* ',' LT!* assignmentExpressionNoIn)*
			 */

			return node.Elements("assignmentExpressionNoIn")
					.Select(CreateAssignmentExpressionNoIn)
					.ToExpressionList();
		}

		public static IUnifiedExpression CreateAssignmentExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "assignmentExpression");
			/*
			 * assignmentExpression
			 *		: conditionalExpression
			 *		| leftHandSideExpression LT!* assignmentOperator LT!* assignmentExpression
			 */

			var first = node.NthElement(0);
			switch(first.Name()) {
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

		public static IUnifiedExpression CreateAssignmentExpressionNoIn(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "assignmentExpressionNoIn");
			/*
			 * assignmentExpressionNoIn
			 *		: conditionalExpressionNoIn
			 *		| leftHandSideExpression LT!* assignmentOperator LT!* assignmentExpressionNoIn
			 */

			var first = node.NthElement(0);
			switch(first.Name()) {
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

		public static IUnifiedExpression CreateLeftHandSideExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "leftHandSideExpression");
			/*
			 * leftHandSideExpression
			 *		: callExpression
			 *		| newExpression
			 */

			var first = node.NthElement(0);
			switch(first.Name()) {
				case "callExpression":
					return CreateCallExpression(first);
				case "newExpression":
					return CreateNewExpression(first);
				default:
					throw new InvalidOperationException();
			}
		}

		public static IUnifiedExpression CreateNewExpression(XElement node)
		{
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

			if(node.NthElement(0).Name() == "memberExpression")
				return CreateMemberExpression(node.NthElement(0));

			return UnifiedNew.Create(UnifiedType.Create(CreateNewExpression(node.Element("newExpression")), null, null));
		}

		public static IUnifiedExpression CreateMemberExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "memberExpression");
			/*
			 * memberExpression
			 *		: (primaryExpression | functionExpression | 'new' LT!* memberExpression LT!* arguments) (LT!* memberExpressionSuffix)*
			 */

			IUnifiedExpression exp = null;
			var first = node.NthElement(0);

			switch(first.Name()) {
				case "primaryExpression":
				exp = CreatePrimaryExpression(first);
				break;
				case "functionExpression":
				exp = CreateFunctionExpression(first);
				break;
				//TODO newノードの名前の確認
				case "NEW":
				exp = UnifiedNew.Create(
								UnifiedType.Create(
										CreateMemberExpression(node.Element("memberExpression")), null, null),
										CreateArguments(node.Element("arguments"))
										);
				break;
				default: 
					throw new InvalidOperationException();
			}

			//TODO expにmemberExpressionSuffixを何度もくっつける -> UnifiedPropertyを使う
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateMemberExpressionSuffix(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "memberExpressionSuffix");
			/*
			 * memberExpressionSuffix
			 *		: indexSuffix
			 *		| propertyReferenceSuffix
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedExpression CreateCallExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "callExpression");
			/*
			 * callExpression
			 *		: memberExpression LT!* arguments (LT!* callExpressionSuffix)*
			 */

			return
					UnifiedCall.Create(
							CreateMemberExpression(node.Element("memberExpression")),
							CreateArguments(node.Element("arguments")));
		}

		public static IUnifiedElement CreateCallExpressionSuffix(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "callExpressionSuffix");
			/*
			 * callExpressionSuffix
			 *		: arguments
			 *		| indexSuffix
			 *		| propertyReferenceSuffix
			 */
			//TODO Callの返り値がfunctionExpressionの可能性があるので、それに対してargunmentsを書けるということか
			throw new NotImplementedException();
		}

		public static UnifiedArgumentCollection CreateArguments(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "arguments");
			/*
			 * arguments
			 *		: '(' (LT!* assignmentExpression (LT!* ',' LT!* assignmentExpression)*)? LT!* ')'
			 */

			return node.Elements("assignmentExpression").Select(
					e => UnifiedArgument.Create(CreateAssignmentExpression(e))).ToCollection();
		}

		public static UnifiedIndexer CreateIndexSuffix(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "indexSuffix");
			/*
			 * indexSuffix
			 *		: '[' LT!* expression LT!* ']'
			 */

			//TODO 第2引数がnullでいいのか確認
			return UnifiedIndexer.Create(CreateExpression(node.Element("expression")), null);
		}

		public static UnifiedProperty CreatePropertyReferenceSuffix(XElement node, IUnifiedExpression prefix)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "propertyReferenceSuffix");
			/*
			 * propertyReferenceSuffix
			 *		: '.' LT!* Identifier
			 */

			return UnifiedProperty.Create(prefix, node.Element("Identifier").Value, ".");
		}

		public static UnifiedBinaryOperator CreateAssignmentOperator(XElement node)
		{
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

		public static IUnifiedExpression CreateConditionalExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "conditionalExpression");
			/*
			 * conditionalExpression
			 *		: logicalORExpression (LT!* '?' LT!* assignmentExpression LT!* ':' LT!* assignmentExpression)?
			 */
			if(node.HasElement("assignmentExpression")) {
				return UnifiedTernaryExpression.Create(
						CreateLogicalORExpression(node.Element("logicalORExpression")),
						UnifiedTernaryOperator.Create(
								"?", ":", UnifiedTernaryOperatorKind.Conditional),
						CreateAssignmentExpression(node.Element("assignmentExpression")),
						CreateAssignmentExpression(
								node.Elements("assignmentExpression").ElementAt(1)));
			}
			return CreateLogicalORExpression(node.NthElement(0));
		}

		public static IUnifiedExpression CreateConditionalExpressionNoIn(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "conditionalExpressionNoIn");
			/*
			 * conditionalExpressionNoIn
			 *		: logicalORExpressionNoIn (LT!* '?' LT!* assignmentExpressionNoIn LT!* ':' LT!* assignmentExpressionNoIn)?
			 */
			if(node.HasElement("assignmentExpressionNoIn")) {
				return UnifiedTernaryExpression.Create(
						CreateLogicalORExpressionNoIn(node.Element("logicalORExpressionNoIn")),
						UnifiedTernaryOperator.Create(
								"?", ":", UnifiedTernaryOperatorKind.Conditional),
						CreateAssignmentExpressionNoIn(node.Element("assignmentExpressionNoIn")),
						CreateAssignmentExpressionNoIn(
								node.Elements("assignmentExpressionNoIn").ElementAt(1)));
			}
			return CreateLogicalORExpressionNoIn(node.NthElement(0));
		}

		public static IUnifiedExpression CreateLogicalORExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "logicalORExpression");
			/*
			 * logicalORExpression
			 *		: logicalANDExpression (LT!* '||' LT!* logicalANDExpression)*
			 */
			return CreateBinaryExpression(node, CreateLogicalANDExpression);
		}

		public static IUnifiedExpression CreateLogicalORExpressionNoIn(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "logicalORExpressionNoIn");
			/*
			 * logicalORExpressionNoIn
			 *		: logicalANDExpressionNoIn (LT!* '||' LT!* logicalANDExpressionNoIn)*
			 */
			return CreateBinaryExpression(node, CreateLogicalANDExpressionNoIn);
		}

		public static IUnifiedExpression CreateLogicalANDExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "logicalANDExpression");
			/*
			 * logicalANDExpression
			 *		: bitwiseORExpression (LT!* '&&' LT!* bitwiseORExpression)*
			 */
			return CreateBinaryExpression(node, CreateBitwiseORExpression);
		}

		public static IUnifiedExpression CreateLogicalANDExpressionNoIn(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "logicalANDExpressionNoIn");
			/*
			 * logicalANDExpressionNoIn
			 *		: bitwiseORExpressionNoIn (LT!* '&&' LT!* bitwiseORExpressionNoIn)*
			 */
			return CreateBinaryExpression(node, CreateBitwiseORExpressionNoIn);
		}

		public static IUnifiedExpression CreateBitwiseORExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "bitwiseORExpression");
			/*
			 * bitwiseORExpression
			 *		: bitwiseXORExpression (LT!* '|' LT!* bitwiseXORExpression)*
			 */
			return CreateBinaryExpression(node, CreateBitwiseXORExpression);
		}

		public static IUnifiedExpression CreateBitwiseORExpressionNoIn(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "bitwiseORExpressionNoIn");
			/*
			 * bitwiseORExpressionNoIn
			 *		: bitwiseXORExpressionNoIn (LT!* '|' LT!* bitwiseXORExpressionNoIn)*
			 */
			return CreateBinaryExpression(node, CreateBitwiseXORExpressionNoIn);
		}

		public static IUnifiedExpression CreateBitwiseXORExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "bitwiseXORExpression");
			/*
			 * bitwiseXORExpression
			 *		: bitwiseANDExpression (LT!* '^' LT!* bitwiseANDExpression)*
			 */
			return CreateBinaryExpression(node, CreateBitwiseANDExpression);
		}

		public static IUnifiedExpression CreateBitwiseXORExpressionNoIn(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "bitwiseXORExpressionNoIn");
			/*
			 * bitwiseXORExpressionNoIn
			 *		: bitwiseANDExpressionNoIn (LT!* '^' LT!* bitwiseANDExpressionNoIn)*
			 */
			return CreateBinaryExpression(node, CreateBitwiseANDExpressionNoIn);
		}

		public static IUnifiedExpression CreateBitwiseANDExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "bitwiseANDExpression");
			/*
			 * bitwiseANDExpression
			 *		: equalityExpression (LT!* '&' LT!* equalityExpression)*
			 */
			return CreateBinaryExpression(node, CreateEqualityExpression);
		}

		public static IUnifiedExpression CreateBitwiseANDExpressionNoIn(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "bitwiseANDExpressionNoIn");
			/*
			 * bitwiseANDExpressionNoIn
			 *		: equalityExpressionNoIn (LT!* '&' LT!* equalityExpressionNoIn)*
			 */
			return CreateBinaryExpression(node, CreateEqualityExpressionNoIn);
		}

		public static IUnifiedExpression CreateEqualityExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "equalityExpression");
			/*
			 * equalityExpression
			 *		: relationalExpression (LT!* ('==' | '!=' | '===' | '!==') LT!* relationalExpression)*
			 */
			//TODO ===演算子などを加える
			return CreateBinaryExpression(node, CreateRelationalExpression);
		}

		public static IUnifiedExpression CreateEqualityExpressionNoIn(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "equalityExpressionNoIn");
			/*
			 * equalityExpressionNoIn
			 *		: relationalExpressionNoIn (LT!* ('==' | '!=' | '===' | '!==') LT!* relationalExpressionNoIn)*
			 */
			return CreateBinaryExpression(node, CreateRelationalExpressionNoIn);
		}

		public static IUnifiedExpression CreateRelationalExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "relationalExpression");
			/*
			 * relationalExpression
			 *		: shiftExpression (LT!* ('<' | '>' | '<=' | '>=' | 'instanceof' | 'in') LT!* shiftExpression)*
			 */
			return CreateBinaryExpression(node, CreateShiftExpression);
		}

		public static IUnifiedExpression CreateRelationalExpressionNoIn(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "relationalExpressionNoIn");
			/*
			 * relationalExpressionNoIn
			 *		: shiftExpression (LT!* ('<' | '>' | '<=' | '>=' | 'instanceof') LT!* shiftExpression)*
			 */
			return CreateBinaryExpression(node, CreateShiftExpression);
		}

		public static IUnifiedExpression CreateShiftExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "shiftExpression");
			/*
			 * shiftExpression
			 *		: additiveExpression (LT!* ('<<' | '>>' | '>>>') LT!* additiveExpression)*
			 */
			return CreateBinaryExpression(node, CreateAdditiveExpression);
		}

		public static IUnifiedExpression CreateAdditiveExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "additiveExpression");
			/*
			 * additiveExpression
			 *		: multiplicativeExpression (LT!* ('+' | '-') LT!* multiplicativeExpression)*
			 */
			return CreateBinaryExpression(node, CreateMultiplicativeExpression);
		}

		public static IUnifiedExpression CreateMultiplicativeExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "multiplicativeExpression");
			/*
			 * multiplicativeExpression
			 *		: unaryExpression (LT!* ('*' | '/' | '%') LT!* unaryExpression)*
			 */
			return CreateBinaryExpression(node, CreateUnaryExpression);
		}

		public static IUnifiedExpression CreateUnaryExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "unaryExpression");
			/*
			 * unaryExpression
			 *		: postfixExpression
			 *		| ('delete' | 'void' | 'typeof' | '++' | '--' | '+' | '-' | '~' | '!') unaryExpression
			 */
			var first = node.NthElement(0);
			if(first.Name() == "postfixExpression")
				return CreatePostfixExpression(first);
			//TODO delete演算子などの実装
			return
					UnifiedUnaryExpression.Create(
							CreateUnaryExpression(node.NthElement(1)),
							CreatePrefixUnaryOperator(first.Value));
		}

		public static IUnifiedExpression CreatePostfixExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "postfixExpression");
			/*
			 * postfixExpression
			 *		: leftHandSideExpression ('++' | '--')?
			 */

			UnifiedUnaryOperator ope = null;
			if(node.Elements().Count() == 2) {
				ope = node.NthElement(1).Value == "++"
				      		? UnifiedUnaryOperator.Create(
				      				"++", UnifiedUnaryOperatorKind.PostIncrementAssign)
				      		: UnifiedUnaryOperator.Create(
				      				"--", UnifiedUnaryOperatorKind.PostDecrementAssign);
			}
			return
					UnifiedUnaryExpression.Create(
							CreateLeftHandSideExpression(node.NthElement(0)), ope);
		}

		public static IUnifiedExpression CreatePrimaryExpression(XElement node)
		{
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
			if(first.Value == "this")
				return UnifiedIdentifier.Create("this", UnifiedIdentifierKind.Unknown);
			if(first.Value == "(")
				return CreateExpression(node.Element("expression"));

			switch(first.Name()) {
				case "Identifier":
					return UnifiedIdentifier.Create(first.Value, UnifiedIdentifierKind.Variable);
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

		public static IUnifiedExpression CreateArrayLiteral(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "arrayLiteral");
			/*
			 * arrayLiteral
			 *		: '[' LT!* assignmentExpression? (LT!* ',' (LT!* assignmentExpression)?)* LT!* ']'
			 */
			//TODO UnifiedIndexerなのかUnifiedSupplementなのか
			//-> 型宣言しないので、UnifiedIndexerしか取りえないか
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedExpression CreateObjectLiteral(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "objectLiteral");
			/*
			 * objectLiteral
			 *		: '{' LT!* propertyNameAndValue (LT!* ',' LT!* propertyNameAndValue)* LT!* '}'
			 */

			var body =
					UnifiedBlock.Create(
							node.Elements("propertyNameAndValue").Select(CreatePropertyNameAndValue));

			//TODO 確認：nodeの祖先をたどって、変数宣言部分の兄弟から識別子を得る
			return
					UnifiedClassDefinition.CreateClass(
							node.Ancestors().Where(e => e.Name() == "variableDeclaration").First().
									Element("Identifier").Value, body);
		}

		public static IUnifiedExpression CreatePropertyNameAndValue(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "propertyNameAndValue");
			/*
			 * propertyNameAndValue
			 *		: propertyName LT!* ':' LT!* assignmentExpression
			 */

			//プロパティ宣言を変数宣言でとりあえずは代用
			var body = UnifiedVariableDefinitionBody.Create(
					CreatePropertyName(node.Element("propertyName")).Value, null,
					CreateAssignmentExpression(node.Element("assignmentExpression"))).ToCollection();
			return UnifiedVariableDefinition.Create(null, null, body);
		}

		public static UnifiedIdentifier CreatePropertyName(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "propertyName");
			/*
			 * propertyName
			 *		: Identifier
			 *		| StringLiteral
			 *		| NumericLiteral
			 */
			//TODO 最終的に文字列だけ取得するが、要素を場合分けるのか検討
			return UnifiedIdentifier.CreateVariable(node.NthElement(0).Value);
		}

		public static UnifiedLiteral CreateLiteral(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "literal");
			/*
			 * literal
			 *		: 'null'
			 *		| 'true'
			 *		| 'false'
			 *		| StringLiteral
			 *		| NumericLiteral
			 */
			var first = node.NthElement(0);
			if(first.Value == "null")
				return UnifiedNullLiteral.Create();
			if(first.Value == "true")
				return UnifiedBooleanLiteral.Create(true);
			if(first.Value == "false")
				return UnifiedBooleanLiteral.Create(false);

			switch(first.Name()) {
				case "StringLiteral":
					return CreateStringliteral(first);
				case "NumericLiteral":
					return CreateNumericliteral(first);
				default:
					throw new InvalidOperationException();
			}
		}

		public static UnifiedLiteral CreateNumericliteral(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "numericliteral");
			/*
			 * numericliteral
			 *		: DecimalLiteral
			 *		| HexIntegerLiteral
			 */
			//TODO Javaを参考にLiteralまわりの実装方針を決める
			throw new NotImplementedException(); //TODO: implement
		}

		public static UnifiedLiteral CreateStringliteral(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "stringliteral");
			/*
			 * stringliteral
			 */
			//TODO 確認：nodeから""または''を除いた文字列
			return UnifiedStringLiteral.CreateString(
								node.Value.Substring(1, node.Value.Length - 2));
		}

		//TODO copy from JavaModelFactoryHelper
		private static IUnifiedExpression CreateBinaryExpression(
				XElement node, Func<XElement, IUnifiedExpression> createExpression) {
			var nodes = node.Elements().OddIndexElements();
			//TODO LT!*は無視されるのか？
			return nodes.Skip(1).Aggregate(
					createExpression(nodes.First()),
					(e, n) => UnifiedBinaryExpression.Create(
							e, CreateBinaryOperator(n.PreviousElement().Value),
							createExpression(n)));
		}

		//TODO copy from JavaModelFactoryHelper
		private static UnifiedBinaryOperator CreateBinaryOperator(string name) {
			Contract.Requires(name != null);
			UnifiedBinaryOperatorKind kind;
			switch (name) {
				// Arithmetic
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
				// Shift
			case "<<":
				kind = UnifiedBinaryOperatorKind.ArithmeticLeftShift;
				break;
			case ">>":
				kind = UnifiedBinaryOperatorKind.ArithmeticRightShift;
				break;
			case ">>>":
				kind = UnifiedBinaryOperatorKind.LogicalRightShift;
				break;
				// Comparison
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
				// Logocal
			case "&&":
				kind = UnifiedBinaryOperatorKind.AndAlso;
				break;
			case "||":
				kind = UnifiedBinaryOperatorKind.OrElse;
				break;
				// Bit
			case "&":
				kind = UnifiedBinaryOperatorKind.And;
				break;
			case "|":
				kind = UnifiedBinaryOperatorKind.Or;
				break;
			case "^":
				kind = UnifiedBinaryOperatorKind.ExclusiveOr;
				break;
				// Assignment
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
			case "instanceof":
				kind = UnifiedBinaryOperatorKind.InstanceOf;
				break;
			default:
				throw new InvalidOperationException();
			}
			return UnifiedBinaryOperator.Create(name, kind);
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
			default:
				throw new InvalidOperationException();
			}
			return UnifiedUnaryOperator.Create(name, kind);
		}
	}
}