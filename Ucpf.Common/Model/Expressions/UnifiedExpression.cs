using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ucpf.Common.Model {
	public abstract class UnifiedExpression : UnifiedElement {
		public UnifiedStatement ToStatement() {
			return new UnifiedExpressionStatement(this);
		}
	}
}
