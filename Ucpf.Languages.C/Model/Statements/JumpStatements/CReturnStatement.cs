using System.Linq;
using System.Xml.Linq;
using Ucpf.Common.Model;
using Ucpf.Common.ModelToCode;

namespace Ucpf.Languages.C.Model {
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