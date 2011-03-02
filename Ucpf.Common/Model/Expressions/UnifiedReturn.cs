using Ucpf.Common.Model.Visitors;

namespace Ucpf.Common.Model {
	public class UnifiedReturn : UnifiedExpression {
		public UnifiedExpression Value { get; set; }

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}