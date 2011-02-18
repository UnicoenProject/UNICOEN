
using Ucpf.Common.Visitors;

namespace Ucpf.Common.Model {
	public class UnifiedBooleanLiteral : UnifiedTypedLiteral<UnifiedBoolean> {
		public override void Accept(IUnifiedModelVisitor conv) {
			conv.Visit(this);
		}
	}
}