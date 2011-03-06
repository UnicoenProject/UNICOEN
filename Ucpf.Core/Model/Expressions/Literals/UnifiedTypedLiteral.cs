using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model.Expressions.Literals {
	public abstract class UnifiedTypedLiteral<T> : UnifiedLiteral {
		public T Value { get; set; }

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}