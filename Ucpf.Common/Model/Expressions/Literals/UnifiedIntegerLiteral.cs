using System.Numerics;

using Ucpf.Common.Visitors;

namespace Ucpf.Common.Model {
	public class UnifiedIntegerLiteral : UnifiedTypedLiteral<BigInteger> {
		public UnifiedIntegerLiteral(int value) {
			this.TypedValue = value;
		}

		public UnifiedIntegerLiteral(BigInteger value) {
			this.TypedValue = value;
		}

		public override void Accept(IUnifiedModelVisitor conv) {
			conv.Visit(this);
		}

		public override string ToString() {
			return UnifiedModelToXml.ToXml(this).ToString();
		}
	}
}