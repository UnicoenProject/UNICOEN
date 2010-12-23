namespace Ucpf.CodeModel
{
	public interface IBinaryOperator : ICodeElement
	{
		string Sign { get; }
		BinaryOperatorType Type { get; }
	}
}
