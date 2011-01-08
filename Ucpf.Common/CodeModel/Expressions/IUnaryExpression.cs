using Ucpf.Common.CodeModel;

namespace Ucpf.Common.CodeModel
{
	public interface IUnaryExpression : IExpression
	{
		IUnaryOperator Operator { get; set; }
		IExpression Term { get; set; }
	}
}
