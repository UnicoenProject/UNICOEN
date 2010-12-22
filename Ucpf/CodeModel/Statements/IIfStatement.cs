using System.Collections.Generic;
namespace Ucpf.CodeModel
{
	public interface IIfStatement : IStatement
	{
		IExpression Condition { get; set; }
		IBlock TrueBlock { get; set; }
		IBlock FalseBlock { get; set; }
		IList<IElseIfBlock> ElseIfBlocks { get; set; }
	}
}
