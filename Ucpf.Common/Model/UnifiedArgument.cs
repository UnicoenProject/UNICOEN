using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ucpf.Common.Model {
	public class UnifiedArgument {

		public UnifiedExpression Value { get; set; }

		public static implicit operator UnifiedArgument(UnifiedExpression expr) {
			return new UnifiedArgument { Value = expr };
		}
	}
}
