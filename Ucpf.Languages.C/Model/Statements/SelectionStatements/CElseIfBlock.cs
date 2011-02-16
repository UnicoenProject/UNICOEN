using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Ucpf.Common.ModelToCode;
using Ucpf.Common.OldModel;
using Ucpf.Common.OldModel.Expressions;
using Ucpf.Common.OldModel.Statements;
using Ucpf.Languages.C.Model.Expressions;

namespace Ucpf.Languages.C.Model.Statements.SelectionStatements {
	public class CElseIfBlock : CBlock, IElseIfBlock {
		public CElseIfBlock(CExpression conditionalExpression, XElement statementNode)
			: base(statementNode) {
			ConditionalExpression = conditionalExpression;
		}

		public CExpression ConditionalExpression { get; set; }

		#region IElseIfBlock Members

		IExpression IElseIfBlock.ConditionalExpression {
			get { return ConditionalExpression; }
			set { throw new NotImplementedException(); }
		}

		IList<IStatement> IBlock.Statements {
			get { return Statements; }
		}

		public void Accept(IModelToCode conv) {
			conv.Generate(this);
		}

		#endregion
	}
}