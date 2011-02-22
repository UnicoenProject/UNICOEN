
using Ucpf.Common.Visitors;

namespace Ucpf.Common.Model {
	public class UnifiedDecimalLiteral : UnifiedTypedLiteral<decimal > {
		public override void Accept(IUnifiedModelVisitor conv) {
			conv.Visit(this);
		}
	}
}