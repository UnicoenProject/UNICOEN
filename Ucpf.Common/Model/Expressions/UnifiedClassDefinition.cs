using System;
using Ucpf.Common.Model.Visitors;

namespace Ucpf.Common.Model {
	public class UnifiedClassDefinition : UnifiedElement {
		public string Name { get; set; }
		public UnifiedBlock Body { get; set; }

		public override void Accept(IUnifiedModelVisitor conv) {
			throw new NotImplementedException();
		}
	}
}