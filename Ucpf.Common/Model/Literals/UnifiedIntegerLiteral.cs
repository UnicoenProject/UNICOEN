using System.Numerics;

namespace Ucpf.Common.Model {
	public class UnifiedIntegerLiteral : UnifiedLiteral {
		public BigInteger TypedValue { get; set; }
	}
}