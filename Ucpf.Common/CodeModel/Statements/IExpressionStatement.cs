using Ucpf.Common.CodeModel.Expressions;

namespace Ucpf.Common.CodeModel.Statements
{
	public interface IExpressionStatement : IStatement
	{
		IExpression Expression { get; set; }
	}
}
