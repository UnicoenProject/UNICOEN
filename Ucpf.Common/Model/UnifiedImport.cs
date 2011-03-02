using System;
using Ucpf.Common.Model.Visitors;

namespace Ucpf.Common.Model {
	public class UnifiedImport : UnifiedElement {
		public string Name { get; set; }

		public override void Accept(IUnifiedModelVisitor visitor) {
			throw new NotImplementedException();
		}
	}
}