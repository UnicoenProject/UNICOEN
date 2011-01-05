namespace Ucpf.Common.CodeModel.Operators
{
	public interface IBinaryOperator : ICodeElement
	{
		string Sign { get; }
		BinaryOperatorType Type { get; }
	}
}
