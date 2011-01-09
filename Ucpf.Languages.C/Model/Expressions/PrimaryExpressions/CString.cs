using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C.Model
{
	public class CString : CPrimaryExpression
	{
		public override string Body { get; set; }

		// constructor
		public CString(XElement node)
		{
			Body = node.Element("IDENTIFIER").Value;
		}

		// for temporary test
		public CString(string s)
		{
			Body = s;
		}

		
		
		public override string ToString()
		{
			return Body;
		}


	}
}
