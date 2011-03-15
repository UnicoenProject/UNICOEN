using Ucpf.Core.Model.Expressions;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedFor : UnifiedExpressionWithBlock<UnifiedFor> {
		public UnifiedExpression Initializer { get; set; }
		public UnifiedExpression Condition { get; set; }
		public UnifiedExpression Step { get; set; }

		public override TResult Accept<TData, TResult>(IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}
	}
}
