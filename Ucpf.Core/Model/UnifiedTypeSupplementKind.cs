namespace Ucpf.Core.Model
{
	/// <summary>
	///   UnifiedTypeSupplementの種類を表します。
	/// </summary>
	public enum UnifiedTypeSupplementKind
	{
		/// <summary>
		///   C, C++, C#言語などにおけるポインタ（ex. "int *p;"）
		/// </summary>
		Pointer,
		/// <summary>
		///   C++言語などにおける参照（ex. "int &p = i;"）
		/// </summary>
		Reference,
		/// <summary>
		///   C#, Java言語などにおける配列（ex. "int[] a;"）
		///   C, C++言語などにおける配列（ex. "int[10] a;"）
		///   C#言語などにおける多次元配列（ex. "int[,] a2;"）
		/// </summary>
		Array,
	}
}