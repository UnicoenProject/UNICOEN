using System;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedNamespace : UnifiedElement {
		public string Name { get; set; }
		public UnifiedBlock Body { get; set; }

		public override TResult Accept<TData, TResult>(IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			throw new NotImplementedException();
		}
	}
}