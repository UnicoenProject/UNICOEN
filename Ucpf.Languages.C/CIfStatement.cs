using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C
{
	public class CIfStatement : CStatement
	{
		private XElement _node;		//

		public CExpression ConditionalExpression;
		public CBlock TrueBlock;
		public CBlock ElseBlock;

		// constructor
		public CIfStatement(XElement node) : base(node, "if")
		{
			_node = node;
		}

		public CIfStatement()
		{
			_node = null;
		}
	}
}