using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ucpf.Common.Model {
	public class UnifiedReturn : UnifiedStatement {
		public UnifiedExpression Value { get; set; }

		public UnifiedReturn(UnifiedExpression expression) {
			Value = expression;
		}
	}
}
