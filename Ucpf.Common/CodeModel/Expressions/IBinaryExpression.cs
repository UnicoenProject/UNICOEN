using Ucpf.Common.CodeModel;

namespace Ucpf.Common.CodeModel
{
	public interface IBinaryExpression : IExpression
	{
		IBinaryOperator Operator { get; set; }
		IExpression LeftHandSide { get; set; }
		IExpression RightHandSide { get; set; }
	}
}
