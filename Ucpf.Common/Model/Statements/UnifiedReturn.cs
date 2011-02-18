using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ucpf.Common.Visitors;

namespace Ucpf.Common.Model {
	public class UnifiedReturn : UnifiedStatement {
		public UnifiedExpression Value { get; set; }

		public UnifiedReturn(UnifiedExpression expression) {
			Value = expression;
		}

		public override void Accept(IUnifiedModelVisitor conv) {
			conv.Visit(this);
		}
	}
}
