namespace Ucpf.Common.Model {
	public interface IAssignmentExpression : IExpression {
		IAssignmentOperator Operator { get; set; }
		IExpression LValue { get; set; }
		IExpression RExpression { get; set; }
	}
}