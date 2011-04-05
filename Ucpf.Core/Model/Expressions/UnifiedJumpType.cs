namespace Ucpf.Core.Model {
	public enum UnifiedJumpType {
		Break,
		Continue,
		Goto,
		Return,
		YieldReturn,
		Throw,
		/// <summary>
		/// retry in Ruby
		/// </summary>
		Retry,
		/// <summary>
		/// redo in Ruby
		/// </summary>
		Redo,
		/// <summary>
		/// yield in Ruby
		/// </summary>
		Yield,
	}
}