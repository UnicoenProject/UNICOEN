﻿using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedCall : UnifiedExpression {
		public UnifiedExpression Function { get; set; }
		public UnifiedArgumentCollection Arguments { get; set; }

		public UnifiedCall() {
			Arguments = new UnifiedArgumentCollection();
		}

		public override TResult Accept<TData, TResult>(IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}
	}
}