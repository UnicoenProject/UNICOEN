namespace Ucpf.Common.Model {
	public enum UnifiedBinaryOperatorType {
		// Arithmetic
		Addition,
		Subtraction,
		Multiplication,
		Division,
		Modulo,
		// Shift
		LeftShift, // <<< in Java
		RightShift, // nothing in Java
		LeftRotate, // << in Java
		RightRotate, // >> in Java
		// Comparison
		Greater,
		GreaterEqual,
		Lesser,
		LesserEqual,
		Equal,
		NotEqual,
		// Logical
		LogicalAnd,
		LogicalOr,
		// Bit
		BitAnd, // &
		BitOr, // |
		BitXor, // ^
		// Assignment
		Assignment, // =
		AddAssignment, // +=
		SubAssignment, // -=
		MulAssignment, // *=
		DivAssignment, // /=
		ModAssignment, // %=
	}
}