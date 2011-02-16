namespace Ucpf.Common.OldModel.Operators {
	public interface IAssignmentOperator : ICodeElement {
		string Sign { get; }
		AssignmentOperatorType Type { get; }
	}
}