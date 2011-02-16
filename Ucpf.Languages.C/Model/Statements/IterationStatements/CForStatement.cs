using System.Xml.Linq;

namespace Ucpf.Languages.C.Model.Statements.IterationStatements {
	public class CForStatement : CIterationStatement {
		public CForStatement(XElement node) : base(node) {}
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