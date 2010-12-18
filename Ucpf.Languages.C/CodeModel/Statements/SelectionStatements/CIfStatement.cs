using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C.CodeModel
{
	public class CIfStatement : CSelectionStatement
	{
		// properties
		public CExpression ConditionalExpression { get; private set; }
		public CBlock TrueBlock { get; private set; }
		public CBlock ElseBlock { get; private set; }

		// constructor for parsing AST
		public CIfStatement(XElement ifNode)
		{
			// ConditionalExpression
			ConditionalExpression = CExpression.Create(ifNode.Descendants("expression").First());
			var topNode = ifNode.Element("selection_statement")
							.Elements("statement");

			// TrueBlock
			var trueList = topNode
					.First()
					.Element("compound_statement")
					.Element("statement_list");
			TrueBlock = new CBlock(trueList);

			// ElseBlock
			if (topNode.Count() > 1)
			{
				var elseNode = topNode.ElementAt(1);

				// 'else'
				if (elseNode.Element("compound_statement") != null)
				{
					ElseBlock = new CBlock(elseNode.Element("compound_statement")
												.Element("statement_list"));
				}
				// 'else if'
				else
				{
					ElseBlock = new CBlock(elseNode);
				}
			}

			else
			{
				ElseBlock = null;
			}

		}

	}
}