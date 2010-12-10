using Ucpf.CodeModel.Operators;
using Ucpf.CodeModelToCode;

namespace Ucpf.CodeModel.Expressions
{
	public interface IBinaryExpression
	{
		IOperator Operator { get; set; }
		IExpression LeftHandSide { get; set; }
		IExpression RightHandSide { get; set; }
	}
}
