using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	/// <summary>
	/// case式の集合を表します。
	/// </summary>
	public class UnifiedCaseCollection : UnifiedElementCollection<UnifiedCase> {
		public UnifiedCaseCollection() {}

		public UnifiedCaseCollection(IEnumerable<UnifiedCase> elements)
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