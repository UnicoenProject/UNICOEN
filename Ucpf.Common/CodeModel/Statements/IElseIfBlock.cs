using Ucpf.Common.CodeModel.Expressions;

namespace Ucpf.Common.CodeModel.Statements
{
	public interface IElseIfBlock : IBlock
	{
		IExpression ConditionalExpression { get; set; }
	}
}
