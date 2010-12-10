using System.Xml.Linq;
using Ucpf.Languages.JavaScript.CodeModel;

namespace Ucpf.Languages.JavaScript.CodeModel {
	// returnStatement
	// : 'return' expression? (LT | ';')
	public class JSReturnStatement : JSStatement {
		private readonly XElement _node;

		public JSReturnStatement(XElement xElement)
			: base(xElement) {
			_node = xElement;
		}

		public JSExpression ReturnExpression {
			get {
				//TODO ReturnStatement may have no expression (It means "return;")
				return JSExpression.CreateExpression(_node.Element("expression"));
			}
		}
	}
}