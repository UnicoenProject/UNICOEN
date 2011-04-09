using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model
{
	/// <summary>
	///   単項演算子を表します。
	/// </summary>
	public class UnifiedUnaryOperator : UnifiedElement
	{
		public string Sign { get; private set; }
		public UnifiedUnaryOperatorType Type { get; private set; }

		private UnifiedUnaryOperator() {}

		public static UnifiedUnaryOperator Create(string sign,
		                                          UnifiedUnaryOperatorType type)
		{
			return new UnifiedUnaryOperator {
				Sign = sign,
				Type = type,
			};
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
			yield break;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndSetters()
		{
			yield break;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndDirectSetters()
		{
			yield break;
		}
	}
}