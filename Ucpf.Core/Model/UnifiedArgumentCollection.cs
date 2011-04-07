using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedArgumentCollection
			: UnifiedElementCollection<UnifiedArgument, UnifiedArgumentCollection> {
		private UnifiedArgumentCollection() { }

		private UnifiedArgumentCollection(IEnumerable<UnifiedArgument> elements)
				: base(elements) {}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public static UnifiedArgumentCollection Create() {
			return new UnifiedArgumentCollection();
		}

		public static UnifiedArgumentCollection Create(params UnifiedArgument[] elements) {
			return new UnifiedArgumentCollection(elements);
		}

		public static UnifiedArgumentCollection Create(IEnumerable<UnifiedArgument> elements) {
			return new UnifiedArgumentCollection(elements);
		}
	}
}