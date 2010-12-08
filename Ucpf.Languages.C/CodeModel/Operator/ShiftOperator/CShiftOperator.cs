using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C
{
	public class CShiftOperator : COperator
	{
		public static CShiftOperator CreateShiftOperator(XElement opeNode)
		{
			var sw = opeNode.Value;
			switch (sw)
			{
				case "<<":
					return new CLeftShiftOperator();
				case ">>":
					return new CRightShiftOperator();
				default:
					throw new InvalidOperationException();
			}
		}

		// constructor
		public CShiftOperator(string name) : base(name) { }
	}
}
