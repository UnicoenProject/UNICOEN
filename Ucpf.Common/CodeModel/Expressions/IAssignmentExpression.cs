using Ucpf.Common.CodeModel.Operators;

namespace Ucpf.Common.CodeModel.Expressions
{
	public interface IAssignmentExpression : IExpression {
		IAssignmentOperator Operator { get; set; }
		IExpression LValue { get; set; }
		IExpression RExpression { get; set; }
	}
}
