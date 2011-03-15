using System.Numerics;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedIntegerLiteral : UnifiedTypedLiteral<BigInteger> {
		public override TResult Accept<TData, TResult>(IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
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