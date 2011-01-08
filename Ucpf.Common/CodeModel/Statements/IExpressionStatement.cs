using Ucpf.Common.CodeModel;

namespace Ucpf.Common.CodeModel
{
	public interface IExpressionStatement : IStatement
	{
		IExpression Expression { get; set; }
	}
}
