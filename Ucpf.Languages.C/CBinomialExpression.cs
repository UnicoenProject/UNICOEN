using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C
{
	public class CBinomialExpression : CExpression
	{
		// private XElement _node;

		public COperator Operator;
		public CValue LeftValue;
		public CValue RightValue;

		// constructor
		public CBinomialExpression(XElement node)
			: base(node, "bionomial") { }
	}
}
