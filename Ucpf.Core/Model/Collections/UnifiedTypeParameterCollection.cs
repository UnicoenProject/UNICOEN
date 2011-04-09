using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model
{
	/// <summary>
	///   ジェネリックタイプにおける仮引数の集合を表します。
	/// </summary>
	public class UnifiedTypeParameterCollection
		: UnifiedElementCollection
		  	<UnifiedTypeParameter, UnifiedTypeParameterCollection>
	{
		private UnifiedTypeParameterCollection() {}

		private UnifiedTypeParameterCollection(
			IEnumerable<UnifiedTypeParameter> elements)
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

		public static UnifiedTypeParameterCollection Create()
		{
			return new UnifiedTypeParameterCollection();
		}

		public static UnifiedTypeParameterCollection Create(
			params UnifiedTypeParameter[] elements)
		{
			return new UnifiedTypeParameterCollection(elements);
		}

		public static UnifiedTypeParameterCollection Create(
			IEnumerable<UnifiedTypeParameter> elements)
		{
			return new UnifiedTypeParameterCollection(elements);
		}
	}
}