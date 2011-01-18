using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Ucpf.Common.Model;
using Ucpf.Common.ModelToCode;

namespace Ucpf.Languages.C.Model {
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