using Ucpf.Common.ModelToCode;

namespace Ucpf.Common.OldModel {
	public interface ICodeElement {
		void Accept(IModelToCode conv);
	}
}