using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedBooleanLiteral : UnifiedTypedLiteral<UnifiedBoolean> {
		public override TResult Accept<TData, TResult>(IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}
	}
}