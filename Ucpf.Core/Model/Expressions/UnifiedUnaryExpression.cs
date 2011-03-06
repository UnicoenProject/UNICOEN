using Ucpf.Core.Model.Expressions.Operators;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model.Expressions {
	public class UnifiedUnaryExpression : UnifiedExpression {
		public UnifiedUnaryOperator Operator { get; set; }
		public UnifiedExpression Operand { get; set; }

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}
