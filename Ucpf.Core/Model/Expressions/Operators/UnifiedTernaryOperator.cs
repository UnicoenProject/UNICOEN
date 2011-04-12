using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedTernaryOperator : UnifiedElement {
		public string Sign { get; private set; }

		public UnifiedTernaryOperatorKind Kind { get; private set; }

		private UnifiedTernaryOperator() {}

		public static UnifiedTernaryOperator Create(string sign,
		                                           UnifiedTernaryOperatorKind kind)
		{
			return new UnifiedTernaryOperator {
				Sign = sign,
				Kind = kind,
			};
		}

		public override void Accept(IUnifiedModelVisitor visitor)
		{
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(
			IUnifiedModelVisitor<TData, TResult> visitor, TData data)
		{
			return visitor.Visit(this, data);
		}

		public override IEnumerable<IUnifiedElement> GetElements()
		{
			yield break;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndSetters()
		{
			yield break;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndDirectSetters()
		{
			yield break;
		}

	}
}
