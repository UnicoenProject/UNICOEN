using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedBinaryExpression : UnifiedExpression {
		private UnifiedBinaryOperator _operator;

		public UnifiedBinaryOperator Operator {
			get { return _operator; }
			set {
				_operator = value;
				if (value != null) value.Parent = this;
			}
		}

		private UnifiedExpression _leftHandSide;

		public UnifiedExpression LeftHandSide {
			get { return _leftHandSide; }
			set {
				_leftHandSide = value;
				if (value != null) value.Parent = this;
			}
		}

		private UnifiedExpression _rightHandSide;

		public UnifiedExpression RightHandSide {
			get { return _rightHandSide; }
			set {
				_rightHandSide = value;
				if (value != null) value.Parent = this;
			}
		}

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

		public override IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>>
			GetElementsAndSetters() {
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
				(LeftHandSide, v => LeftHandSide = (UnifiedExpression)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
				(Operator, v => Operator = (UnifiedBinaryOperator)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
				(RightHandSide, v => RightHandSide = (UnifiedExpression)v);
		}
	}
}