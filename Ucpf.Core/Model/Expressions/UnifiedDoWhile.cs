using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model.Expressions {
	public class UnifiedDoWhile : UnifiedExpressionWithBlock<UnifiedDoWhile> {
		public UnifiedExpression Condition { get; set; }

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}
