using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedTypeParameterCollection : UnifiedElementCollection<UnifiedTypeParameter> {
		public UnifiedTypeParameterCollection() {}

		public UnifiedTypeParameterCollection(IEnumerable<UnifiedTypeParameter> elements)
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
