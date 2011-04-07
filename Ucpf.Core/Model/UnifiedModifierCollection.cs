using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	/// <summary>
	/// 修飾子の集合を表します。
	/// </summary>
	public class UnifiedModifierCollection
			: UnifiedElementCollection<UnifiedModifier> {
		public UnifiedModifierCollection() {}

		public UnifiedModifierCollection(IEnumerable<UnifiedModifier> elements)
				: base(elements) {}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}
			}
}