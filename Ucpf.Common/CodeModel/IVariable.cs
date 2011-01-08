namespace Ucpf.Common.CodeModel
{
	public interface IVariable : ICodeElement
	{
		string Name { get; set; }
		IType Type { get; set; }
	}
}
