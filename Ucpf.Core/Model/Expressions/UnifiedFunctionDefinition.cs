using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model.Expressions {
	public class UnifiedFunctionDefinition : UnifiedExpression {
		public UnifiedModifierCollection Modifiers { get; set; }
		public UnifiedType Type { get; set; }
		public string Name { get; set; }
		public UnifiedParameterCollection Parameters { get; set; }
		public UnifiedBlock Block { get; set; }

		public UnifiedFunctionDefinition() {
			Modifiers = new UnifiedModifierCollection();
			Parameters = new UnifiedParameterCollection();
			Block = new UnifiedBlock();
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}