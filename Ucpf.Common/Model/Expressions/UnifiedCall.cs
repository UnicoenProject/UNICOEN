using Ucpf.Common.Model.Visitors;

namespace Ucpf.Common.Model {
	public class UnifiedCall : UnifiedExpression {
		public UnifiedExpression Function { get; set; }
		public UnifiedArgumentCollection Arguments { get; set; }

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}