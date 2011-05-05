using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Xml.Linq;
using Code2Xml.Languages.C.CodeToXmls;
using Mocomoco.Xml.Linq;
using Paraiba.Linq;
using Unicoen.Core.Model;

namespace Unicoen.Languages.C.ModelFactories
{
	// for Statement
	public static partial class CModelFactoryHelper
	{
		public static IUnifiedElement CreateStatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "statement");
			/*
			statement
			: labeled_statement
			| compound_statement
			| expression_statement
			| selection_statement
			| iteration_statement
			| jump_statement
			 */
	
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateLabeledStatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "labeled_statement");
			/*
			labeled_statement
			: IDENTIFIER ':' statement
			| 'case' constant_expression ':' statement
			| 'default' ':' statement
			 */
	
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateCompoundStatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "compound_statement");
			/*
			compound_statement
			: '{' declaration* statement_list? '}'
			 */
			
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateStatementList(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "statement_list");
			/*
			statement_list
			: statement+
			 */
	
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateExpressionStatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "expression_statement");
			/*
			expression_statement
			: ';'
			| expression ';'
			*/
			
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateSelectionStatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "selection_statement");
			/*
			selection_statement
			: 'if' '(' expression ')' statement (options {k=1; backtrack=false;}:'else' statement)?
			| 'switch' '(' expression ')' statement
			*/
			
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateIterationStatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "iteration_statement");
			/*
			iteration_statement
			: 'while' '(' expression ')' statement
			| 'do' statement 'while' '(' expression ')' ';'
			| 'for' '(' expression_statement expression_statement expression? ')' statement
			 */
			
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateJumpStatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "jump_statement");
			/*
			jump_statement
			: 'goto' IDENTIFIER ';'
			| 'continue' ';'
			| 'break' ';'
			| 'return' ';'
			| 'return' expression ';'
			 */

			throw new NotImplementedException(); //TODO: implement
		}
	}
}
