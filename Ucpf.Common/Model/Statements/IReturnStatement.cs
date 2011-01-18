namespace Ucpf.Common.Model {
	public interface IReturnStatement : IStatement {
		IExpression Expression { get; }
	}
}