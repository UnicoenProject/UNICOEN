using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ucpf.Core.Model
{
	public class UnifiedExpressionList : UnifiedExpressionCollection, IUnifiedExpression
	{
		protected UnifiedExpressionList() {}

		protected UnifiedExpressionList(
			IEnumerable<IUnifiedExpression> expressions)
			: base(expressions) {}

		public new static UnifiedExpressionList Create()
		{
			return new UnifiedExpressionList();
		}

		public new static UnifiedExpressionList Create(
			params IUnifiedExpression[] elements)
		{
			return new UnifiedExpressionList(elements);
		}

		public new static UnifiedExpressionList Create(
			IEnumerable<IUnifiedExpression> elements)
		{
			return new UnifiedExpressionList(elements);
		}
	}
}
