using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedModifier : UnifiedElement {
		public string Name { get; set; }

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public static UnifiedModifier Create(string name) {
			return new UnifiedModifier { Name = name };
		}
	}
}