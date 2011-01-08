using Ucpf.Common.CodeModel;

namespace Ucpf.Common.CodeModel
{
	public interface IElseIfBlock : IBlock
	{
		IExpression ConditionalExpression { get; set; }
	}
}
