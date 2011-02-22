using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ucpf.Common.Model;

using Ucpf.Common.Visitors;

namespace Ucpf.Common.Model {
	public class UnifiedBinaryExpression : UnifiedExpression {
		public UnifiedBinaryOperator Operator { get; set; }
		public UnifiedExpression LeftHandSide { get; set; }
		public UnifiedExpression RightHandSide { get; set; }

		public override void Accept(IUnifiedModelVisitor conv) {
			conv.Visit(this);
		}

		public override string ToString() {
			return UnifiedModelToXml.ToXml(this).ToString();
		}
	}
}
