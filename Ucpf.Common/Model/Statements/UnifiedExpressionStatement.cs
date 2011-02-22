using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ucpf.Common.Model.Visitors;

namespace Ucpf.Common.Model {
	public sealed class UnifiedExpressionStatement : UnifiedStatement {

		public UnifiedExpression Expression { get; private set; }

		public UnifiedExpressionStatement(UnifiedExpression expr) {
			this.Expression = expr;
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}
