using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model
{
	/// <summary>
	///   try節を表します。
	/// </summary>
	public class UnifiedTry : UnifiedExpressionWithBlock<UnifiedTry>
	{
		private UnifiedCatchCollection _catches;

		public UnifiedCatchCollection Catches
		{
			get { return _catches; }
			set { _catches = SetParentOfChild(value, _catches); }
		}

		private UnifiedBlock _finallyBody;

		public UnifiedBlock FinallyBody
		{
			get { return _finallyBody; }
			set { _finallyBody = SetParentOfChild(value, _finallyBody); }
		}

		private UnifiedTry()
		{
			Body = UnifiedBlock.Create();
			Catches = UnifiedCatchCollection.Create();
			FinallyBody = UnifiedBlock.Create();
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
			yield return Body;
			yield return Catches;
			yield return FinallyBody;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndSetters()
		{
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Body, v => Body = (UnifiedBlock)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Catches, v => Catches = (UnifiedCatchCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(FinallyBody, v => FinallyBody = (UnifiedBlock)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndDirectSetters()
		{
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Body, v => _body = (UnifiedBlock)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Catches, v => _catches = (UnifiedCatchCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(FinallyBody, v => _finallyBody = (UnifiedBlock)v);
		}

		public static UnifiedTry Create(UnifiedBlock body,
		                                UnifiedCatchCollection catches,
		                                UnifiedBlock finallyBody)
		{
			return new UnifiedTry {
				Body = body,
				Catches = catches,
				FinallyBody = finallyBody,
			};
		}
	}
}