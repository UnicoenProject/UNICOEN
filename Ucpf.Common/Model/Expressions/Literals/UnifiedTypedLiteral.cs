using System;
using Ucpf.Common.Model.Visitors;

namespace Ucpf.Common.Model {
	public abstract class UnifiedTypedLiteral<T> : UnifiedLiteral {
		public T Value { get; set; }

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}