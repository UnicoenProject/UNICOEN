using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Ucpf.CodeModel;

namespace Ucpf.CodeModelToCode
{
	public interface ICodeModelToCode {
		void Generate(IBinaryExpression bin);
		void Generate(IBinaryOperator op);
		void Generate(IUnaryOperator op);
	}
}
