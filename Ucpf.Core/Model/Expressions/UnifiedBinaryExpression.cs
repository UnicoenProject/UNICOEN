using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	/// <summary>
	///   二項式を表します。
	/// </summary>
	public class UnifiedBinaryExpression : UnifiedElement, IUnifiedExpression {
		private IUnifiedExpression _leftHandSide;

		public IUnifiedExpression LeftHandSide {
			get { return _leftHandSide; }
			set { _leftHandSide = SetParentOfChild(value, _leftHandSide); }
		}

		private UnifiedBinaryOperator _operator;

		public UnifiedBinaryOperator Operator {
			get { return _operator; }
			set { _operator = SetParentOfChild(value, _operator); }
		}

		private IUnifiedExpression _rightHandSide;

		public IUnifiedExpression RightHandSide {
			get { return _rightHandSide; }
			set { _rightHandSide = SetParentOfChild(value, _rightHandSide); }
		}

		private UnifiedBinaryExpression() {}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override void Accept<TData>(IUnifiedModelVisitor<TData> visitor,
		                                   TData data) {
			visitor.Visit(this, data);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override IEnumerable<IUnifiedElement> GetElements() {
			yield return LeftHandSide;
			yield return Operator;
			yield return RightHandSide;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(LeftHandSide, v => LeftHandSide = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Operator, v => Operator = (UnifiedBinaryOperator)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(RightHandSide, v => RightHandSide = (IUnifiedExpression)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndDirectSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_leftHandSide, v => _leftHandSide = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_operator, v => _operator = (UnifiedBinaryOperator)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_rightHandSide, v => _rightHandSide = (IUnifiedExpression)v);
		}

		public static UnifiedBinaryExpression Create(IUnifiedExpression leftHandSide,
		                                             UnifiedBinaryOperator
		                                             		binaryOperator,
		                                             IUnifiedExpression rightHandSide) {
			return new UnifiedBinaryExpression {
					LeftHandSide = leftHandSide,
					Operator = binaryOperator,
					RightHandSide = rightHandSide,
			};
		}
	}
}