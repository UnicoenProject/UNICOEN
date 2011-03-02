using System.Collections.Generic;
using Ucpf.Common.Model.Visitors;

namespace Ucpf.Common.Model {
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