using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C.CodeModel
{
	public class CArithmeticOperator : COperator {
		public CArithmeticOperator(string name) : base(name) { }

		public static new CArithmeticOperator Create(XElement opeNode)
		{
			var sw = opeNode.Value;

			switch (sw)
			{
				case "+" :
					return new CPlusOperator();
				case "-" :
					return new CMinusOperator();
				case "*" :
					return new CMultiOperator();
				case "/" :
					return new CDivOperator();
				case "%" :
					return new CModOperator();
				default :
					throw new InvalidOperationException();
			}
		}
	}
}
