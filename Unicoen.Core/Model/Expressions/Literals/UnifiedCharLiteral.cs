using Unicoen.Core.Processor;

namespace Unicoen.Core.Model {
	/// <summary>
	///   •¶š—ñ‚Å‚ ‚éƒŠƒeƒ‰ƒ‹‚ğ•\‚µ‚Ü‚·B
	///   e.g. Java‚É‚¨‚¯‚é<c>char str = 'c'</c>‚Ì<c>'c'</c>‚Ì•”•ª
	/// </summary>
	public class UnifiedCharLiteral : UnifiedTypedLiteral<string> {
		private UnifiedCharLiteral() { }

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override void Accept<TData>(
				IUnifiedModelVisitor<TData> visitor,
				TData state) {
			visitor.Visit(this, state);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData state) {
			return visitor.Visit(this, state);
		}

		public static UnifiedCharLiteral Create(string value) {
			return new UnifiedCharLiteral {
					Value = value,
			};
		}
	}
}