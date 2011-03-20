using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedIndexer : UnifiedExpression {
		public UnifiedExpression Target { get; set; }
		public UnifiedArgumentCollection Arguments { get; set; }

		public UnifiedIndexer() {
			Arguments = new UnifiedArgumentCollection();
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(
			IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override IEnumerable<UnifiedElement> GetElements() {
			yield return Target;
			yield return Arguments;
		}

		public override IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>> GetElementsAndSetters() {
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
				(Target, v => Target = (UnifiedExpression)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
				(Arguments, v => Arguments = (UnifiedArgumentCollection)v);
		}
	}
}