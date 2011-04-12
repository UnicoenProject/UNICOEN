using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model
{
	/// <summary>
	///   単項式を表します。
	/// </summary>
	public class UnifiedUnaryExpression : UnifiedElement, IUnifiedExpression
	{
		private UnifiedUnaryOperator _operator;

		public UnifiedUnaryOperator Operator
		{
			get { return _operator; }
			set { _operator = SetParentOfChild(value, _operator); }
		}

		private IUnifiedExpression _operand;

		public IUnifiedExpression Operand
		{
			get { return _operand; }
			set { _operand = SetParentOfChild(value, _operand); }
		}

		private UnifiedUnaryExpression() {}

		public override void Accept(IUnifiedModelVisitor visitor)
		{
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(
			IUnifiedModelVisitor<TData, TResult> visitor, TData data)
		{
			return visitor.Visit(this, data);
		}

		public override IEnumerable<IUnifiedElement> GetElements()
		{
			yield return Operator;
			yield return Operand;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndSetters()
		{
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Operator, v => Operator = (UnifiedUnaryOperator)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Operand, v => Operand = (IUnifiedExpression)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndDirectSetters()
		{
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_operator, v => _operator = (UnifiedUnaryOperator)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_operand, v => _operand = (IUnifiedExpression)v);
		}

		public override IUnifiedElement Normalize()
		{
			NormalizeChildren();
			var operand = Operand as UnifiedIntegerLiteral;
			if (operand != null) {
				if (Operator.Kind == UnifiedUnaryOperatorKind.UnaryPlus) {
					return operand;
				}
				if (Operator.Kind == UnifiedUnaryOperatorKind.Negate) {
					operand.Value = -operand.Value;
					return operand;
				}
			}
			return this;
		}

		public static UnifiedUnaryExpression Create(IUnifiedExpression operand,
		                                            UnifiedUnaryOperator unaryOperator)
		{
			return new UnifiedUnaryExpression {
				Operand = operand,
				Operator = unaryOperator,
			};
		}
	}
}