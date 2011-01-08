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
	public class CExpressionStatement : CStatement, IExpressionStatement
	{
		public CExpression Expression { get; set; }

		public new static CExpressionStatement Create(XElement node)
		{
			var judge = node.Element("expression_statement").Element("expression");
			
			if (judge != null)
			{
				return new CExpressionStatement(node);
			}
			else
			{
				return new CEmptyStatement();
			}
		}

		public CExpressionStatement(XElement node)
		{
			var expNode = node.Descendants("expression").First();
			Expression = CExpression.Create(expNode);
		}
		public CExpressionStatement() { }

		public override string ToString()
		{
			return Expression + ";";
		}


		IExpression IExpressionStatement.Expression
		{
			get
			{
				return Expression;
			}
			set
			{
				throw new NotImplementedException();
			}
		}
	}
}
