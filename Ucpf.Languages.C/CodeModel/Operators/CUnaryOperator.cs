using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ucpf.CodeModel;
using Ucpf.CodeModelToCode;

namespace Ucpf.Languages.C.CodeModel
{
	public class CUnaryOperator : IUnaryOperator
	{
		public CUnaryOperator(string sign, UnaryOperatorType type) {
			Sign = sign;
			Type = type;
		}

		public void Accept(ICodeModelToCode conv) {
			throw new NotImplementedException();
		}

		public string Sign { get; private set; }

		public UnaryOperatorType Type { get; private set; }
	}
}
