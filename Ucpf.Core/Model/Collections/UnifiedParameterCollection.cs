using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model
{
	/// <summary>
	///   仮引数の集合を表します。
	/// </summary>
	public class UnifiedParameterCollection
		: UnifiedElementCollection<UnifiedParameter, UnifiedParameterCollection>
	{
		private UnifiedParameterCollection() {}

		private UnifiedParameterCollection(IEnumerable<UnifiedParameter> elements)
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

		public static UnifiedParameterCollection Create()
		{
			return new UnifiedParameterCollection();
		}

		public static UnifiedParameterCollection Create(
			params UnifiedParameter[] elements)
		{
			return new UnifiedParameterCollection(elements);
		}

		public static UnifiedParameterCollection Create(
			IEnumerable<UnifiedParameter> elements)
		{
			return new UnifiedParameterCollection(elements);
		}
	}
}