﻿using System;
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
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateSourceElements(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "sourceElements");
			/*
			 * sourceElements
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateSourceElement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "sourceElement");
			/*
			 * sourceElement
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateFunctionDeclaration(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "functionDeclaration");
			/*
			 * functionDeclaration
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateFunctionExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "functionExpression");
			/*
			 * functionExpression
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateFormalParameterList(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "formalParameterList");
			/*
			 * formalParameterList
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateFunctionBody(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "functionBody");
			/*
			 * functionBody
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateStatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "statement");
			/*
			 * statement
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateStatementBlock(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "statementBlock");
			/*
			 * statementBlock
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateStatementList(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "statementList");
			/*
			 * statementList
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateVariableStatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "variableStatement");
			/*
			 * variableStatement
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateVariableDeclarationList(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "variableDeclarationList");
			/*
			 * variableDeclarationList
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateVariableDeclarationListNoIn(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "variableDeclarationListNoIn");
			/*
			 * variableDeclarationListNoIn
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateVariableDeclaration(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "variableDeclaration");
			/*
			 * variableDeclaration
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateVariableDeclarationNoIn(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "variableDeclarationNoIn");
			/*
			 * variableDeclarationNoIn
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateInitialiser(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "initialiser");
			/*
			 * initialiser
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateInitialiserNoIn(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "initialiserNoIn");
			/*
			 * initialiserNoIn
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateEmptyStatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "emptyStatement");
			/*
			 * emptyStatement
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateExpressionStatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "expressionStatement");
			/*
			 * expressionStatement
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateIfStatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "ifStatement");
			/*
			 * ifStatement
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateIterationStatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "iterationStatement");
			/*
			 * iterationStatement
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateDoWhileStatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "doWhileStatement");
			/*
			 * doWhileStatement
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateWhileStatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "whileStatement");
			/*
			 * whileStatement
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateForStatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "forStatement");
			/*
			 * forStatement
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateForStatementInitialiserPart(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "forStatementInitialiserPart");
			/*
			 * forStatementInitialiserPart
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateForInStatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "forInStatement");
			/*
			 * forInStatement
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateForInStatementInitialiserPart(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "forInStatementInitialiserPart");
			/*
			 * forInStatementInitialiserPart
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateContinueStatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "continueStatement");
			/*
			 * continueStatement
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateBreakStatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "breakStatement");
			/*
			 * breakStatement
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateReturnStatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "returnStatement");
			/*
			 * returnStatement
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateWithStatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "withStatement");
			/*
			 * withStatement
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateLabelledStatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "labelledStatement");
			/*
			 * labelledStatement
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateSwitchStatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "switchStatement");
			/*
			 * switchStatement
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateCaseBlock(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "caseBlock");
			/*
			 * caseBlock
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateCaseClause(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "caseClause");
			/*
			 * caseClause
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateDefaultClause(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "defaultClause");
			/*
			 * defaultClause
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateThrowStatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "throwStatement");
			/*
			 * throwStatement
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateTryStatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "tryStatement");
			/*
			 * tryStatement
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateCatchClause(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "catchClause");
			/*
			 * catchClause
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateFinallyClause(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "finallyClause");
			/*
			 * finallyClause
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "expression");
			/*
			 * expression
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateExpressionNoIn(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "expressionNoIn");
			/*
			 * expressionNoIn
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateAssignmentExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "assignmentExpression");
			/*
			 * assignmentExpression
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateAssignmentExpressionNoIn(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "assignmentExpressionNoIn");
			/*
			 * assignmentExpressionNoIn
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateLeftHandSideExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "leftHandSideExpression");
			/*
			 * leftHandSideExpression
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateNewExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "newExpression");
			/*
			 * newExpression
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateMemberExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "memberExpression");
			/*
			 * memberExpression
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateMemberExpressionSuffix(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "memberExpressionSuffix");
			/*
			 * memberExpressionSuffix
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateCallExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "callExpression");
			/*
			 * callExpression
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateCallExpressionSuffix(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "callExpressionSuffix");
			/*
			 * callExpressionSuffix
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateArguments(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "arguments");
			/*
			 * arguments
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateIndexSuffix(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "indexSuffix");
			/*
			 * indexSuffix
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreatePropertyReferenceSuffix(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "propertyReferenceSuffix");
			/*
			 * propertyReferenceSuffix
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateAssignmentOperator(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "assignmentOperator");
			/*
			 * assignmentOperator
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateConditionalExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "conditionalExpression");
			/*
			 * conditionalExpression
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateConditionalExpressionNoIn(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "conditionalExpressionNoIn");
			/*
			 * conditionalExpressionNoIn
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateLogicalORExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "logicalORExpression");
			/*
			 * logicalORExpression
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateLogicalORExpressionNoIn(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "logicalORExpressionNoIn");
			/*
			 * logicalORExpressionNoIn
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateLogicalANDExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "logicalANDExpression");
			/*
			 * logicalANDExpression
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateLogicalANDExpressionNoIn(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "logicalANDExpressionNoIn");
			/*
			 * logicalANDExpressionNoIn
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateBitwiseORExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "bitwiseORExpression");
			/*
			 * bitwiseORExpression
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateBitwiseORExpressionNoIn(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "bitwiseORExpressionNoIn");
			/*
			 * bitwiseORExpressionNoIn
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateBitwiseXORExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "bitwiseXORExpression");
			/*
			 * bitwiseXORExpression
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateBitwiseXORExpressionNoIn(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "bitwiseXORExpressionNoIn");
			/*
			 * bitwiseXORExpressionNoIn
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateBitwiseANDExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "bitwiseANDExpression");
			/*
			 * bitwiseANDExpression
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateBitwiseANDExpressionNoIn(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "bitwiseANDExpressionNoIn");
			/*
			 * bitwiseANDExpressionNoIn
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateEqualityExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "equalityExpression");
			/*
			 * equalityExpression
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateEqualityExpressionNoIn(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "equalityExpressionNoIn");
			/*
			 * equalityExpressionNoIn
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateRelationalExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "relationalExpression");
			/*
			 * relationalExpression
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateRelationalExpressionNoIn(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "relationalExpressionNoIn");
			/*
			 * relationalExpressionNoIn
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateShiftExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "shiftExpression");
			/*
			 * shiftExpression
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateAdditiveExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "additiveExpression");
			/*
			 * additiveExpression
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateMultiplicativeExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "multiplicativeExpression");
			/*
			 * multiplicativeExpression
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateUnaryExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "unaryExpression");
			/*
			 * unaryExpression
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreatePostfixExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "postfixExpression");
			/*
			 * postfixExpression
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreatePrimaryExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "primaryExpression");
			/*
			 * primaryExpression
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateArrayLiteral(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "arrayLiteral");
			/*
			 * arrayLiteral
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateObjectLiteral(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "objectLiteral");
			/*
			 * objectLiteral
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreatePropertyNameAndValue(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "propertyNameAndValue");
			/*
			 * propertyNameAndValue
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreatePropertyName(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "propertyName");
			/*
			 * propertyName
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateLiteral(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "literal");
			/*
			 * literal
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateNumericliteral(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "numericliteral");
			/*
			 * numericliteral
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateStringliteral(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "stringliteral");
			/*
			 * stringliteral
			 */
			throw new NotImplementedException(); //TODO: implement
		}
	}
}