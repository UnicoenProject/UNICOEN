namespace Ucpf.Core.Model {

	public class a {
		public void b() {
			var a = UnifiedBinaryOperatorType.Greater;
		}
	}

	public enum UnifiedBinaryOperatorType {
		// Arithmetic
		Add,
		Subtract,
		Multiply,
		Divide,
		Modulo,
		// Shift
		LeftArithmeticShift,	// nothing in Java
		RightArithmeticShift,	// >> in Java
		LeftLogicalRotate,		// << in Java
		RightLogicalRotate,		// >>> in Java
		// Comparison
		/// a > b
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