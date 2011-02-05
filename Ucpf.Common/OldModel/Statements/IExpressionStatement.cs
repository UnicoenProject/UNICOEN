namespace Ucpf.Common.Model {
	public interface IExpressionStatement : IStatement {
		IExpression Expression { get; set; }
	}
}