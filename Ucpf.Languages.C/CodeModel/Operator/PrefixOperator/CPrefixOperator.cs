using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C
{
	public class CPrefixOperator : COperator
	{
		public static CPrefixOperator CreatePrefixOperator(XElement opeNode)
		{
			var sw = opeNode.Value;
			switch (sw)
			{
				case "++":
					return new CPrefixIncrementOperator();
				case "--":
					return new CPrefixDecrementOperator();
				default:
					throw new InvalidOperationException();
			}
		}
		
		public CPrefixOperator(string name) : base(name) { }
	}
}
