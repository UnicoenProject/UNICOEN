namespace Ucpf.Common.Model {
	public enum UnifiedUnaryOperatorType {
		PrefixIncrement,
		PrefixDecrement,
		PostfixIncrement,
		PostfixDecrement,
		Plus,
		Minus,
		Not, // !
		BitReverse, // ~
		Address, // & in C
		Indirect, // * in C
		Sizeof,
	}
}