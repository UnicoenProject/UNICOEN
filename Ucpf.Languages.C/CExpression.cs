using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C
{
	public class CExpression
	{
		private XElement _node;
		public string element
		{
			get
			{
				return _node.Value;
			}
		}
		
		// constructor
		public CExpression(XElement node)
		{
			_node = node;
		}

	}
}
