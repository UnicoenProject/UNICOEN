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
		private XElement _node;		// statement
		public string Type { get; set; }

		public IEnumerable<CExpression> Expressions
		{
			get
			{
				return _node.Descendants("expression")
					.Select(e => CExpression.Create(e));
			}
		}

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


		// constructor
		public CStatement(XElement node)
		{
			_node = node;
		}
		// deligate procedure and root_node to subclasses
		public CStatement() { }

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
