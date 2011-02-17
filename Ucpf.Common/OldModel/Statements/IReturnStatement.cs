using Ucpf.Common.OldModel.Expressions;

namespace Ucpf.Common.OldModel.Statements {
	public interface IReturnStatement : IStatement {
		IExpression Expression { get; }
	}
}