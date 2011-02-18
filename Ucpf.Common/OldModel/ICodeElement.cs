
using Ucpf.Common.Visitors;

namespace Ucpf.Common.OldModel {
	public interface ICodeElement {
		void Accept(IModelToCode conv);
	}
}