using System.Xml.Linq;
using Ucpf.Languages.JavaScript.CodeModel;

namespace Ucpf.Languages.JavaScript.CodeModel {

	public class JSBinaryExpression : JSExpression {

		//constructor
		public JSBinaryExpression(XElement leftSideNode, JSBinaryOperator op, XElement rightSideNode) {
			Lhs = JSExpression.CreateExpression(leftSideNode);
			Rhs = JSExpression.CreateExpression(rightSideNode);
			Operator = op;
		}

		//field
		public JSExpression Lhs { get; private set; }
		public JSExpression Rhs { get; private set; }
		public JSBinaryOperator Operator { get; private set; }

		//function
		public new void Accept(JSCodeModelToCode conv)
		{
			conv.Generate(this);
		}

	}
}