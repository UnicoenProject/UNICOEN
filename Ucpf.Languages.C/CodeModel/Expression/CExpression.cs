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
		public string Type { get; set; }

		public static CExpression CreateExpression(XElement node)
		{
			/*
			* TODO :: implement array reference expressions (ary[]) and dot(.) / arrow(->) operations
			*/


			// fnode is the first node which has more than 2 children nodes
			// or which has only one "TOKEN" node as child node.
			string[] binary_operator = {"*", "/", "%", "+", "-",
											"<<", ">>", "&", "|", "^", "~",
											"=", "+=", "-=", "*=", "/=",
											"<=", "<", ">=", ">", "==", "!=",
											"&&", "||"};
			string[] triple_operator = { };
			string[] unary_operator = { };


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
					COperator.CreateOperator(ope),
					fnode.Elements().ElementAt(2));
			}

			// case : unary expression
			else if (fnode.Name.LocalName == "unary_expression")
			{
				var sw = fnode.Element("postfix_expression").Element("TOKEN");

				if (sw != null)		// ex : ++x
				{
					return new CUnaryExpression(
						COperator.CreateBeforeOperator(fnode.Elements().ElementAt(0)),
						fnode.Elements().ElementAt(1));
				}
				else
				{				// ex : y++
					return new CUnaryExpression(
						COperator.CreateAfterOperator(fnode.Elements().ElementAt(1)),
						fnode.Elements().ElementAt(0));
				}
			}

			// case : primary expression
			else if (fnode.Name.LocalName == "primary_expression")
			{
				if (fnode.Parent.Element("TOKEN").Value == "(")	// method invocation
				{
					return new CInvocationExpression(fnode);
				}
				else
				{	// primary :: numeric_constant or variable_name:string
					// TODO :: distinguish above 2 types when the node names changed
					var val = fnode.Element("constant");
					if (val != null)
					{
						return new CConstant(val.Value);
					}
					else
					{
						return new CConstant(fnode.Element("TOKEN").Value);
					}

				}
			}

			throw new InvalidOperationException("CrateExpression");
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
			throw new NotImplementedException("CreateExpression :: ToString");
		}
	}
}
