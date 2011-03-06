using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model.Expressions.Operators {
	public class UnifiedUnaryOperator : UnifiedElement {
		public string Sign { get; private set; }
		public UnifiedUnaryOperatorType Type { get; private set; }

		public UnifiedUnaryOperator(string sign, UnifiedUnaryOperatorType type) {
			Sign = sign;
			Type = type;
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}