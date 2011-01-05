namespace Ucpf.Common.CodeModel.Operators
{
	public interface IUnaryOperator : ICodeElement
	{
		string Sign { get; }
		UnaryOperatorType Type { get; }
	}
}
