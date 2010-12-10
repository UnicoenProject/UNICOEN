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
		private XElement _node;		// postfix_expression

		public string FunctionName
		{
			get
			{
				return _node.Element("primary_expression").Element("IDENTIFIER").Value;
			}
		}

		public IEnumerable<CExpression> Arguments
		{
			get
			{
				// suspicious...
				return _node.Element("argument_expression_list").Elements()
					.Select(e => Create(e));
			}
		}

		public override string ToString()
		{
			string str = FunctionName + "(";
			foreach (CExpression ex in Arguments)
			{
				str += ex.ToString();
				str += ",";
			}
			str = str.Substring(0, str.Length - 1);
			str += ")";

			return str;
		}

		// constructor
		public CInvocationExpression(XElement node)
		{
			_node = node;
		}
	}
}

