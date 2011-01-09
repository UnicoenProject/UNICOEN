using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C.CodeModel
{
	public class CBitOperator : COperator
	{
		// constructor
		public CBitOperator(string name) : base(name) { }

		public static new CBitOperator Create(XElement opeNode)
		{
			var sw = opeNode.Value;
			switch (sw)
			{
				case "&":
					return new CBitAndOperator();
				case "|":
					return new CBitOrOperator();
				case "^":
					return new CBitXorOperator();
				case "~":
					return new CBitReverseOperator();
				default:
					throw new InvalidOperationException();
			}
		}

	}
}
