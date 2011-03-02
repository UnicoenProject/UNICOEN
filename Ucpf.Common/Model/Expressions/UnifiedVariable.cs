﻿using Ucpf.Common.Model.Visitors;

namespace Ucpf.Common.Model {
	public class UnifiedVariable : UnifiedExpression {
		public string Name { get; set; }

		public UnifiedVariable(string name) {
			Name = name;
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}