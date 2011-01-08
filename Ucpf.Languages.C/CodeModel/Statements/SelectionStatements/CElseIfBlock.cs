using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Ucpf.Common.CodeModel;
using Ucpf.Common.CodeModel;
using Ucpf.Common.CodeModel;
using Ucpf.Common.CodeModelToCode;

namespace Ucpf.Languages.C.CodeModel
{
	public class CElseIfBlock : CBlock, IElseIfBlock
	{
		public CExpression ConditionalExpression { get; set; }

		public CElseIfBlock(CExpression conditionalExpression, XElement statementNode) : base(statementNode){
			ConditionalExpression = conditionalExpression;
		}

		IExpression IElseIfBlock.ConditionalExpression
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

		IList<IStatement> IBlock.Statements
		{
			get { return Statements; }
		}

		public void Accept(ICodeModelToCode conv)
		{
			conv.Generate(this);
		}
	}
}
