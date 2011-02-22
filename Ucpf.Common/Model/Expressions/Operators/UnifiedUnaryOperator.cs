using Ucpf.Common.Model.Visitors;
using Ucpf.Common.OldModel.Operators;

namespace Ucpf.Common.Model {
	public class UnifiedUnaryOperator : UnifiedElement {
		public string Sign { get; private set; }
		public UnaryOperatorType Type { get; private set; }

		public UnifiedUnaryOperator(string sign, UnaryOperatorType type) {
			Sign = sign;
			Type = type;
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override string ToString() {
			return UnifiedModelToXml.ToXml(this).ToString();
		}
	}
}