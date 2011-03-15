using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedBinaryOperator : UnifiedElement {
		public string Sign { get; private set; }
		public UnifiedBinaryOperatorType Type { get; private set; }

		public UnifiedBinaryOperator(string sign, UnifiedBinaryOperatorType type) {
			Sign = sign;
			Type = type;
		}

		public override TResult Accept<TData, TResult>(IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}
	}
}