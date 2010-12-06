using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C
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
					.Select(e => CExpression.CreateExpression(e));
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


		// constructor
		public CStatement(XElement node)
		{
			_node = node;
		}
		// deligate procedure and root_node to subclasses
		public CStatement() { }

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
