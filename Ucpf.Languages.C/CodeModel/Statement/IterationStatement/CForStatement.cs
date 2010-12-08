using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ucpf.Languages.C
{
	public class CForStatement : CIterationStatement
	{

	}
}

/*
 * expression_statement
	: ';'
	| expression ';'
	;
 * 
 * iteration_statement
	: 'while' '(' expression ')' statement
	| 'do' statement 'while' '(' expression ')' ';'
	| 'for' '(' expression_statement expression_statement expression? ')' statement
	;
 * expression_statement
	: ';'
	| expression ';'
	;
*/