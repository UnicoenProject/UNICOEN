using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
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