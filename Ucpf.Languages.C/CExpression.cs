using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C
{
	public class CExpression
	{
		private XElement _node;
		// public CExpression xp;
		public string Type { get; set; }

		public static CExpression CreateExpression(XElement node)
		{
			// throw new NotImplementedException("method :: createExpression");

			// scan node - decendancces - where - count(element) >= 2
			// fnode is the first node which has more than 2 children nodes or which has only one "TOKEN" node as child node.
			// fnode.count == 3 => binary
			// fnode.count == 2 => polynomial
			// fnode.count == 1 => (terminal)
			string[] binary_operator = {"*", "/", "%", "+", "-",
											"<<", ">>", "&", "|", "^", "~",
											"=", "+=", "-=", "*=", "/=",
											"<=", "<", ">=", ">", "==", "!=",
											"&&", "||"};
			string[] triple_operator = { };
			string[] unary_operator = {};


			var fnode =
				node.Descendants().Where(e =>
				{
					var cnt = (e.Elements()).Count();
					return cnt > 1 || (cnt == 1 && e.Element("TOKEN") != null);
				}).First();
			var ope = fnode.Elements().ElementAt(1);
			
			// case : binary expression
			if (binary_operator.Contains(ope.Value))
			{
				return new CBinaryExpression(
					fnode.Elements().ElementAt(0),
					ope,
					fnode.Elements().ElementAt(2));
			}

			// case : unary expression
			else if (fnode.Name.LocalName == "unary_expression")
			{
				var sw = fnode.Element("postfix_expression").Element("TOKEN");
				if (sw != null)
				{
					return new CUnaryExpression(
						fnode.Elements().ElementAt(0),
						fnode.Elements().ElementAt(1));
				}
				else {
					return new CUnaryExpression(
						fnode.Elements().ElementAt(1),
						fnode.Elements().ElementAt(0));
				}
			}

			// case : primary expression
		}



		// constructor
		public CExpression(XElement node, string type = "")
		{
			_node = node;
			Type = type;
		}

		public override string ToString()
		{
			// return _node.Value;
			throw new NotImplementedException("To String");
		}
	}
}
