using System.Linq;
using System.Xml.Linq;
using Ucpf.Common.Model.Visitors;
using Ucpf.Common.OldModel;
using Ucpf.Common.OldModel.Expressions;
using Ucpf.Common.OldModel.Statements;
using Ucpf.Languages.C.Model.Expressions;

namespace Ucpf.Languages.C.Model.Statements.JumpStatements {
	public class CReturnStatement : CJumpStatement, IReturnStatement {
		// constructor
		public CReturnStatement(XElement node) {
			var expNode = node.Descendants("expression").First();
			Expression = CExpression.Create(expNode);
		}

		// properties
		public CExpression Expression { get; set; }

		#region IReturnStatement Members

		public void Accept(IModelToCode conv) {
			conv.Generate(this);
		}

		IExpression IReturnStatement.Expression {
			get { return Expression; }
		}

		#endregion

		public override string ToString() {
			string str = "return " + Expression;
			return str;
		}
	}
}