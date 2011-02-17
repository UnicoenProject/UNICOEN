namespace Ucpf.Common.OldModel.Operators {
	public interface IUnaryOperator : ICodeElement {
		string Sign { get; }
		UnaryOperatorType Type { get; }
	}
}