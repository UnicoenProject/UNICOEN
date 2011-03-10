using Ucpf.Core.Model.Expressions;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedFor : UnifiedExpressionWithBlock<UnifiedFor> {
		public UnifiedExpression Initializer { get; set; }
		public UnifiedExpression Condition { get; set; }
		public UnifiedExpression Step { get; set; }

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}
