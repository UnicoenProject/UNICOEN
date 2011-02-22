using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ucpf.Common.Model.Visitors;

namespace Ucpf.Common.Model {
	public abstract class UnifiedExpression : UnifiedElement {
		public UnifiedStatement ToStatement() {
			return new UnifiedExpressionStatement(this);
		}
	}
}
