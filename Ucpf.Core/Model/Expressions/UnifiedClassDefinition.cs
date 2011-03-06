using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedClassDefinition : UnifiedExpression {
		public string Name { get; set; }
		public UnifiedBlock Body { get; set; }

		public UnifiedClassDefinition() {
			Body = new UnifiedBlock();
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}