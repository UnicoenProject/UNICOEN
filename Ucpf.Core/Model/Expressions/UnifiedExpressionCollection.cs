using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	// TODO: 継承関係がおかしい？ブロックとの差別化
	public class UnifiedExpressionCollection
			: UnifiedElementCollection<IUnifiedExpression> {
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