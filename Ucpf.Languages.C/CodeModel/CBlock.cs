using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Ucpf.CodeModel;
using Ucpf.CodeModelToCode;

namespace Ucpf.Languages.C.CodeModel
{
	public class CBlock
	{
		public IList<CStatement> Statements { get; private set; }

		// constructor for parsing AST
		public CBlock(XElement node) {
			Statements = node.Elements("statement")
				.Select(CStatement.Create)
				.ToList();
		}

		// constructor for constructing programmatically
		public CBlock() {
			Statements = new List<CStatement>();
		}

		public void Accept(CCodeModelToCode conv) {
			conv.Generate(this);
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
