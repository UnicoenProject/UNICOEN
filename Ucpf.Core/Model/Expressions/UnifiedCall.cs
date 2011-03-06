using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedCall : UnifiedExpression {
		public UnifiedExpression Function { get; set; }
		public UnifiedArgumentCollection Arguments { get; set; }

		public UnifiedCall() {
			Arguments = new UnifiedArgumentCollection();
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}