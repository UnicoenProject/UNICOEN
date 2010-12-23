namespace Ucpf.CodeModel {
	public enum UnaryOperatorType
	{
		PrefixIncrement,
		PrefixDecrement,
		PostfixIncrement,
		PostfixDecrement,
		Plus,
		Minus,
		Not,				// LogicalReverse??
		BitReverse,			// "~"

		// used especially in C
		Address,			// &
		Indirect,			// *
		Sizeof,
	}
}