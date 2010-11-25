using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleApplication3
{
	public class CElement
	{
		private XElement _node;
		public CElement(XElement node)
		{
			_node = node;
		}

	}
}
