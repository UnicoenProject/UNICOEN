namespace Ucpf.Common.Model {
	public interface IUnaryOperator : ICodeElement {
		string Sign { get; }
		UnaryOperatorType Type { get; }
	}
}