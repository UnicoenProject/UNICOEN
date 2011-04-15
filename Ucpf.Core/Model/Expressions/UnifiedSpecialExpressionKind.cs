namespace Ucpf.Core.Model {
	/// <summary>
	///   UnifiedSpecialExpressionの種類を表します。
	/// </summary>
	public enum UnifiedSpecialExpressionKind {
		Break,
		Continue,
		Goto,
		Return,
		YieldReturn,
		Throw,
		/// <summary>
		///   retry in Ruby
		/// </summary>
		Retry,
		/// <summary>
		///   redo in Ruby
		/// </summary>
		Redo,
		/// <summary>
		///   yield in Ruby
		/// </summary>
		Yield,
	}
}