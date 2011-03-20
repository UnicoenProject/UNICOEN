using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedUnaryOperator : UnifiedElement {
		public string Sign { get; private set; }
		public UnifiedUnaryOperatorType Type { get; private set; }

		public UnifiedUnaryOperator(string sign, UnifiedUnaryOperatorType type) {
			Sign = sign;
			Type = type;
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(
			IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override IEnumerable<UnifiedElement> GetElements() {
			yield break;
		}

		public override IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>> GetElementsAndSetters() {
			yield break;
		}
	}
}