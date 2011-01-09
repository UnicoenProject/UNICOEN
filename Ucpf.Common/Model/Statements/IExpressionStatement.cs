using Ucpf.Common.Model;

namespace Ucpf.Common.Model
{
	public interface IExpressionStatement : IStatement
	{
		IExpression Expression { get; set; }
	}
}
