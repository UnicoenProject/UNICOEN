using System.Numerics;
using Ucpf.Common.Model.Visitors;

namespace Ucpf.Common.Model {
	public class UnifiedIntegerLiteral : UnifiedTypedLiteral<BigInteger> {
		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
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