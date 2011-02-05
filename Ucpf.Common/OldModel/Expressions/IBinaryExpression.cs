namespace Ucpf.Common.Model {
	public interface IBinaryExpression : IExpression {
		IBinaryOperator Operator { get; set; }
		IExpression LeftHandSide { get; set; }
		IExpression RightHandSide { get; set; }
	}
}