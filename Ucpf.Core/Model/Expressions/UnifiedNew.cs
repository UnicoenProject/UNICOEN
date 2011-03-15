using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedNew : UnifiedExpression {
		public UnifiedType Type { get; set; }
		public UnifiedArgumentCollection Arguments { get; set; }

		public UnifiedNew() {
			Arguments = new UnifiedArgumentCollection();
		}

		public override TResult Accept<TData, TResult>(IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override IEnumerable<UnifiedElement> GetElements() {
			yield return Type;
			yield return Arguments;
		}
	}
}
