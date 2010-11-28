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
		public string Type { get; set; }

		// constructor
		public CExpression(XElement node, string type = "")
		{
			_node = node;
			Type = type;
		}

		ToString(){
		}

	}
}
