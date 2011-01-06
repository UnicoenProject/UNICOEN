using Ucpf.Common.CodeModel.Expressions;

namespace Ucpf.Common.CodeModel.Statements
{
	public interface IReturnStatement : IStatement
	{
		IExpression Expression { get; }
	}
}
