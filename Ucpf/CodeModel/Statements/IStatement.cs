using System.Collections.Generic;
namespace Ucpf.CodeModel
{
	public interface IStatement : ICodeElement
	{
		IList<IExpression> Expressions { get; set; }
	}
}
