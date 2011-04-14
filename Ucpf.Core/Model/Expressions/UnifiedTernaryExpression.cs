using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model
{
	public class UnifiedTernaryExpression : UnifiedElement, IUnifiedExpression
	{
		private IUnifiedExpression _firstExpression;

		public IUnifiedExpression FirstExpression
		{
			get { return _firstExpression; }
			set { _firstExpression = SetParentOfChild(value, _firstExpression); }
		}

		private UnifiedTernaryOperator _operator;

		public UnifiedTernaryOperator Operator
		{
			get { return _operator; }
			set { _operator = SetParentOfChild(value, _operator); }
		}

		private IUnifiedExpression _secondExpression;

		public IUnifiedExpression SecondExpression
		{
			get { return _secondExpression; }
			set { _secondExpression = SetParentOfChild(value, _secondExpression); }
		}

		private IUnifiedExpression _lastExpression;

		public IUnifiedExpression LastExpression
		{
			get { return _lastExpression; }
			set { _lastExpression = SetParentOfChild(value, _lastExpression); }
		}

		private UnifiedTernaryExpression() {}

		public override void Accept(IUnifiedModelVisitor visitor)
		{
			visitor.Visit(this);
		}

		public override void Accept<TData>(IUnifiedModelVisitor<TData> visitor,
		                                   TData data)
		{
			visitor.Visit(this, data);
		}

		public override TResult Accept<TData, TResult>(
			IUnifiedModelVisitor<TData, TResult> visitor, TData data)
		{
			return visitor.Visit(this, data);
		}

		public override IEnumerable<IUnifiedElement> GetElements()
		{
			yield return FirstExpression;
			yield return Operator;
			yield return SecondExpression;
			yield return LastExpression;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndSetters()
		{
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(FirstExpression, v => FirstExpression = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Operator, v => Operator = (UnifiedTernaryOperator)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(SecondExpression, v => SecondExpression = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(LastExpression, v => LastExpression = (IUnifiedExpression)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndDirectSetters()
		{
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_firstExpression, v => _firstExpression = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_operator, v => _operator = (UnifiedTernaryOperator)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_secondExpression, v => _secondExpression = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_lastExpression, v => _lastExpression = (IUnifiedExpression)v);
		}

		public static UnifiedTernaryExpression Create(
			IUnifiedExpression firstExpression,
			UnifiedTernaryOperator ternaryOperator,
			IUnifiedExpression secondExpression,
			IUnifiedExpression lastExpression)
		{
			return new UnifiedTernaryExpression {
				FirstExpression = firstExpression,
				Operator = ternaryOperator,
				SecondExpression = secondExpression,
				LastExpression = lastExpression,
			};
		}
	}
}