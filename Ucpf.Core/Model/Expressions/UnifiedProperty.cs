using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedProperty : UnifiedExpression {
		public UnifiedExpression Owner { get; set; }
		public string Name { get; set; }

		public override TResult Accept<TData, TResult>(IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}
	}
}
