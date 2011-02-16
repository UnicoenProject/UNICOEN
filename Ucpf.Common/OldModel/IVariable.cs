namespace Ucpf.Common.OldModel {
	public interface IVariable : ICodeElement {
		string Name { get; set; }
		IType Type { get; set; }
	}
}