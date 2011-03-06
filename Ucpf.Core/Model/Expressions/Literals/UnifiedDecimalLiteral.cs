using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model.Expressions.Literals {
	public class UnifiedDecimalLiteral : UnifiedTypedLiteral<decimal> {
		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}