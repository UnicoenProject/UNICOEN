using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedParameterCollection
		: UnifiedElementCollection<UnifiedParameter> {
		public UnifiedParameterCollection() {}

		public UnifiedParameterCollection(IEnumerable<UnifiedParameter> elements)
			: base(elements) {}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
		}
}