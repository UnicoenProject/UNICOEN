using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C.CodeModel
{
	public class CStatement
	{
		// properties
		public List<CExpression> Expressions { get; private set; }

		// constructor for parsing AST
		public CStatement(XElement node)
		{
			Expressions = node.Descendants("expression")
				.Select(e => CExpression.Create(e))
				.ToList();
		}
		// constructor for deligating to subclasses
		public CStatement() { }

		

		public override string ToString()
		{
			string str = "";
			foreach (CExpression s in Expressions)
			{
				str += s.ToString();
			}

			return str;
		}

		public static CStatement Create(XElement node)
		{
			// -- which is better ?
			// var judge = node.Descendants("TOKEN").First().Value;
			var judge = node.Descendants().First().Name.LocalName;
			switch (judge)
			{
				case ("selection_statement"):
					return CSelectionStatement.CreateSelectionStatement(node);
				case ("jump_statement"):
					return new CReturnStatement(node);
				case ("iteration_statement") :
					// return CIterationStatement.CreateStatement(node);
					throw new NotImplementedException();
				default:
					return new CStatement(node);
			}
		}


		// acceptor
		public void Accept(CCodeModelToCode conv) {
			conv.Generate(this);
		}
	}
}

/*
 * postfix_expression
	:   primary_expression
        (   '[' expression ']'
        |   '(' ')'
        |   '(' argument_expression_list ')'
        |   '.' IDENTIFIER
        |   '->' IDENTIFIER
        |   '++'
        |   '--'
        )*
*/
