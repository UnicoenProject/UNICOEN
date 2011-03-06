using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedProgram : UnifiedElementCollection<UnifiedExpression> {
		public UnifiedProgram() {}

		public UnifiedProgram(IEnumerable<UnifiedExpression> elements)
			: base(elements) {}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}