using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedProgram : UnifiedElementCollection<UnifiedExpression> {
		public UnifiedProgram() {}

		public UnifiedProgram(IEnumerable<UnifiedExpression> elements)
			: base(elements) {}

		public override TResult Accept<TData, TResult>(IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}
	}
}