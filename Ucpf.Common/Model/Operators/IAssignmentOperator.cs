namespace Ucpf.Common.Model
{
	public interface IAssignmentOperator : ICodeElement
	{
		string Sign { get;}
		AssignmentOperatorType Type { get; }
	}
}
