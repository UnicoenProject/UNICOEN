using Ucpf.CodeModelToCode;

namespace Ucpf.CodeModel
{
	public interface IBinaryExpression : IExpression
	{
		IBinaryOperator Operator { get; set; }
		IExpression LeftHandSide { get; set; }
		IExpression RightHandSide { get; set; }
	}
}
