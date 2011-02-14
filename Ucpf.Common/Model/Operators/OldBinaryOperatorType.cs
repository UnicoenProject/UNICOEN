namespace Ucpf.Common.OldModel.Operators {
	public enum OldBinaryOperatorType {
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
		Assignment,
		// TODO :: add other 'compound' assignment operator (e.g. +=
	}
}