using Ucpf.CodeModel.Operators;

namespace Ucpf.CodeModel.Expressions
{
	public interface IUnaryExpression
	{
		IOperator Operator { get; set; }
		IExpression Term { get; set; }
	}
}
