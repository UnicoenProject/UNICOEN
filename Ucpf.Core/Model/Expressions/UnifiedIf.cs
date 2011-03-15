using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedIf : UnifiedExpression {
		public UnifiedExpression Condition { get; set; }
		public UnifiedBlock TrueBlock { get; set; }
		public UnifiedBlock FalseBlock { get; set; }

		public UnifiedIf() {
			TrueBlock = new UnifiedBlock();
			FalseBlock = new UnifiedBlock();
		}

		public UnifiedIf AddToTrueBody(UnifiedExpression expression) {
			TrueBlock.Add(expression);
			return this;
		}

		public UnifiedIf AddToFalseBody(UnifiedExpression expression) {
			FalseBlock.Add(expression);
			return this;
		}

		public override TResult Accept<TData, TResult>(IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}
	}
}