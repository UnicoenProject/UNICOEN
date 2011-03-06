using System;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedIndexer : UnifiedExpression {
		public UnifiedExpression Target { get; set; }
		public UnifiedArgumentCollection Arguments { get; set; }

		public UnifiedIndexer() {
			Arguments = new UnifiedArgumentCollection();
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			throw new NotImplementedException();
		}
	}
}
