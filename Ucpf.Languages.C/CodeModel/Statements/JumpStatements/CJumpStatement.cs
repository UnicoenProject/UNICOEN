using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C.CodeModel
{
	public class CJumpStatement : CStatement
	{
		public static CJumpStatement CCreateJumpStatement(XElement node)
		{
			throw new NotImplementedException();
		}

		public CJumpStatement(XElement node) : base(node){ }
	}
}
