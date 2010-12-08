using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C
{
	public class CIfStatement : CSelectionStatement
	{
		private XElement _ifnode;		// statemenet

		public CExpression ConditionalExpression
		{
			get
			{
				return CExpression.CreateExpression(_ifnode.Descendants("expression").First());
				// return _node.Descendants("expression").First().Value;
			}
		}
		public CBlock TrueBlock
		{
			get
			{
				var list = _ifnode.Element("selection_statement")
					.Elements("statement")
					.First()
					.Element("compound_statement")
					.Element("statement_list");
				return new CBlock(list);
			}
		}
		public CBlock ElseBlock
		{
			get
			{
				var list = _ifnode.Element("selection_statement")
					.Elements("statement")
					.ElementAt(1)
					.Element("compound_statement")
					.Element("statement_list");
				return new CBlock(list);
			}
		}
		// constructor
		public CIfStatement(XElement node){
			_ifnode = node;
		}


	}
}