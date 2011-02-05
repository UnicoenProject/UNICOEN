namespace Ucpf.Common.Model {
	public interface IVariable : ICodeElement {
		string Name { get; set; }
		IType Type { get; set; }
	}
}