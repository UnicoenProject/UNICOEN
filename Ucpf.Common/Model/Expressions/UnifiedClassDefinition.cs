using System;
using Ucpf.Common.Model.Visitors;

namespace Ucpf.Common.Model {
	public class UnifiedClassDefinition : UnifiedExpression {
		public string Name { get; set; }
		public UnifiedBlock Body { get; set; }

		public UnifiedClassDefinition() {
			Body = new UnifiedBlock();
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}