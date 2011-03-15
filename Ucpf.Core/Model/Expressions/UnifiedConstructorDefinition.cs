using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedConstructorDefinition : UnifiedExpression {
		public UnifiedModifierCollection Modifiers { get; set; }
		public UnifiedParameterCollection Parameters { get; set; }
		public UnifiedBlock Block { get; set; }

		public UnifiedConstructorDefinition() {
			Modifiers = new UnifiedModifierCollection();
			Parameters = new UnifiedParameterCollection();
			Block = new UnifiedBlock();
		}

		public override TResult Accept<TData, TResult>(IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}
	}
}