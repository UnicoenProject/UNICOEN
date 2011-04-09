namespace Ucpf.Core.Model
{
	/// <summary>
	///   二項演算子の種類を表します。
	///   http://msdn.microsoft.com/ja-jp/library/bb361179.aspx
	/// </summary>
	public enum UnifiedBinaryOperatorType
	{
		/// <summary>
		///   a + b
		/// </summary>
		Add,
		/// <summary>
		///   a - b
		/// </summary>
		Subtract,
		/// <summary>
		///   a * b
		/// </summary>
		Multiply,
		/// <summary>
		///   a / b
		/// </summary>
		Divide,
		/// <summary>
		///   a % b
		/// </summary>
		Modulo,
		/// <summary>
		///   a ^ b in VB
		/// </summary>
		Power,
		/// <summary>
		///   nothing in Java
		/// </summary>
		ArithmeticLeftShift,
		/// <summary>
		///   a >> b
		/// </summary>
		ArithmeticRightShift,
		/// <summary>
		///   a &lt;&lt; b
		/// </summary>
		LogicalLeftShift,
		/// <summary>
		///   a >>> b
		/// </summary>
		LogicalRightShift,
		/// <summary>
		///   a > b
		/// </summary>
		GreaterThan,
		/// <summary>
		///   a >= b
		/// </summary>
		GreaterThanOrEqual,
		/// <summary>
		///   a ?? b
		/// </summary>
		Coalesce,
		/// <summary>
		///   a &lt; b
		/// </summary>
		LessThan,
		/// <summary>
		///   a &lt;= b
		/// </summary>
		LessThanOrEqual,
		/// <summary>
		///   a == b
		/// </summary>
		Equal,
		/// <summary>
		///   a == b
		/// </summary>
		NotEqual,
		/// <summary>
		///   a && b
		/// </summary>
		AndAlso,
		/// <summary>
		///   a || b
		/// </summary>
		OrElse,
		/// <summary>
		///   a & b
		/// </summary>
		And,
		/// <summary>
		///   a | b
		/// </summary>
		Or,
		/// <summary>
		///   a ^ b
		/// </summary>
		ExclusiveOr,

		/// <summary>
		///   a = b
		/// </summary>
		Assign,
		/// <summary>
		///   a += b
		/// </summary>
		AddAssign,
		/// <summary>
		///   a -= b
		/// </summary>
		SubtractAssign,
		/// <summary>
		///   a *= b
		/// </summary>
		MultiplyAssign,
		/// <summary>
		///   a /= b
		/// </summary>
		DivideAssign,
		/// <summary>
		///   a %= b
		/// </summary>
		ModuloAssign,
		/// <summary>
		///   a ^= b in VB
		/// </summary>
		PowerAssign,
		/// <summary>
		///   nothing in Java
		/// </summary>
		ArithmeticLeftShiftAssign,
		/// <summary>
		///   a &lt;&lt;= b
		/// </summary>
		LogicalLeftShiftAssign,
		/// <summary>
		///   a >>= b
		/// </summary>
		ArithmeticRightShiftAssign,
		/// <summary>
		///   a >>>= b
		/// </summary>
		LogicalRightShiftAssign,
		/// <summary>
		///   a &= b
		/// </summary>
		AndAssign,
		/// <summary>
		///   a |= b
		/// </summary>
		OrAssign,
		/// <summary>
		///   a ^= b
		/// </summary>
		ExclusiveOrAssign,
	}
}