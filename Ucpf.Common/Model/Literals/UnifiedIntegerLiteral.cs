using System.Numerics;

namespace Ucpf.Common.Model {
	public class UnifiedIntegerLiteral : UnifiedLiteral {
		public BigInteger TypedValue { get; set; }

		public UnifiedIntegerLiteral(int value) {
			this.TypedValue = value;
		}

		public UnifiedIntegerLiteral(BigInteger value) {
			this.TypedValue = value;
		}
	}
}