using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedFor : UnifiedExpression {
		public UnifiedExpression Initializer { get; set; }
		public UnifiedExpression Condition { get; set; }
		public UnifiedExpression Step { get; set; }
		public UnifiedBlock Block { get; set; }

		public UnifiedFor() {
			Block = new UnifiedBlock();
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}
