using Ucpf.CodeModel.Operators;
using Ucpf.CodeModelToCode;

namespace Ucpf.CodeModel.Expressions
{
	public interface IBinaryExpression
	{
		IOperator Operator { get; set; }
		IExpression Lhs { get; set; }
		IExpression Rhs { get; set; }
	}
}
