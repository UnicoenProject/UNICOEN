using Ucpf.Common.OldModel.Expressions;

namespace Ucpf.Common.OldModel.Statements {
	public interface IExpressionStatement : IStatement {
		IExpression Expression { get; set; }
	}
}