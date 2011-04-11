using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model
{
	/// <summary>
	///   ジェネリックタイプにおける仮引数の集合を表します。
	/// </summary>
	public class UnifiedTypeArgumentCollection
		: UnifiedElementCollection
		  	<UnifiedTypeArgument, UnifiedTypeArgumentCollection>
	{
		private UnifiedTypeArgumentCollection() {}

		private UnifiedTypeArgumentCollection(
			IEnumerable<UnifiedTypeArgument> elements)
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

		public static UnifiedTypeArgumentCollection Create()
		{
			return new UnifiedTypeArgumentCollection();
		}

		public static UnifiedTypeArgumentCollection Create(
			params UnifiedTypeArgument[] elements)
		{
			return new UnifiedTypeArgumentCollection(elements);
		}

		public static UnifiedTypeArgumentCollection Create(
			IEnumerable<UnifiedTypeArgument> elements)
		{
			return new UnifiedTypeArgumentCollection(elements);
		}
	}
}