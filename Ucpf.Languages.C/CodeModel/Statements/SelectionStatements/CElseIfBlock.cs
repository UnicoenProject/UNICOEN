using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C.CodeModel
{
	public class CElseIfBlock : CBlock
	{
		public CExpression ConditionalExpression { get; set; }

		public CElseIfBlock(CExpression conditionalExpression, XElement statementNode) : base(statementNode){
			ConditionalExpression = conditionalExpression;
		}
	}
}
