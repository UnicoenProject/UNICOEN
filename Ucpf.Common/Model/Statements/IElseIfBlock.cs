using Ucpf.Common.Model;

namespace Ucpf.Common.Model
{
	public interface IElseIfBlock : IBlock
	{
		IExpression ConditionalExpression { get; set; }
	}
}
