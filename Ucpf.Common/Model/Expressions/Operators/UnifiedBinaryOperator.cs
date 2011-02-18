using Ucpf.Common.OldModel.Operators;
using Ucpf.Common.Visitors;

namespace Ucpf.Common.Model {
	public class UnifiedBinaryOperator : UnifiedElement {
		public string Sign { get; private set; }
		public BinaryOperatorType Type { get; private set; }

		public UnifiedBinaryOperator(string sign, BinaryOperatorType type) {
			Sign = sign;
			Type = type;
		}

		public override void Accept(IUnifiedModelVisitor conv) {
			conv.Visit(this);
		}
	}
}