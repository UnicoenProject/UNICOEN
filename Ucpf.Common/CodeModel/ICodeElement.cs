using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ucpf.CodeModelToCode;

namespace Ucpf.CodeModel
{
	public interface ICodeElement {
		void Accept(ICodeModelToCode conv);
	}
}
