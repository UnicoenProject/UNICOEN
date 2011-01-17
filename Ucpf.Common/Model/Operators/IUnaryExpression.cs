using Ucpf.Common.Model;

namespace Ucpf.Common.Model
{
	public interface IUnaryExpression : IExpression
	{
		IUnaryOperator Operator { get; set; }
		IExpression Term { get; set; }
	}
}
