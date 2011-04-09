using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model
{
	/// <summary>
	///   UnifiedCatchの集合を表します。
	/// </summary>
	public class UnifiedCatchCollection
		: UnifiedElementCollection<UnifiedCatch, UnifiedCatchCollection>
	{
		private UnifiedCatchCollection() {}

		private UnifiedCatchCollection(IEnumerable<UnifiedCatch> elements)
			: base(elements) {}

		public override void Accept(IUnifiedModelVisitor visitor)
		{
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(
			IUnifiedModelVisitor<TData, TResult> visitor, TData data)
		{
			return visitor.Visit(this, data);
		}

		public static UnifiedCatchCollection Create()
		{
			return new UnifiedCatchCollection();
		}

		public static UnifiedCatchCollection Create(params UnifiedCatch[] elements)
		{
			return new UnifiedCatchCollection(elements);
		}

		public static UnifiedCatchCollection Create(IEnumerable<UnifiedCatch> elements)
		{
			return new UnifiedCatchCollection(elements);
		}
	}
}