namespace Ucpf.CodeModel
{
	public interface IUnaryExpression
	{
		IUnaryOperator Operator { get; set; }
		IExpression Term { get; set; }
	}
}
