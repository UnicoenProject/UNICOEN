using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C.CodeModel
{
	public class CComparisonOperator : COperator
	{
		public static CComparisonOperator CreateComparisonOperator(XElement opeNode)
		{
			var sw = opeNode.Value;

			switch (sw)
			{
				case "==":
					return new CEqualOperator();
				case "!=":
					return new CNotEqualOperator();
				case ">":
					return new CGreaterOperator();
				case ">=":
					return new CGreaterOrEqualOperator();
				case "<":
					return new CLessOperator();
				case "<=":
					return new CLessOrEqualOperator();
				default:
					throw new InvalidOperationException();
			}

		}

		// constructor
		public CComparisonOperator(string name) : base(name) { }
	}
}
