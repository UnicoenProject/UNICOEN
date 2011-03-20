using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedBinaryExpression : UnifiedExpression {
		public UnifiedBinaryOperator Operator { get; set; }
		public UnifiedExpression LeftHandSide { get; set; }
		public UnifiedExpression RightHandSide { get; set; }

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(
			IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override IEnumerable<UnifiedElement> GetElements() {
			yield return LeftHandSide;
			yield return Operator;
			yield return RightHandSide;
		}

		public override IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>> GetElementsAndSetters() {
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
				(LeftHandSide, v => LeftHandSide = (UnifiedExpression)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
				(Operator, v => Operator = (UnifiedBinaryOperator)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
				(RightHandSide, v => RightHandSide = (UnifiedExpression)v);
		}
	}
}