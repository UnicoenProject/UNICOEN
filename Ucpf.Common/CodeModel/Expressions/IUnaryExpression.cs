namespace Ucpf.CodeModel
{
	public interface IUnaryExpression : IExpression
	{
		IUnaryOperator Operator { get; set; }
		IExpression Term { get; set; }
	}
}
