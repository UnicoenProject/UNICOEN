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
			if (node.FirstAttribute.Value == "selection_statemenet")
			{
				return new CIfStatement();
			}
			else return new CStatement();
		}

		// constructor
		public CBlock(XElement node)
		{
			_node = node;
		}

	}
}
