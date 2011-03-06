using Ucpf.Core.Model.Expressions.Operators;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model.Expressions {
	public class UnifiedBinaryExpression : UnifiedExpression {
		public UnifiedBinaryOperator Operator { get; set; }
		public UnifiedExpression LeftHandSide { get; set; }
		public UnifiedExpression RightHandSide { get; set; }

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}