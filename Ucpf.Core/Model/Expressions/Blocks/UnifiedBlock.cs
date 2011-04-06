using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedBlock : UnifiedElementCollection<IUnifiedExpression, UnifiedBlock>, IUnifiedExpression {
		private UnifiedBlock() {}

		private UnifiedBlock(IEnumerable<IUnifiedExpression> expressions)
				: base(expressions) {}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public static UnifiedBlock Create() {
			return new UnifiedBlock();
		}

		public static UnifiedBlock Create(IUnifiedExpression expression) {
			return new UnifiedBlock(new[] { expression });
		}

		public static UnifiedBlock Create(IEnumerable<IUnifiedExpression> expressions) {
			return new UnifiedBlock(expressions);
		}
	}
}