using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedExpressionCollection : UnifiedElementCollection<UnifiedExpression> {
		public UnifiedExpressionCollection() { }

		public UnifiedExpressionCollection(IEnumerable<UnifiedExpression> expressions) : base(expressions) { }

		public override TResult Accept<TData, TResult>(IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override IEnumerable<UnifiedElement> GetElements() {
			return this;
		}
	}
}
