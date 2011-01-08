using Ucpf.Common.CodeModel;

namespace Ucpf.Common.CodeModel
{
	public interface IReturnStatement : IStatement
	{
		IExpression Expression { get; }
	}
}
