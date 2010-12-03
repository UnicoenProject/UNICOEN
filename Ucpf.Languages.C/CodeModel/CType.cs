using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C
{
	public class CType
	{
		public string Name { get; set; }

		// constructor
		public CType(string name)
		{
			Name = name;
		}
	}
}
