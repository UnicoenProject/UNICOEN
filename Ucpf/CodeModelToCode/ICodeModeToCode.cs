using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Ucpf.CodeModel.Expressions;
using Ucpf.CodeModel.Operators;

namespace Ucpf.CodeModelToCode
{
	public interface ICodeModeToCode {
		string GenerateBinaryExpression(IExpression lhs, IOperator op, IExpression rhs);
	}
}
