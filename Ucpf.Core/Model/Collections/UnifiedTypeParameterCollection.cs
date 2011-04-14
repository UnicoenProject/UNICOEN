using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model
{
	/// <summary>
	///   ジェネリックタイプにおける仮引数の集合を表します。
	///   クラスやメソッドを宣言する際に型パラメータを宣言するために利用します。
	///   e.g. Javaにおける<c>class A&lt;T1, T2&gt; {  }</c>
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