namespace Ucpf.Common.Model {
	public interface IElseIfBlock : IBlock {
		IExpression ConditionalExpression { get; set; }
	}
}