using System.Collections.Generic;
using System.Linq;
using Ucpf.Core.Model.Extensions;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model
{
	/// <summary>
	///   UnifiedTypeSupplement（配列型やポインタ型などを表すために型に付加される修飾子）の集合を表します。
	///   例えば、"int** p;"の"**"部分が該当します。
	/// </summary>
	public class UnifiedTypeSupplementCollection
		: UnifiedElementCollection
		  	<UnifiedTypeSupplement, UnifiedTypeSupplementCollection>
	{
		private UnifiedTypeSupplementCollection() {}

		private UnifiedTypeSupplementCollection(
			IEnumerable<UnifiedTypeSupplement> elements)
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

		public static UnifiedTypeSupplementCollection Create()
		{
			return new UnifiedTypeSupplementCollection();
		}

		public static UnifiedTypeSupplementCollection Create(
			params UnifiedTypeSupplement[] elements)
		{
			return new UnifiedTypeSupplementCollection(elements);
		}

		public static UnifiedTypeSupplementCollection Create(
			IEnumerable<UnifiedTypeSupplement> elements)
		{
			return new UnifiedTypeSupplementCollection(elements);
		}

		public static UnifiedTypeSupplementCollection CreateArray()
		{
			return CreateArray(1);
		}

		public static UnifiedTypeSupplementCollection CreateArray(int dimension)
		{
			return CreateArray(Enumerable.Repeat<IUnifiedExpression>(null, dimension));
		}

		public static UnifiedTypeSupplementCollection CreateArray(
			IEnumerable<IUnifiedExpression> values)
		{
			return UnifiedTypeSupplement.Create(
				values.ToCollection(), UnifiedTypeSupplementKind.Array)
				.ToCollection();
		}
	}
}