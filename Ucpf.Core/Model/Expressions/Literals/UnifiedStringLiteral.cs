using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedStringLiteral : UnifiedTypedLiteral<string> {
		public override TResult Accept<TData, TResult>(IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override IEnumerable<UnifiedElement> GetElements() {
			yield break;
		}

		public static UnifiedStringLiteral Create(string value) {
			return new UnifiedStringLiteral {
				Value = value,
			};
		}
	}
}