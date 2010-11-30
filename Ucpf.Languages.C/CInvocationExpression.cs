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
		private XElement _node;
		// _node :: "expression" ?  maybe not

		public string FunctionName
		{
			get
			{
				// throw new NotImplementedException();
				return _node.Element("postfix_expresiion").Value;
			}
		}

		public IEnumerable<CArgument> Arguments
		{
			get
			{
				// return _node.Element("argument_expression").Elements("TOKEN")
				throw new NotImplementedException();
			}
		}

		// constructor
		public CInvocationExpression(XElement node)
			: base(node, "invocation") { }
	}
}
