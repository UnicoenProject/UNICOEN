
using Ucpf.Common.Visitors;

namespace Ucpf.Common.Model {
	public class UnifiedStringLiteral : UnifiedTypedLiteral<string> {
		public override void Accept(IUnifiedModelVisitor conv) {
			conv.Visit(this);
		}
	}
}