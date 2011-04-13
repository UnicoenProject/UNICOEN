using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model
{
	public class UnifiedLabel : UnifiedElement, IUnifiedExpression
	{
		private UnifiedIdentifier _name;

		private IUnifiedExpression _expression;

		public override void Accept(IUnifiedModelVisitor visitor)
		{
			throw new NotImplementedException();
		}

		public override TResult Accept<TData, TResult>(IUnifiedModelVisitor<TData, TResult> visitor, TData data)
		{
			throw new NotImplementedException();
		}

		public override IEnumerable<IUnifiedElement> GetElements()
		{
			throw new NotImplementedException();
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>> GetElementAndSetters()
		{
			throw new NotImplementedException();
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>> GetElementAndDirectSetters()
		{
			throw new NotImplementedException();
		}
	}
}
