using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedTernaryOperator : UnifiedElement {
		public string FirstSign { get; private set; }

		public string SecondSign { get; private set; }

		public UnifiedTernaryOperatorKind Kind { get; private set; }

		private UnifiedTernaryOperator() {}

		public static UnifiedTernaryOperator Create(string first, string second,
		                                            UnifiedTernaryOperatorKind kind) {
			return new UnifiedTernaryOperator {
					FirstSign = first,
					SecondSign = second,
					Kind = kind,
			};
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override void Accept<TData>(IUnifiedModelVisitor<TData> visitor,
		                                   TData data) {
			visitor.Visit(this, data);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override IEnumerable<IUnifiedElement> GetElements() {
			yield break;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndSetters() {
			yield break;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndDirectSetters() {
			yield break;
		}
	}
}