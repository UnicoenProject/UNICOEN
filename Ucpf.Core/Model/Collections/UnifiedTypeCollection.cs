using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model
{
	/// <summary>
	///   UnifiedTypeの集合を表します。
	/// </summary>
	public class UnifiedTypeCollection
		: UnifiedElementCollection<UnifiedType, UnifiedTypeCollection>
	{
		private UnifiedTypeCollection() {}

		private UnifiedTypeCollection(IEnumerable<UnifiedType> elements)
			: base(elements) {}

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

		public static UnifiedTypeCollection Create()
		{
			return new UnifiedTypeCollection();
		}

		public static UnifiedTypeCollection Create(params UnifiedType[] elements)
		{
			return new UnifiedTypeCollection(elements);
		}

		public static UnifiedTypeCollection Create(IEnumerable<UnifiedType> elements)
		{
			return new UnifiedTypeCollection(elements);
		}
	}
}