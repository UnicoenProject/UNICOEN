using Ucpf.Common.Model.Visitors;

namespace Ucpf.Common.Model {
	public class UnifiedIf : UnifiedExpression {
		public UnifiedExpression Condition { get; set; }
		public UnifiedBlock TrueBlock { get; set; }
		public UnifiedBlock FalseBlock { get; set; }

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}