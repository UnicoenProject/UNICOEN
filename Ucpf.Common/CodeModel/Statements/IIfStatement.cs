using System.Collections.Generic;
using Ucpf.Common.CodeModel.Expressions;

namespace Ucpf.Common.CodeModel.Statements
{
	public interface IIfStatement : IStatement
	{
		IExpression Condition { get; set; }
		IBlock TrueBlock { get; set; }
		IBlock FalseBlock { get; set; }
		IList<IElseIfBlock> ElseIfBlocks { get; set; }
	}
}
