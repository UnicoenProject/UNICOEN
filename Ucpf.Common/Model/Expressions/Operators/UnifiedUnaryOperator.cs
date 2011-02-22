using Ucpf.Common.OldModel.Operators;

using Ucpf.Common.Visitors;

namespace Ucpf.Common.Model {
	public class UnifiedUnaryOperator : UnifiedElement {
		public string Sign { get; private set; }
		public UnaryOperatorType Type { get; private set; }

		public UnifiedUnaryOperator(string sign, UnaryOperatorType type) {
			Sign = sign;
			Type = type;
		}

		public override void Accept(IUnifiedModelVisitor conv) {
			conv.Visit(this);
		}

		public override string ToString() {
			return UnifiedModelToXml.ToXml(this).ToString();
		}
	}
}