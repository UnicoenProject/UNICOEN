using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedExpressionList
			: UnifiedElementCollection<IUnifiedExpression, UnifiedExpressionList>,
			  IUnifiedExpression {
		protected UnifiedExpressionList() {}

		protected UnifiedExpressionList(
				IEnumerable<IUnifiedExpression> expressions)
				: base(expressions) {}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override void Accept<TData>(IUnifiedModelVisitor<TData> visitor,
		                                   TData data) {
			visitor.Visit(this, data);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public static UnifiedExpressionList Create() {
			return new UnifiedExpressionList();
		}

		public static UnifiedExpressionList Create(
				params IUnifiedExpression[] elements) {
			return new UnifiedExpressionList(elements);
		}

		public static UnifiedExpressionList Create(
				IEnumerable<IUnifiedExpression> elements) {
			return new UnifiedExpressionList(elements);
		}
			  }
}