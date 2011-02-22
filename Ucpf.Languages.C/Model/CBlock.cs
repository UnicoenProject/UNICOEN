using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Ucpf.Common.Model;
using Ucpf.Common.OldModel;
using Ucpf.Common.OldModel.Statements;

using Ucpf.Common.Visitors;
using Ucpf.Languages.C.Model.Statements;

namespace Ucpf.Languages.C.Model {
	public class CBlock : IBlock {
		// constructor for parsing AST
		public CBlock(XElement node) {
			var sw = node.Name.LocalName;
			switch (sw) {
			case "statement_list": // for compound statement
				Statements = node.Elements("statement")
					.Select(CStatement.Create)
					.Cast<IStatement>()
					.ToList();
				break;
			case "statement": // for regarding single statement as block
				List<IStatement> result = new List<IStatement>();
				result.Add((CStatement.Create(node)));
				Statements = result;
				break;
			default:
				throw new InvalidOperationException("CBlock");
			}
		}

		// constructor for constructing programmatically
		public CBlock() {
			Statements = new List<IStatement>();
		}

		public IList<IStatement> Statements { get; private set; }

		// acceptor

		#region IBlock Members

		public void Accept(IModelToCode conv) {
			conv.Generate(this);
		}

		IList<IStatement> IBlock.Statements {
			get { return Statements; }
		}

		#endregion
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