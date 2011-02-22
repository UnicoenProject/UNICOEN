using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ucpf.Common.Visitors;

namespace Ucpf.Common.Model
{
	public abstract class UnifiedExpression : UnifiedElement
	{
		public static implicit operator UnifiedStatement(UnifiedExpression expr) {
			return new UnifiedExpressionStatement(expr);
		}

		public override string ToString() {
			return UnifiedModelToXml.ToXml(this).ToString();
		}
	}
}
