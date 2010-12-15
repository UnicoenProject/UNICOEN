namespace Ucpf.CodeModel {
	public enum BinaryOperatorType {
		// Arithmetic
		Addition,
		Subtraction,
		Multiplication,
		Division,
		Modulo,
		Assignment,
		// Shift
		LeftShift,		// <<< in Java
		RightShift,		// nothing in Java
		LeftRotate,		// << in Java
		RightRotate,	// >> in Java
		// Comparison
		Greater,
		GreaterEqual,
		Lesser,
		LesserEqual,
		Equal,
	}
}