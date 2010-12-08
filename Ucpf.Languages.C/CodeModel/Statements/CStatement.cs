using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Ucpf.Languages.C.CodeModel.Expressions;

namespace Ucpf.Languages.C.CodeModel.Statements
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
					.Select(CExpression.Create);
			}
		}

		public override string ToString()
		{
			var str = "";
			foreach (var s in Expressions)
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

		public static CStatement Create(XElement node){
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
