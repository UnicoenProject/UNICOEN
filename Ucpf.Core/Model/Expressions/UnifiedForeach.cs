using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Expressions;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedForeach : UnifiedExpressionWithBlock<UnifiedForeach> {
		public UnifiedVariableDefinition Element { get; set; }
		public UnifiedExpression Set { get; set; }

		public override TResult Accept<TData, TResult>(IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override IEnumerable<UnifiedElement> GetElements() {
			yield return Element;
			yield return Set;
			yield return Body;
		}
	}
}
