using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model.Expressions {
	public class UnifiedWhile : UnifiedExpressionWithBlock<UnifiedFunctionDefinition> {
		public UnifiedExpression Condition { get; set; }

		public override TResult Accept<TData, TResult>(IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}
	}
}
