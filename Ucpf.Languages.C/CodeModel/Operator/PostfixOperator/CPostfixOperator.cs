using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C.CodeModel
{
	public class CPostfixOperator : COperator
	{
		public static CPostfixOperator CreatePostfixOperator(XElement opeNode)
		{
			var sw = opeNode.Value;
			switch (sw)
			{
				case "++":
					return new CPostfixIncrementOperator();
				case "--":
					return new CPostfixDecrementOperator();
				default:
					throw new InvalidOperationException();
			}
		}

		// constructor
		public CPostfixOperator(string name) : base(name) { } 
	}
}
