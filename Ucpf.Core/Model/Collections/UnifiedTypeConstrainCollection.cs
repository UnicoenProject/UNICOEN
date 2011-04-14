using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model
{
	/// <summary>
	///   型が持つ性質の集合を表します。
	/// </summary>
	public class UnifiedTypeConstrainCollection
		: UnifiedElementCollection
		  	<UnifiedTypeConstrain, UnifiedTypeConstrainCollection>
	{
		private UnifiedTypeConstrainCollection() {}

		private UnifiedTypeConstrainCollection(
			IEnumerable<UnifiedTypeConstrain> elements)
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

		public static UnifiedTypeConstrainCollection Create()
		{
			return new UnifiedTypeConstrainCollection();
		}

		public static UnifiedTypeConstrainCollection Create(
			params UnifiedTypeConstrain[] elements)
		{
			return new UnifiedTypeConstrainCollection(elements);
		}

		public static UnifiedTypeConstrainCollection Create(
			IEnumerable<UnifiedTypeConstrain> elements)
		{
			return new UnifiedTypeConstrainCollection(elements);
		}
	}
}