using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedExpressionCollection
			: UnifiedElementCollection<IUnifiedExpression>, IUnifiedExpression {
		public UnifiedExpressionCollection() {}

		public UnifiedExpressionCollection(IEnumerable<IUnifiedExpression> expressions)
				: base(expressions) {}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}
			}
}