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

		/// <summary>
		/// 実引数を持たない一次元配列の修飾子を作成します。
		/// e.g. Javaにおける<c>int[]</c>
		/// </summary>
		/// <returns></returns>
		public static UnifiedTypeSupplementCollection CreateArray()
		{
			return CreateArray(1);
		}

		/// <summary>
		/// 実引数を持たない多次元配列(ジャグ配列)の修飾子を作成します。
		/// e.g. Javaにおける<c>int[][]</c>
		/// </summary>
		/// <returns></returns>
		public static UnifiedTypeSupplementCollection CreateArray(int dimension)
		{
			return CreateArray(Enumerable.Repeat(UnifiedArgument.Create(null), dimension));
		}

		/// <summary>
		/// 実引数を指定して配列(ジャグ配列)の修飾子を作成します。次元数は実引数の数になります。
		/// e.g. Javaにおける<c>int[1][2]</c>
		/// </summary>
		/// <returns></returns>
		public static UnifiedTypeSupplementCollection CreateArray(
			IEnumerable<UnifiedArgument> values)
		{
			return values.Select(UnifiedTypeSupplement.CreateArray)
				.ToCollection();
		}
	}
}