using System;
using System.Collections.Generic;
using System.Numerics;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedIntegerLiteral : UnifiedTypedLiteral<BigInteger> {
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

		public override IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>>
				GetElementAndSetters() {
			yield break;
		}

		public override IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>> GetElementAndDirectSetters() {
			yield break;
		}

		public static UnifiedIntegerLiteral Create(int value) {
			return new UnifiedIntegerLiteral {
					Value = value,
			};
		}

		public static UnifiedIntegerLiteral Create(BigInteger value) {
			return new UnifiedIntegerLiteral {
					Value = value,
			};
		}
	}
}