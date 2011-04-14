using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model
{
	/// <summary>
	///   二項演算子を表します。
	/// </summary>
	public class UnifiedBinaryOperator : UnifiedElement
	{
		public string Sign { get; private set; }

		public UnifiedBinaryOperatorKind Kind { get; private set; }

		private UnifiedBinaryOperator() {}

		public static UnifiedBinaryOperator Create(string sign,
		                                           UnifiedBinaryOperatorKind kind)
		{
			return new UnifiedBinaryOperator {
				Sign = sign,
				Kind = kind,
			};
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