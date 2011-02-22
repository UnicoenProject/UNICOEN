using Ucpf.Common.Model.Visitors;
using Ucpf.Common.OldModel.Operators;

namespace Ucpf.Common.Model {
	public class UnifiedBinaryOperator : UnifiedElement {
		public string Sign { get; private set; }
		public BinaryOperatorType Type { get; private set; }

		public UnifiedBinaryOperator(string sign, BinaryOperatorType type) {
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