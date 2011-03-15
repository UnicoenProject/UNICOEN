using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedBinaryExpression : UnifiedExpression {
		public UnifiedBinaryOperator Operator { get; set; }
		public UnifiedExpression LeftHandSide { get; set; }
		public UnifiedExpression RightHandSide { get; set; }

		public override TResult Accept<TData, TResult>(IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}
	}
}