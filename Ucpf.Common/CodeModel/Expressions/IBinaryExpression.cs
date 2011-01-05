using Ucpf.Common.CodeModel.Operators;

namespace Ucpf.Common.CodeModel.Expressions
{
	public interface IBinaryExpression : IExpression
	{
		IBinaryOperator Operator { get; set; }
		IExpression LeftHandSide { get; set; }
		IExpression RightHandSide { get; set; }
	}
}
