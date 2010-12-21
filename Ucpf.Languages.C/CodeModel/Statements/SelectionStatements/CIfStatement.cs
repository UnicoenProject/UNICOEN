using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Ucpf.CodeModel;

namespace Ucpf.Languages.C.CodeModel
{
		public class CIfStatement : CSelectionStatement, IIfStatement
	{
		// properties
		public CExpression ConditionalExpression { get; private set; }
		public CBlock TrueBlock { get; private set; }
		public List<CElseIfBlock> ElseIfBlocks { get; private set; }
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

			// ElseIfBlock
			if (topNode.Count() > 1)
			{
				var elseNode = topNode.ElementAt(1);

				var node = elseNode;
				var elseifblocks = new List<CElseIfBlock>();
				
				while (node != null && 
					node.Element("selection_statement") != null &&
					node.Element("selection_statement").Element("TOKEN") != null &&
					node.Element("selection_statement").Element("TOKEN").Value == "if")
				{
					var conditionalExpression = CExpression.Create(node.Descendants("expression").First());
					var statementNode = node.Element("selection_statement")
						.Element("statement").Element("compound_statement")
						.Element("statement_list");
					var addElement = new CElseIfBlock(conditionalExpression, statementNode);
					elseifblocks.Add(addElement);

					if (node.Element("selection_statement") != null && node.Element("selection_statement").Elements("statement").Count() > 1)
					{
						node = node.Element("selection_statement").Elements("statement").ElementAt(1);
					}
					else
					{
						break;
					}
				}

				ElseIfBlocks = elseifblocks;

				// 'else'
				if (node != null && node.Element("compound_statement") != null)
				{
					ElseBlock = new CBlock(node.Element("compound_statement")
												.Element("statement_list"));
				}

			}

			else
			{
				ElseBlock = null;
			}

		}


		IExpression IIfStatement.Condition
		{
			get
			{
				return ConditionalExpression;
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		IBlock IIfStatement.TrueBlock
		{
			get
			{
				return TrueBlock;
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		IBlock IIfStatement.FalseBlock
		{
			get
			{
				return ElseBlock;
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		IList<IExpression> IStatement.Expressions
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		void ICodeElement.Accept(CodeModelToCode.ICodeModelToCode conv)
		{
			conv.Generate(this);
		}
	}
}