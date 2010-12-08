using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C
{
	public class CReturnStatement : CJumpStatement
	{
		public CReturnStatement(XElement node) : base(node) { }
	}
}
