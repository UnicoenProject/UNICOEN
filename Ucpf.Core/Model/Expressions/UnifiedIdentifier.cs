using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model
{
	/// <summary>
	///   変数を表します。
	/// </summary>
	public class UnifiedIdentifier : UnifiedElement, IUnifiedExpression
	{
		private UnifiedIdentifier() {}

		public string Value { get; set; }

		public UnifiedIdentifierKind Kind { get; set; }

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

		public static UnifiedIdentifier Create(string name, UnifiedIdentifierKind kind)
		{
			return new UnifiedIdentifier {
				Value = name,
				Kind = kind
			};
		}

		public static UnifiedIdentifier CreateUnknown(string name)
		{
			return Create(name, UnifiedIdentifierKind.Unknown);
		}

		public static UnifiedIdentifier CreateVariable(string name)
		{
			return Create(name, UnifiedIdentifierKind.Variable);
		}
	}
}