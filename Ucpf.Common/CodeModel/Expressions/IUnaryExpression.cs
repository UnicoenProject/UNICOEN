using Ucpf.Common.CodeModel.Operators;

namespace Ucpf.Common.CodeModel.Expressions
{
	public interface IUnaryExpression : IExpression
	{
		IUnaryOperator Operator { get; set; }
		IExpression Term { get; set; }
	}
}
