namespace Ucpf.Core.Model
{
	/// <summary>
	///   UnifiedTypeSupplementの種類を表します。
	/// </summary>
	public enum UnifiedTypeSupplementKind
	{
		/// <summary>
		///   e.g. C, C++, C#におけるポインタ(<c>int *p;</c>)
		/// </summary>
		Pointer,
		/// <summary>
		///   e.g. C++における参照(<c>int &p = i;</c>)
		/// </summary>
		Reference,
		/// <summary>
		///   e.g. C#, Javaにおける配列(<c>int[] a;</c>)
		///   e.g. C, C++における配列(<c>int[10] a;</c>)
		/// </summary>
		Array,
		/// <summary>
		///   e.g. C#における多次元配列(<c>int[,] a2;</c>)
		/// </summary>
		MultidimensionArray,
	}
}