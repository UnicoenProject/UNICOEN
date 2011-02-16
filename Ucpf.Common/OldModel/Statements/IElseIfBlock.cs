using Ucpf.Common.OldModel.Expressions;

namespace Ucpf.Common.OldModel.Statements {
	public interface IElseIfBlock : IBlock {
		IExpression ConditionalExpression { get; set; }
	}
}