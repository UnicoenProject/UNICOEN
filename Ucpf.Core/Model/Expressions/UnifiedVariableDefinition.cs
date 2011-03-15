﻿using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedVariableDefinition : UnifiedExpression {
		public UnifiedModifierCollection Modifiers { get; set; }
		public UnifiedType Type { get; set; }
		public string Name { get; set; }
		public UnifiedExpression InitialValue { get; set; }

		public UnifiedVariableDefinition() {
			Modifiers = new UnifiedModifierCollection();
		}

		public override TResult Accept<TData, TResult>(IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}
	}
}
