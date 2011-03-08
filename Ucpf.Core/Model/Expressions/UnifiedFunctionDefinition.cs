using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedFunctionDefinition : UnifiedExpression {
		public UnifiedModifierCollection Modifiers { get; set; }
		public UnifiedType Type { get; set; }
		public string Name { get; set; }
		public UnifiedParameterCollection Parameters { get; set; }
		public UnifiedBlock Body { get; set; }

		public UnifiedFunctionDefinition() {
			Modifiers = new UnifiedModifierCollection();
			Parameters = new UnifiedParameterCollection();
			Body = new UnifiedBlock();
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}