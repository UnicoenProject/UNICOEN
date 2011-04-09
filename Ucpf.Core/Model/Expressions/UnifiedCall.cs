using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model
{
	/// <summary>
	///   関数呼び出しを表します。
	/// </summary>
	public class UnifiedCall : UnifiedElement, IUnifiedExpression
	{
		private IUnifiedExpression _function;

		public IUnifiedExpression Function
		{
			get { return _function; }
			set { _function = SetParentOfChild(value, _function); }
		}

		private UnifiedArgumentCollection _arguments;

		public UnifiedArgumentCollection Arguments
		{
			get { return _arguments; }
			set { _arguments = SetParentOfChild(value, _arguments); }
		}

		private UnifiedCall()
		{
			Arguments = UnifiedArgumentCollection.Create();
		}

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
			yield return Function;
			yield return Arguments;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndSetters()
		{
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Function, v => Function = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Arguments, v => Arguments = (UnifiedArgumentCollection)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndDirectSetters()
		{
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_function, v => _function = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_arguments, v => _arguments = (UnifiedArgumentCollection)v);
		}

		public static UnifiedCall Create(IUnifiedExpression target,
		                                 UnifiedArgumentCollection args)
		{
			return new UnifiedCall {
				Function = target,
				Arguments = args,
			};
		}
	}
}