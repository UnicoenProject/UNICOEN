using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedModifier : UnifiedElement {
		public string Name { get; set; }

		public override TResult Accept<TData, TResult>(IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public static UnifiedModifier Create(string name) {
			return new UnifiedModifier { Name = name };
		}
	}
}