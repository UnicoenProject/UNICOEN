using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model
{
	/// <summary>
	/// </summary>
	/// <typeparam name = "T"></typeparam>
	public abstract class UnifiedTypedLiteral<T> : UnifiedLiteral
	{
		public T Value { get; set; }
	}
}