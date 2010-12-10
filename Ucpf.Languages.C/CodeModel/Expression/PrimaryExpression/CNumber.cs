using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C.CodeModel
{
	public class CNumber : CPrimaryExpression
	{
		private XElement _node;
		public string Body
		{
			get
			{
				return _node.Value;
			}
		}

		public override string ToString()
		{
			return Body;
		}

		// constructor
		public CNumber(XElement node)
		{
			_node = node;
		}
	}
}
