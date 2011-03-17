namespace Ucpf.Core.Model {
	/// <summary>
	/// 単項演算子の種類を表します。
	/// http://msdn.microsoft.com/ja-jp/library/bb361179.aspx
	/// </summary>
	public enum UnifiedUnaryOperatorType {
		/// <summary>++a</summary>
		PreIncrementAssign,
		/// <summary>--a</summary>
		PreDecrementAssign,
		/// <summary>a++</summary>
		PostIncrementAssign,
		/// <summary>a--</summary>
		PostDecrementAssign,
		/// <summary>+a</summary>
		UnaryPlus,
		/// <summary>-a</summary>
		Negate,
		/// <summary>!a</summary>
		Not,
		/// <summary>!a</summary>
		OnesComplement,
		/// <summary>&a</summary>
		Address,
		/// <summary>*a</summary>
		Indirect,
		/// <summary>sizeof(a)</summary>
		Sizeof,
	}
}