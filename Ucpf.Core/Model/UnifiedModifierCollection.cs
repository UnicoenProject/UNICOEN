using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedModifierCollection
			: UnifiedElementCollection<UnifiedModifier, UnifiedModifierCollection> {
		private UnifiedModifierCollection() {}

		private UnifiedModifierCollection(IEnumerable<UnifiedModifier> elements)
				: base(elements) {}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public static UnifiedModifierCollection Create() {
			return new UnifiedModifierCollection();
		}

		public static UnifiedModifierCollection Create(UnifiedModifier modifier) {
			return new UnifiedModifierCollection(new[] { modifier });
		}

		public static UnifiedModifierCollection Create(IEnumerable<UnifiedModifier> modifiers) {
			return new UnifiedModifierCollection(modifiers);
		}
	}
}