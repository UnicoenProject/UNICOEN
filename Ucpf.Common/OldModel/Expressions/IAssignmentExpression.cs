using Ucpf.Common.OldModel.Operators;

namespace Ucpf.Common.OldModel.Expressions {
	public interface IAssignmentExpression : IExpression {
		IAssignmentOperator Operator { get; set; }
		IExpression LValue { get; set; }
		IExpression RExpression { get; set; }
	}
}