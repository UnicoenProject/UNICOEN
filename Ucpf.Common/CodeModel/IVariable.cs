namespace Ucpf.Common.CodeModel
{
	public interface IVariable
	{
		string Name { get; set; }
		IType Type { get; set; }
	}
}
