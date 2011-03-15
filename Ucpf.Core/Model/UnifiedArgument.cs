using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedArgument : UnifiedElement {
		public UnifiedExpression Value { get; set; }

		public override TResult Accept<TData, TResult>(IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override IEnumerable<UnifiedElement> GetElements() {
			yield return Value;
		}

		public static UnifiedArgument Create(UnifiedExpression exprssion) {
			return new UnifiedArgument { Value = exprssion };
		}
	}
}