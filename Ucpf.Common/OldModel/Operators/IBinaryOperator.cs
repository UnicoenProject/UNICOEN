namespace Ucpf.Common.OldModel.Operators {
	public interface IBinaryOperator : ICodeElement {
		string Sign { get; }
		BinaryOperatorType Type { get; }
	}
}