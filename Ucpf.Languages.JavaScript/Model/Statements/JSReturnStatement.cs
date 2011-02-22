using System.Xml.Linq;
using Ucpf.Common.OldModel.Expressions;
using Ucpf.Common.OldModel.Statements;

using Ucpf.Common.Visitors;
using Ucpf.Languages.JavaScript.Model.Expressions;

namespace Ucpf.Languages.JavaScript.Model.Statements {
	// returnStatement
	// : 'return' expression? (LT | ';')

	public class JSReturnStatement : JSStatement, IReturnStatement {
		//property

		//constructor
		public JSReturnStatement(XElement node) {
			ReturnExpression = JSExpression.CreateExpression(node.Element("expression"));
		}

		public JSExpression ReturnExpression { get; private set; }

		//function

		#region IReturnStatement Members

		public override void Accept(IModelToCode conv) {
			conv.Generate(this);
		}

		//Common-Interface
		IExpression IReturnStatement.Expression {
			get { return ReturnExpression; }
		}

		#endregion

		public override string ToString() {
			return "return" + ReturnExpression;
		}
	}
}