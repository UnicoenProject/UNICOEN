using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model.Expressions {
	public class UnifiedIf : UnifiedExpression {
		public UnifiedExpression Condition { get; set; }
		public UnifiedBlock TrueBlock { get; set; }
		public UnifiedBlock FalseBlock { get; set; }

		public UnifiedIf() {
			TrueBlock = new UnifiedBlock();
			FalseBlock = new UnifiedBlock();
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}