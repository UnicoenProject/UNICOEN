using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedForeach : UnifiedExpression {
		public UnifiedVariableDefinition Element { get; set; }
		public UnifiedExpression Set { get; set; }
		public UnifiedBlock Block { get; set; }

		public UnifiedForeach() {
			Block = new UnifiedBlock();
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}
