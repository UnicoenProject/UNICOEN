using Ucpf.Common.Model.Visitors;

namespace Ucpf.Common.Model {
	public class UnifiedArgument : UnifiedElement {
		public UnifiedExpression Value { get; set; }

		public static explicit operator UnifiedArgument(UnifiedExpression expr) {
			return new UnifiedArgument { Value = expr };
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}