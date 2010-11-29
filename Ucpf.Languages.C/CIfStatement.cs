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
		private XElement _node;		// statemenet

		public CExpression ConditionalExpression
		{
			get
			{
				return new CExpression(_node.Descendants("expression").First());
			}
		}
		public CBlock TrueBlock
		{
			get
			{
				return new CBlock(_node.Descendants("statement").First());
			}
		}
		public CBlock ElseBlock
		{
			get
			{
				throw new NotImplementedException();
			}
		}
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