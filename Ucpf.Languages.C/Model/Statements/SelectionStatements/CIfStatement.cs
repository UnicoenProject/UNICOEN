using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Ucpf.Common.OldModel;
using Ucpf.Common.OldModel.Expressions;
using Ucpf.Common.OldModel.Statements;

using Ucpf.Common.Visitors;
using Ucpf.Languages.C.Model.Expressions;

namespace Ucpf.Languages.C.Model.Statements.SelectionStatements {
	public class CIfStatement : CSelectionStatement, IIfStatement {
		// properties
		public CIfStatement(XElement ifNode) {
			// ConditionalExpression
			ConditionalExpression =
				CExpression.Create(ifNode.Descendants("expression").First());
			var topNode = ifNode.Element("selection_statement")
				.Elements("statement");

			// TrueBlock
			var compoundStatementNode = topNode
				.First()
				.Element("compound_statement");
			// if(con){ [statement]* }
			if (compoundStatementNode != null) {
				TrueBlock = new CBlock(compoundStatementNode.Element("statement_list"));
			}
				// if(con) [expression_statement]
			else {
				TrueBlock = new CBlock(topNode.First());
			}

			// ElseIfBlock
			if (topNode.Count() > 1) {
				var elseNode = topNode.ElementAt(1);

				var node = elseNode;
				var elseifblocks = new List<IElseIfBlock>();

				while (node != null &&
				       node.Element("selection_statement") != null &&
				       node.Element("selection_statement").Element("TOKEN") != null &&
				       node.Element("selection_statement").Element("TOKEN").Value == "if") {
					var conditionalExpression =
						CExpression.Create(node.Descendants("expression").First());
					var statementNode = node.Element("selection_statement")
						.Element("statement").Element("compound_statement")
						.Element("statement_list");
					var addElement = new CElseIfBlock(conditionalExpression, statementNode);
					elseifblocks.Add(addElement);

					if (node.Element("selection_statement") != null &&
					    node.Element("selection_statement").Elements("statement").Count() > 1) {
						node =
							node.Element("selection_statement").Elements("statement").ElementAt(1);
					} else {
						break;
					}
				}

				ElseIfBlocks = elseifblocks;

				// 'else'
				if (node != null && node.Element("compound_statement") != null) {
					ElseBlock = new CBlock(node.Element("compound_statement")
						.Element("statement_list"));
				}
			} else {
				ElseBlock = null;
			}
		}

		public CExpression ConditionalExpression { get; private set; }
		public CBlock TrueBlock { get; private set; }
		public IList<IElseIfBlock> ElseIfBlocks { get; private set; }
		public CBlock ElseBlock { get; private set; }

		// constructor for parsing AST

		#region IIfStatement Members

		IExpression IIfStatement.Condition {
			get { return ConditionalExpression; }
			set { throw new NotImplementedException(); }
		}

		IBlock IIfStatement.TrueBlock {
			get { return TrueBlock; }
			set { throw new NotImplementedException(); }
		}

		IBlock IIfStatement.FalseBlock {
			get { return ElseBlock; }
			set { throw new NotImplementedException(); }
		}

		public void Accept(IModelToCode conv) {
			conv.Generate(this);
		}

		IList<IElseIfBlock> IIfStatement.ElseIfBlocks {
			get { return ElseIfBlocks; }
			set { throw new NotImplementedException(); }
		}

		#endregion
	}
}