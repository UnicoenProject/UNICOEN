using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Ucpf.Common.Model;
using Ucpf.Common.Model;
using Ucpf.Common.Model;
using Ucpf.Common.ModelToCode;

namespace Ucpf.Languages.C.Model
{
	public class CReturnStatement : CJumpStatement, IReturnStatement
	{
		// constructor
		public CReturnStatement(XElement node)
		{
			var expNode = node.Descendants("expression").First();
			Expression = CExpression.Create(expNode);
		}

		// properties
		public CExpression Expression { get; set; }

		public override string ToString()
		{
			string str = "return " + Expression.ToString();
			return str;
		}

		public void Accept(IModelToCode conv)
		{
			conv.Generate(this);
		}

		IExpression IReturnStatement.Expression
		{
			get { return Expression; }
		}


	}
}
