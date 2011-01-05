using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Linq;
using Ucpf.CodeModel;

namespace Ucpf.Languages.C.CodeModel
{
	public abstract class CExpression : IExpression
	{
		// constructor
		protected CExpression() { }

		public static CExpression Create(XElement expNode)
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
				expNode.Descendants().Where(e =>
				{
					var cnt = (e.Elements()).Count();
					return cnt > 1
						|| (cnt == 1
							&& (e.Element("TOKEN") != null
								|| e.Element("IDENTIFIER") != null));
				}).First();

			// TODO : the 'if-elseif' switching below must be converted into 'switch-case' switching

			// case : primary expression :: method_invocation or string
			var nodeName = fnode.Name.LocalName;

			switch (nodeName)
			{
				// primary :: numeric_constant or variable_name:string
				case "primary_expression":
					return new CString(fnode);

				// case : assisgnment(e.g. a = 3)
				case "assignment_expression":
					var elements = fnode.Elements();
					var lNode = elements.ElementAt(0);
					var aOpeNode = elements.ElementAt(1);
					var rNode = elements.ElementAt(2);
					return new CAssignmentExpression(
						lNode,
						CAssignmentOperator.Create(aOpeNode),
						rNode);
				// case : numeric constant))
				case "constant":
					return new CNumber(fnode);

				// case : unary expression
				case "prefix_expression":
					// var sw = fnode.Element("postfix_expression").Element("TOKEN");
					var preOpeNode = fnode.Elements().ElementAt(0);
					return new CUnaryExpression(
						CUnaryOperator.CreatePrefix(preOpeNode),
						fnode.Elements().ElementAt(1));

				case "postfix_expression":
					var token = fnode.Element("TOKEN");
					// case : method_invocation
					if (token != null && token.Value == "(")
					{
						return new CInvocationExpression(fnode);
					}

					// case : postfix expression (e.g. y++
					var postOpeNode = fnode.Elements().ElementAt(1);
					return new CUnaryExpression(
						CUnaryOperator.CreatePostfix(postOpeNode),
						fnode.Elements().ElementAt(0));
					// TODO :: array reference expression etc...
			}

			// case : binary expression
			// else if (fnode.Elements().Count() == 3)
			// {
			var ope = fnode.Elements().ElementAt(1);
			if (ope != null && binaryOperator.Contains(ope.Value))
			{
				return new CBinaryExpression(
					fnode.Elements().ElementAt(0),
					CBinaryOperator.Create(ope),
					fnode.Elements().ElementAt(2));
			}
			// }	
			throw new InvalidOperationException();

		}


		public override string ToString()
		{
			// return _node.Value;
			throw new NotImplementedException("Create :: ToString");
		}

		// acceptor
		public void Accept(CCodeModelToCode conv)
		{
			conv.Generate(this);
		}


		void ICodeElement.Accept(CodeModelToCode.ICodeModelToCode conv)
		{
			conv.Generate(this);
		}
	}
}
