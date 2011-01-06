using System;
using System.Xml.Linq;
using Ucpf.Common.CodeModel;
using Ucpf.Common.CodeModel.Expressions;
using Ucpf.Common.CodeModel.Statements;
using Ucpf.Common.CodeModelToCode;

namespace Ucpf.Languages.JavaScript.CodeModel {
	// returnStatement
	// : 'return' expression? (LT | ';')
	public class JSReturnStatement : JSStatement, IReturnStatement {

		//constructor
		public JSReturnStatement(XElement node)	: base(node) {
			ReturnExpression = JSExpression.CreateExpression(node.Element("expression"));
		}

		//field
		public JSExpression ReturnExpression { get; private set; }
		
		IExpression IReturnStatement.Expression {
			get {
				return ReturnExpression;
			}
		}

		//function
		public override void Accept(JSCodeModelToCode conv)
		{
			conv.Generate(this);
		}

		void ICodeElement.Accept(ICodeModelToCode conv) {
			conv.Generate(this);
		}

		public override string ToString()
		{
			return "return" + ReturnExpression.ToString();
		}

	}
}