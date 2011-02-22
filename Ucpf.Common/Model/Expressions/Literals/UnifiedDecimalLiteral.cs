
using Ucpf.Common.Model.Visitors;

namespace Ucpf.Common.Model {
	public class UnifiedDecimalLiteral : UnifiedTypedLiteral<decimal > {
		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override string ToString() {
			return UnifiedModelToXml.ToXml(this).ToString();
		}
	}
}