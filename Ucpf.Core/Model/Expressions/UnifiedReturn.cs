using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedReturn : UnifiedExpression {
		public UnifiedExpression Value { get; set; }

		public override TResult Accept<TData, TResult>(IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}
	}
}