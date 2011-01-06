namespace Ucpf.Common.CodeModel.Operators
{
	public interface IAssignmentOperator : ICodeElement
	{
		string Sign { get;}
		AssignmentOperatorType Type { get; }
	}
}
