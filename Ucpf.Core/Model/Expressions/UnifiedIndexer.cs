using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedIndexer : UnifiedExpression {
		public UnifiedExpression Target { get; set; }
		public UnifiedArgumentCollection Arguments { get; set; }

		public UnifiedIndexer() {
			Arguments = new UnifiedArgumentCollection();
		}

		public override TResult Accept<TData, TResult>(IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			throw new NotImplementedException();
		}

		public override IEnumerable<UnifiedElement> GetElements() {
			yield return Target;
			yield return Arguments;
		}
	}
}
