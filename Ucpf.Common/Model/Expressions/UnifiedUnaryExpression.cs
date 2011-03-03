using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ucpf.Common.Model.Visitors;

namespace Ucpf.Common.Model {
	public class UnifiedUnaryExpression : UnifiedExpression {
		public UnifiedUnaryOperator Operator { get; set; }
		public UnifiedExpression Operand { get; set; }

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}
