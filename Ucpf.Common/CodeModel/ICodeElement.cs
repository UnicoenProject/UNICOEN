using Ucpf.Common.CodeModelToCode;

namespace Ucpf.Common.CodeModel
{
	public interface ICodeElement {
		void Accept(ICodeModelToCode conv);
	}
}
