using Ucpf.Common.ModelToCode;

namespace Ucpf.Common.Model {
	public class UnifiedUnaryOperator {
		public string Sign { get; private set; }
		public UnaryOperatorType Type { get; private set; }

		public UnifiedUnaryOperator(string sign, UnaryOperatorType type) {
			Sign = sign;
			Type = type;
		}
	}
}