using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model
{
	/// <summary>
	///   for文を表します。
	/// </summary>
	public class UnifiedFor : UnifiedExpressionWithBlock<UnifiedFor>
	{
		private IUnifiedExpression _initializer;

		public IUnifiedExpression Initializer
		{
			get { return _initializer; }
			set { _initializer = SetParentOfChild(value, _initializer); }
		}

		private IUnifiedExpression _condition;

		public IUnifiedExpression Condition
		{
			get { return _condition; }
			set { _condition = SetParentOfChild(value, _condition); }
		}

		private IUnifiedExpression _step;

		public IUnifiedExpression Step
		{
			get { return _step; }
			set { _step = SetParentOfChild(value, _step); }
		}

		private UnifiedFor() {}

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
			yield return Initializer;
			yield return Condition;
			yield return Step;
			yield return Body;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndSetters()
		{
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Initializer, v => Initializer = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Condition, v => Condition = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Step, v => Step = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Body, v => Body = (UnifiedBlock)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndDirectSetters()
		{
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_initializer, v => _initializer = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_condition, v => _condition = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_step, v => _step = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_body, v => _body = (UnifiedBlock)v);
		}

		public static UnifiedFor Create(IUnifiedExpression initializer,
		                                IUnifiedExpression condition,
		                                IUnifiedExpression step,
		                                UnifiedBlock body)
		{
			return new UnifiedFor {
				Initializer = initializer,
				Condition = condition,
				Step = step,
				Body = body,
			};
		}
	}
}