using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model.Expressions {
	public class UnifiedVariableDefinition : UnifiedExpression {
		public UnifiedModifierCollection Modifiers { get; set; }
		public UnifiedType Type { get; set; }
		public string Name { get; set; }
		public UnifiedExpression InitialValue { get; set; }

		public UnifiedVariableDefinition() {
			Modifiers = new UnifiedModifierCollection();
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}
