namespace Ucpf.Core.Model.Expressions.Operators {
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