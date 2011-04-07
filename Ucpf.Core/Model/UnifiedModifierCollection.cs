using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	/// <summary>
	/// 修飾子の集合を表します。
	/// </summary>
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

		public static UnifiedModifierCollection Create(params UnifiedModifier[] modifiers) {
			return new UnifiedModifierCollection(modifiers);
		}

		public static UnifiedModifierCollection Create(IEnumerable<UnifiedModifier> modifiers) {
			return new UnifiedModifierCollection(modifiers);
		}
	}
}