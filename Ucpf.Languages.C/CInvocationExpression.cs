using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C
{
	public class CInvocationExpression : CExpression
	{
		private XElement _node;		// primary_expression

		public string FunctionName
		{
			get
			{
				return _node.Element("TOKEN").Value;
			}
		}

		public IEnumerable<CExpression> Arguments
		{
			get
			{
				return _node.Element("argument_expression_list").Elements()
					.Select(e => CreateExpression(e));
			}
		}

		public override string ToString()
		{
			string str = FunctionName + "(";
			foreach (CExpression ex in Arguments)
			{
				str += ex.ToString();
			}
			str += ")";

			return str;
		}

		// constructor
		public CInvocationExpression(XElement node) : base(null, "invocation")
		{
			_node = node;
		}
	}
}

