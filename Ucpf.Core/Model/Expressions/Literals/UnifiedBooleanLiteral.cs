using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model.Expressions.Literals {
	public class UnifiedBooleanLiteral : UnifiedTypedLiteral<UnifiedBoolean> {
		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}