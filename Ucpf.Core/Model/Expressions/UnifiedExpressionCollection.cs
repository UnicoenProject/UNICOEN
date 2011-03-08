using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ucpf.Common.Model.Visitors;

namespace Ucpf.Common.Model.Expressions {
	public class UnifiedExpressionCollection : UnifiedElementCollection<UnifiedExpression> {
		public UnifiedExpressionCollection() { }

		public UnifiedExpressionCollection(IEnumerable<UnifiedExpression> expressions) : base(expressions) { }

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}
