using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C.CodeModel
{
	public class CSelectionStatement : CStatement
	{
		public static CSelectionStatement CreateSelectionStatement(XElement node)
		{
			// SelectionStatement is consisted of IfStatement and SwitchStatement
			// node :: statement
			var sw = node.Element("selection_statement").Elements("TOKEN").First().Value;
			switch (sw)
			{
				case "if":
					return new CIfStatement(node);
				case "switch":
					throw new NotImplementedException();
				// return new CSwitchStatement(node)
				default:
					throw new InvalidOperationException();
			}
		}
	}
}
