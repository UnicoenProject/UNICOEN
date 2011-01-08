using System;
using System.Xml.Linq;
using Ucpf.Common.CodeModel;
using Ucpf.Common.CodeModel;
using Ucpf.Common.CodeModel;
using Ucpf.Common.CodeModelToCode;

namespace Ucpf.Languages.JavaScript.CodeModel 
{
	// returnStatement
	// : 'return' expression? (LT | ';')

	public class JSReturnStatement : JSStatement, IReturnStatement
	{
		//property
		public JSExpression ReturnExpression { get; private set; }
		
		//constructor
		public JSReturnStatement(XElement node)
		{
			ReturnExpression = JSExpression.CreateExpression(node.Element("expression"));
		}

		//function
		public override void Accept(ICodeModelToCode conv)
		{
			conv.Generate(this);
		}

		public override string ToString()
		{
			return "return" + ReturnExpression.ToString();
		}

		//Common-Interface
		IExpression IReturnStatement.Expression
		{
			get {
				return ReturnExpression;
			}
		}
	}
}