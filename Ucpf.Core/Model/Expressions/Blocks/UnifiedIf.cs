using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model
{
	/// <summary>
	///   if文を表します。
	/// </summary>
	public class UnifiedIf : UnifiedExpressionWithBlock<UnifiedIf>
	{
		private IUnifiedExpression _condition;

		public IUnifiedExpression Condition
		{
			get { return _condition; }
			set { _condition = SetParentOfChild(value, _condition); }
		}

		private UnifiedBlock _falseBody;

		public UnifiedBlock FalseBody
		{
			get { return _falseBody; }
			set { _falseBody = SetParentOfChild(value, _falseBody); }
		}

		private UnifiedIf()
		{
			Body = UnifiedBlock.Create();
			FalseBody = UnifiedBlock.Create();
		}

		public UnifiedIf AddToFalseBody(IUnifiedExpression expression)
		{
			FalseBody.Add(expression);
			return this;
		}

		public UnifiedIf RemoveFalseBody()
		{
			FalseBody = null;
			return this;
		}

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
			// TODO: Fix to proper order
			yield return Condition;
			yield return FalseBody;
			yield return Body;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndSetters()
		{
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Condition, v => Condition = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(FalseBody, v => FalseBody = (UnifiedBlock)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Body, v => Body = (UnifiedBlock)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndDirectSetters()
		{
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_condition, v => _condition = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_falseBody, v => _falseBody = (UnifiedBlock)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_body, v => _body = (UnifiedBlock)v);
		}

		public static UnifiedIf Create(UnifiedBlock body)
		{
			return new UnifiedIf {
				Body = body,
			};
		}

		public static UnifiedIf Create(UnifiedBlock body, IUnifiedExpression condition)
		{
			return new UnifiedIf {
				Body = body,
				Condition = condition,
			};
		}

		public static UnifiedIf Create(IUnifiedExpression condition)
		{
			return new UnifiedIf {
				Condition = condition,
			};
		}

		public static UnifiedIf Create(IUnifiedExpression condition, UnifiedBlock body,
		                               UnifiedBlock falseBody)
		{
			return new UnifiedIf {
				Body = body,
				Condition = condition,
				FalseBody = falseBody,
			};
		}
	}
}