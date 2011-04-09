namespace Ucpf.Core.Model
{
	/// <summary>
	///   処理を移動させる式の種類を表します。
	/// </summary>
	public enum UnifiedJumpType
	{
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