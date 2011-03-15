using System;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedType : UnifiedElement {
		public string Name { get; set; }

		public static UnifiedType Create(string name) {
			return new UnifiedType {
				Name = name,
			};
		}

		public override TResult Accept<TData, TResult>(IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}
	}
}
