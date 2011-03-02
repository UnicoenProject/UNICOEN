using Ucpf.Common.Model.Visitors;

namespace Ucpf.Common.Model {
	public class UnifiedParameter : UnifiedElement {
		public UnifiedModifier Modifier { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}