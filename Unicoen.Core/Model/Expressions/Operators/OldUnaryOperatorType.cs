namespace Unicoen.Common.OldModel.Operators {
	public enum OldUnaryOperatorType {
		PrefixIncrement,
		PrefixDecrement,
		PostfixIncrement,
		PostfixDecrement,
		Plus,
		Minus,
		Not, // LogicalReverse??
		BitReverse, // "~"

		// used especially in C
		Address, // &
		Indirect, // *
		Sizeof,
	}
}