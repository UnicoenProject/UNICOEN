using Ucpf.Common.Model.Visitors;

namespace Ucpf.Common.Model {
	public class UnifiedArgument : UnifiedElement {
		public UnifiedExpression Value { get; set; }

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public static UnifiedArgument Create(UnifiedExpression exprssion) {
			return new UnifiedArgument { Value = exprssion };
		}
	}
}