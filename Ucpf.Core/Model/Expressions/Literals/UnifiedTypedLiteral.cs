using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public abstract class UnifiedTypedLiteral<T> : UnifiedLiteral {
		public T Value { get; set; }

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(
			IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}
	}
}