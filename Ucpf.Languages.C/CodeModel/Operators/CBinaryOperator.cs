using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ucpf.CodeModel;
using Ucpf.CodeModelToCode;

namespace Ucpf.Languages.C.CodeModel
{
	public class CBinaryOperator : IBinaryOperator
	{
		public CBinaryOperator(string sign, BinaryOperatorType type) {
			Sign = sign;
			Type = type;
		}

		public void Accept(ICodeModelToCode conv) {
			conv.Generate(this);
		}

		public string Sign { get; private set; }

		public BinaryOperatorType Type { get; private set; }
	}
}
