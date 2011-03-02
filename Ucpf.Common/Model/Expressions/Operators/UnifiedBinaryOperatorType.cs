namespace Ucpf.Common.Model {
	public enum UnifiedBinaryOperatorType {
		// Arithmetic
		Addition,
		Subtraction,
		Multiplication,
		Division,
		Modulo,
		// Shift
		LeftShift,			// ex) logical << in Java
		RightShift,			// ex) logical >>> in Java
		LeftRotate,			// ex) arithmetic nothing
		RightRotate,		// ex) arithmetic >> in Java
		// Comparison
		Greater,
		GreaterEqual,
		Lesser,
		LesserEqual,
		Equal,
		NotEqual,
		// Logical
		LogicalAnd,			// &&
		LogicalOr,			// ||
		// Bit
		BitAnd,				// &
		BitOr,				// |
		BitXor,				// ^
		// Assignment
		Assignment,			// =
		AddAssignment,		// +=
		SubAssignment,		// -=
		MulAssignment,		// *=
		DivAssignment,		// /=
		ModAssignment,		// %=
	}
}