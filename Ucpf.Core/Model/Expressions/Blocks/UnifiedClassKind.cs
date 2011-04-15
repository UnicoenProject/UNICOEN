namespace Ucpf.Core.Model {
	/// <summary>
	///   UnifiedClassDefinitionの種類を表します。
	/// </summary>
	public enum UnifiedClassKind {
		Class,
		/// <summary>
		///   interface in Java, C#
		///   trait? in Scala
		/// </summary>
		Interface,
		/// <summary>
		///   namespace in C#, C++
		///   package in Java
		/// </summary>
		Namespace,
		/// <summary>
		///   enum in Java, C#, C++
		/// </summary>
		Enum,
		/// <summary>
		///   module in Ruby
		/// </summary>
		Module,
	}
}