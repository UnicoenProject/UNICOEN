using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Ucpf.CodeModel;

namespace Ucpf.Languages.C.CodeModel
{
	public class CReturnStatement : CJumpStatement, IReturnStatement
	{
		public CReturnStatement(XElement node) : base(node) { }

		public override string ToString()
		{
			string str = "return ";
			foreach (CExpression s in Expressions)
			{
				str += s.ToString();
			}
			return str;
		}



		void ICodeElement.Accept(CodeModelToCode.ICodeModelToCode conv)
		{
			conv.Generate(this);
		}

		IExpression IReturnStatement.Return
		{
			get { throw new NotImplementedException(); }
		}

		IList<IExpression> IStatement.Expressions
		{
			get
			{
				return Expressions;
			}
			set
			{
				throw new NotImplementedException();
			}
		}
	}
}
