using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C
{
	public class CString : CPrimaryExpression
	{
		private XElement _node;

		public string Body
		{
			get
			{
				return _node.Element("IDENTIFIER").Value;
			}
		}

		public override string ToString()
		{
			return Body;
		}

		// constructor
		public CString(XElement node)
		{
			_node = node;
		}
	}
}
