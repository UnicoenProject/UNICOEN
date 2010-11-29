using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C
{
	public class CBlock
	{
		private XElement _node;		// statement_list
		public IEnumerable<CStatement> Statements
		{
			get
			{
				return _node.Elements("statement")
					.Select(e => createStatement(e));
			}
		}

		public static CStatement createStatement(XElement node){
			var judge = node.Descendants("TOKEN").First().Value;
			switch (judge)
			{
				case ("if"):
					return new CIfStatement(node);
				case ("return"):
					return new CJumpStatement(node);
				default:
					return new CStatement(node);
			}
		}

		// constructor
		public CBlock(XElement node)
		{
			_node = node;
		}

	}
}
