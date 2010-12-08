using System;
using System.Linq;
using System.Xml.Linq;
using Ucpf.Languages.C.CodeModel.Expressions.PrimaryExpressions;
using Ucpf.Languages.C.CodeModel.Operators;

namespace Ucpf.Languages.C.CodeModel.Expressions
{
	public class CExpression
	{
		private XElement _node;
		public string Type { get; set; }

		public static CExpression Create(XElement node)
		{
			/*
			 * TODO :: implement array reference expressions (ary[]) and dot(.) / arrow(->) operations
			 * 
			 * Suspicious :: is swiching order correct ?
			 * */


			// fnode is the first node which has more than 2 children nodes
			// or which has only one "TOKEN" node as child node.
			string[] binaryOperator = {"*", "/", "%", "+", "-",
											"<<", ">>", "&", "|", "^", "~",
											"=", "+=", "-=", "*=", "/=",
											"<=", "<", ">=", ">", "==", "!=",
											"&&", "||"};
			// may not be used
			string[] tripleOperator = { };
			string[] unaryOperator = { };


			var fnode =
				node.Descendants().Where(e =>
				{
					var cnt = (e.Elements()).Count();
					return cnt > 1
						|| (cnt == 1
							&& (e.Element("TOKEN") != null
								|| e.Element("IDENTIFIER") != null));
				}).First();
			
			// case : primary expression :: method_invocation or string
			if (fnode.Name.LocalName == "primary_expression")
			{
				// primary :: numeric_constant or variable_name:string
				return new CString(fnode);
			}
			
			// case : numeric constant
			else if (fnode.Name.LocalName == "constant")
			{
				return new CNumber(fnode);
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

			// case : binary expression
			// else if (fnode.Elements().Count() == 3)
			// {
				var ope = fnode.Elements().ElementAt(1);
				if (ope != null && binaryOperator.Contains(ope.Value))
				{
					return new CBinaryExpression(
						fnode.Elements().ElementAt(0),
						COperator.CreateOperator(ope),
						fnode.Elements().ElementAt(2));
				}
			// }	
				
			// case : method_invocation
			else if(fnode.Name.LocalName == "postfix_expression"){
				var token = fnode.Element("TOKEN");

				if (token != null && token.Value == "(")
				{
					return new CInvocationExpression(fnode);
				}

				// TODO :: array reference expression etc...
				else
				{
					throw new NotImplementedException();
				}
			}

			throw new InvalidOperationException();
		}



		// constructor
		protected CExpression(XElement node, string type = "")
		{
			_node = node;
			Type = type;
		}
		protected CExpression()
		{
		}

		public override string ToString()
		{
			// return _node.Value;
			throw new NotImplementedException("Create :: ToString");
		}
	}
}
