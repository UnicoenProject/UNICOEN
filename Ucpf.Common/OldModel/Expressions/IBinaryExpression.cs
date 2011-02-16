using Ucpf.Common.OldModel.Operators;

namespace Ucpf.Common.OldModel.Expressions {
	public interface IBinaryExpression : IExpression {
		IBinaryOperator Operator { get; set; }
		IExpression LeftHandSide { get; set; }
		IExpression RightHandSide { get; set; }
	}
}