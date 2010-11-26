using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C
{
	public class CJumpStatement : CStatement
	{
		public CJumpStatement(XElement node) : base(node, "jump") { }
	}
}
