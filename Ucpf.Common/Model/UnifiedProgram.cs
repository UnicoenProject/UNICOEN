using System.Collections.Generic;
using Ucpf.Common.Model.Visitors;

namespace Ucpf.Common.Model {
	public class UnifiedProgram : UnifiedElementCollection<UnifiedExpression> {
		public UnifiedProgram() {}

		public UnifiedProgram(IEnumerable<UnifiedExpression> elements)
			: base(elements) {}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}