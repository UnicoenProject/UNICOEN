using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ucpf.Common.Model
{
	public abstract class UnifiedExpression
	{


		public static implicit operator UnifiedStatement(UnifiedExpression expr) {
			return new UnifiedExpressionStatement(expr);
		}
	}
}
