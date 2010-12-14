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
		public CExpression ConditionalExpression {get; private set;}
		public CBlock TrueBlock{get; private set;}
		public CBlock ElseBlock { get; private set; }

		// constructor for parsing AST
		public CIfStatement(XElement ifNode)
		{	
			// ConditionalExpression
			ConditionalExpression = CExpression.Create(ifNode.Descendants("expression").First());
			
			// TrueBlock
			var trueList = ifNode.Element("selection_statement")
					.Elements("statement")
					.First()
					.Element("compound_statement")
					.Element("statement_list");
			TrueBlock = new CBlock(trueList);

			// ElseBlock
			var elseList = ifNode.Element("selection_statement")
					.Elements("statement")
					.ElementAt(1)
					.Element("compound_statement")
					.Element("statement_list");
			ElseBlock = new CBlock(elseList);
			
		}
		
	}
}