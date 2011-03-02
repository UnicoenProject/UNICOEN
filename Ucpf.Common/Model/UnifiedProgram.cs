using Ucpf.Common.Model.Visitors;

namespace Ucpf.Common.Model {
	public class UnifiedProgram : UnifiedElementCollection<UnifiedExpression> {
		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}