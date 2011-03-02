using System.Collections.Generic;
using Ucpf.Common.Model.Visitors;

namespace Ucpf.Common.Model {
	public class UnifiedArgumentCollection
		: UnifiedElementCollection<UnifiedArgument> {
		public UnifiedArgumentCollection() {}

		public UnifiedArgumentCollection(IEnumerable<UnifiedArgument> elements)
			: base(elements) {}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
		}
}