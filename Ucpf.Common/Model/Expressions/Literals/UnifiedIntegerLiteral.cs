using System.Numerics;
using Ucpf.Common.Model.Visitors;

namespace Ucpf.Common.Model {
	public class UnifiedIntegerLiteral : UnifiedTypedLiteral<BigInteger> {
		public UnifiedIntegerLiteral(int value) {
			this.TypedValue = value;
		}

		public UnifiedIntegerLiteral(BigInteger value) {
			this.TypedValue = value;
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}