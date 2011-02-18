using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ucpf.Common.Visitors;

namespace Ucpf.Common.Model {
	public class UnifiedArgument :UnifiedElement {

		public UnifiedExpression Value { get; set; }

		public static explicit operator UnifiedArgument(UnifiedExpression expr) {
			return new UnifiedArgument { Value = expr };
		}

		public override void Accept(IUnifiedModelVisitor conv) {
			conv.Visit(this);
		}
	}
}
