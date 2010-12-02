using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C
{
	public class CBlock
	{
		private XElement _node;		// statement_list
		public IEnumerable<CStatement> Statements
		{
			get
			{
				return _node.Elements("statement")
					.Select(e => createStatement(e));
			}
		}

		public static CStatement createStatement(XElement node){
			// -- which is better ?
			// var judge = node.Descendants("TOKEN").First().Value;
			var judge = node.Descendants().First().Name.LocalName;
			switch (judge)
			{
				case ("selection_statement"):
					return new CIfStatement(node);
				case ("jump_statement"):
					return new CJumpStatement(node);
				default:
					return new CStatement(node);
			}
		}

		// constructor
		public CBlock(XElement node)
		{
			_node = node;
		}

	}
}
/*
statement
	: labeled_statement
	| compound_statement
	| expression_statement
	| selection_statement
	| iteration_statement
	| jump_statement
	;

labeled_statement
	: IDENTIFIER ':' statement
	| 'case' constant_expression ':' statement
	| 'default' ':' statement
	;

compound_statement
scope Symbols; // blocks have a scope of symbols
	: '{' declaration* statement_list? '}'
	;

statement_list
	: statement+
	;

expression_statement
	: ';'
	| expression ';'
	;

selection_statement
	: 'if' '(' expression ')' statement (options {k=1; backtrack=false;}:'else' statement)?
	| 'switch' '(' expression ')' statement
	;

iteration_statement
	: 'while' '(' expression ')' statement
	| 'do' statement 'while' '(' expression ')' ';'
	| 'for' '(' expression_statement expression_statement expression? ')' statement
	;

jump_statement
	: 'goto' IDENTIFIER ';'
	| 'continue' ';'
	| 'break' ';'
	| 'return' ';'
	| 'return' expression ';'
	;
*/
