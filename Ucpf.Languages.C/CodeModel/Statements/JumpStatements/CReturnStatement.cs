using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C.CodeModel
{
	public class CReturnStatement : CJumpStatement
	{
		public CReturnStatement(XElement node) : base(node) { }

		public override string ToString()
		{
			string str = "return ";
			foreach (CExpression s in Expressions)
			{
				str += s.ToString();
			}
			return str;
		}

	}
}
