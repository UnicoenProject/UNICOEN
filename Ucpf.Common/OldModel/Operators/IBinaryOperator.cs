namespace Ucpf.Common.Model {
	public interface IBinaryOperator : ICodeElement {
		string Sign { get; }
		BinaryOperatorType Type { get; }
	}
}