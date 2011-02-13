using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ucpf.Common.Model {
	public sealed class UnifiedExpressionStatement : UnifiedStatement {

		public UnifiedExpression Expression { get; private set; }

		public UnifiedExpressionStatement(UnifiedExpression expr) {
			this.Expression = expr;
		}
	}
}
