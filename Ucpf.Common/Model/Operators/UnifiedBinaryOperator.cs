using Ucpf.Common.ModelToCode;

namespace Ucpf.Common.Model {
	public class UnifiedBinaryOperator {
		public string Sign { get; private set; }
		public BinaryOperatorType Type { get; private set; }

		public UnifiedBinaryOperator(string sign, BinaryOperatorType type) {
			Sign = sign;
			Type = type;
		}
	}
}