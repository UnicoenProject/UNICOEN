using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Ucpf.Languages.C.CodeModel.Expressions
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

