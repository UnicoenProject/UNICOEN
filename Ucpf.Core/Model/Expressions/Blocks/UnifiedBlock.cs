using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedBlock : UnifiedElementCollection<IUnifiedExpression>, IUnifiedExpression {
		public UnifiedBlock() {}

		public UnifiedBlock(IEnumerable<IUnifiedExpression> expressions)
				: base(expressions) {}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override IUnifiedElement Normalize() {
			NormalizeChildren();
			if (Elements.Count == 1) {
				var block = Elements[0] as UnifiedBlock;
				if (block != null)
					return block;
			}
			return this;
		}
	}
}