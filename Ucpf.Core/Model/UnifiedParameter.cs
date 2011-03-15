﻿using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedParameter : UnifiedElement {
		public UnifiedModifierCollection Modifiers { get; set; }
		public string Name { get; set; }
		public UnifiedType Type { get; set; }

		public UnifiedParameter() {
			Modifiers = new UnifiedModifierCollection();
		}

		public override TResult Accept<TData, TResult>(IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}
	}
}