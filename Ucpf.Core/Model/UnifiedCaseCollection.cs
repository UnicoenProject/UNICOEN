using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedCaseCollection : UnifiedElementCollection<UnifiedCase, UnifiedCaseCollection> {
		private UnifiedCaseCollection() {}

		private UnifiedCaseCollection(IEnumerable<UnifiedCase> elements)
				: base(elements) {}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public static UnifiedCaseCollection Create() {
			return new UnifiedCaseCollection();
		}

		public static UnifiedCaseCollection Create(params UnifiedCase[] elements) {
			return new UnifiedCaseCollection(elements);
		}

		public static UnifiedCaseCollection Create(IEnumerable<UnifiedCase> elements) {
			return new UnifiedCaseCollection(elements);
		}
	}
}