namespace Ucpf.Common.CodeModel
{
	public interface IUnaryOperator : ICodeElement
	{
		string Sign { get; }
		UnaryOperatorType Type { get; }
	}
}
