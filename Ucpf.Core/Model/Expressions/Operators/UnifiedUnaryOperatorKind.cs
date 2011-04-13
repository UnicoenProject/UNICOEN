namespace Ucpf.Core.Model
{
	/// <summary>
	///   単項演算子の種類を表します。
	///   http://msdn.microsoft.com/ja-jp/library/bb361179.aspx
	/// </summary>
	public enum UnifiedUnaryOperatorKind
	{
		/// <summary>
		///   種類が不明
		/// </summary>
		Unknown,
		/// <summary>
		///   e.g. ++a
		/// </summary>
		PreIncrementAssign,
		/// <summary>
		///   e.g. --a
		/// </summary>
		PreDecrementAssign,
		/// <summary>
		///   e.g. a++
		/// </summary>
		PostIncrementAssign,
		/// <summary>
		///   e.g. a--
		/// </summary>
		PostDecrementAssign,
		/// <summary>
		///   e.g. +a
		/// </summary>
		UnaryPlus,
		/// <summary>
		///   e.g. -a
		/// </summary>
		Negate,
		/// <summary>
		///   e.g. !a
		/// </summary>
		Not,
		/// <summary>
		///   e.g. ~a
		/// </summary>
		OnesComplement,
		/// <summary>
		///   e.g. &a
		/// </summary>
		Address,
		/// <summary>
		///   e.g. *a
		/// </summary>
		Indirect,
		/// <summary>
		///   e.g. sizeof(a)
		/// </summary>
		Sizeof,
	}
}