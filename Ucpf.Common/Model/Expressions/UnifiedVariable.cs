using Ucpf.Common.Model.Visitors;

namespace Ucpf.Common.Model {
	public class UnifiedVariable : UnifiedExpression {
		public static UnifiedVariable Create(string name) {
			return new UnifiedVariable { Name = name };
		}

		public string Name { get; set; }

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}