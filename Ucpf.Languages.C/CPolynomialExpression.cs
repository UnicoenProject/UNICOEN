using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C
{
	public class CPolynomialExpression : CExpression
	{
		private COperator Operator;
		private CValue Value;

		public override string ToString()
		{
			return Operator.ToString() + Value.ToString();
		}

		// constructor
		public CPolynomialExpression(XElement node)
			: base(node, "polynomial") { }
	}
}
