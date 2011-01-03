namespace Ucpf.CodeModel
{
	public interface IAssignmentOperator : ICodeElement
	{
		string Sign { get;}
		AssignmentOperatorType Type { get; }
	}
}
