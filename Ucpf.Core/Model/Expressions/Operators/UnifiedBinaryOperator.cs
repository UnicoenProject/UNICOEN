using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedBinaryOperator : UnifiedElement {
		public string Sign { get; private set; }
		public UnifiedBinaryOperatorType Type { get; private set; }

		public UnifiedBinaryOperator(string sign, UnifiedBinaryOperatorType type) {
			Sign = sign;
			Type = type;
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}