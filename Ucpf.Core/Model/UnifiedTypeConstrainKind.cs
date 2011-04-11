namespace Ucpf.Core.Model
{
	/// <summary>
	///   型が持つ制約の種類を表します。
	/// </summary>
	public enum UnifiedTypeConstrainKind
	{
		/// <summary>
		///   継承を表します。
		///   e.g. Javeにおける継承(<c>class Child extends Parent</c>)
		/// </summary>
		Extends,
		/// <summary>
		///   実装を表します。
		///   e.g. Javeにおける実装(<c>class Child implements Interface</c>)
		/// </summary>
		Implements,
		/// <summary>
		///   継承もしくは実装を表します。
		///   e.g. C#における継承(<c>class Child : Parent, Interface</c>)
		/// </summary>
		ExtendsOrImplements,
		/// <summary>
		///   デフォルトコンストラクタの存在を表します。
		///   e.g. C#におけるnew()(<c>where T : new()</c>)
		/// </summary>
		DefaultConstructor,
		/// <summary>
		///   参照型を表します。
		///   e.g. C#におけるclass(<c>where T : class</c>)
		/// </summary>
		ReferenceType,
		/// <summary>
		///   値型を表します。
		///   e.g. C#におけるstruct(<c>where T : struct</c>)
		/// </summary>
		ValueType,
	}
}