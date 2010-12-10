using System.Xml.Linq;
using Ucpf.Languages.JavaScript.CodeModel.Operators;

namespace Ucpf.Languages.JavaScript.CodeModel.Expressions {
	public class JSBinaryExpression : JSExpression {
		private readonly XElement _lNode;
		private readonly XElement _rNode;

		public JSBinaryExpression(XElement leftSideNode, JSOperator op,
		                          XElement rightSideNode) {
			_lNode = leftSideNode;
			_rNode = rightSideNode;
			Operator = op;
		}

		public JSExpression Lhs {
			get { return CreateExpression(_lNode); }
		}

		public JSExpression Rhs {
			get { return CreateExpression(_rNode); }
		}

		public JSOperator Operator { private set; get; }
	}
}