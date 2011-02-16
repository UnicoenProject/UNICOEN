using Ucpf.Common.OldModel.Expressions;

namespace Ucpf.Common.OldModel.Operators {
	public interface IUnaryExpression : IExpression {
		IUnaryOperator Operator { get; set; }
		IExpression Term { get; set; }
	}
}