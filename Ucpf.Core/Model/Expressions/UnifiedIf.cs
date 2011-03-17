using System.Collections.Generic;
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

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(
			IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override IEnumerable<UnifiedElement> GetElements() {
			yield return Condition;
			yield return TrueBlock;
			yield return FalseBlock;
		}
	}
}