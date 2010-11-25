using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleApplication3
{
	// equiavalent of IfStatement?
	// not needed??
	public class CSelectionStatement : CStatement
	{
		public CSelectionStatement(XElement node) : base(node, "selection"){}
	}
}
