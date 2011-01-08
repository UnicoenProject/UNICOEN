using Ucpf.Common.CodeModel;

namespace Ucpf.Common.CodeModel
{
	public interface IAssignmentExpression : IExpression {
		IAssignmentOperator Operator { get; set; }
		IExpression LValue { get; set; }
		IExpression RExpression { get; set; }
	}
}
