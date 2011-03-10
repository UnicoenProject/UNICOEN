using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ucpf.Core.Model.Expressions {
	public abstract class UnifiedExpressionWithBlock<T> : UnifiedExpression
		where T : UnifiedExpressionWithBlock<T>
	{
		public UnifiedBlock Body { get; set; }

		protected UnifiedExpressionWithBlock() {
			Body = new UnifiedBlock();
		}

		public T AddToBody(UnifiedExpression expression) {
			Body.Add(expression);
			return (T)this;
		}
	}
}
