using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C.CodeModel
{
	public class CAssignmentOperator : COperator
	{
		// constructor
		public CAssignmentOperator(string name) : base(name) { }
		
		public static CAssignmentOperator CreateAssignmentOperator(XElement opeNode)
		{
			var sw = opeNode.Value;

			switch (sw)
			{
				case "=":
					return new CPrimaryAssignmentOperator();
				default:
					throw new NotImplementedException();
			}
		}

		
	}
}
