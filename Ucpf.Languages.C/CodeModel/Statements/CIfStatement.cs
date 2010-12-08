using System.Linq;
using System.Xml.Linq;
using Ucpf.Languages.C.CodeModel.Expressions;

namespace Ucpf.Languages.C.CodeModel.Statements
{
	public class CIfStatement : CStatement
	{
		private XElement _ifnode;		// statemenet

		public CExpression ConditionalExpression
		{
			get
			{
				return CExpression.Create(_ifnode.Descendants("expression").First());
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