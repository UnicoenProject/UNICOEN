using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C
{
	// equiavalent of IfStatement?
	// not needed??
	public class CSelectionStatement : CStatement
	{
		private XElement _node;
		public CSelectionStatement(XElement node)
		{
			_node = node;
		}
	}
}
