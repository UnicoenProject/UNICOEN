using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model.Expressions.Literals {
	public class UnifiedStringLiteral : UnifiedTypedLiteral<string> {
		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public static UnifiedStringLiteral Create(string value) {
			return new UnifiedStringLiteral {
				Value = value,
			};
		}
	}
}