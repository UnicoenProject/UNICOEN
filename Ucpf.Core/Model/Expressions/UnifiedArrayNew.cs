using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedArrayNew : UnifiedExpression {
		public UnifiedType Type { get; set; }
		public UnifiedArgumentCollection Arguments { get; set; }
		public UnifiedExpressionCollection InitialValues { get; set; }

		public UnifiedArrayNew() {
			Arguments = new UnifiedArgumentCollection();
			InitialValues = new UnifiedExpressionCollection();
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}