using System;
using System.Xml.Linq;
using Ucpf.Common.Model;
using Ucpf.Common.Model;
using Ucpf.Common.Model;
using Ucpf.Common.ModelToCode;

namespace Ucpf.Languages.JavaScript.Model 
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
		public override void Accept(IModelToCode conv)
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