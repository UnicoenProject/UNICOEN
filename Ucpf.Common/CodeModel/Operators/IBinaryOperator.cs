namespace Ucpf.Common.CodeModel
{
	public interface IBinaryOperator : ICodeElement
	{
		string Sign { get; }
		BinaryOperatorType Type { get; }
	}
}
