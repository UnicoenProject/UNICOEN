
using Ucpf.Common.Model.Visitors;

namespace Ucpf.Common.OldModel {
	public interface ICodeElement {
		void Accept(IModelToCode visitor);
	}
}