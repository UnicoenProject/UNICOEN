using Ucpf.Common.ModelToCode;

namespace Ucpf.Common.Model {
	public interface ICodeElement {
		void Accept(IModelToCode conv);
	}
}