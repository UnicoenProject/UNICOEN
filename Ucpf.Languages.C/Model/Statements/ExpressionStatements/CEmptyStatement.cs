using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ucpf.Common.Model;
using Ucpf.Common.ModelToCode;

namespace Ucpf.Languages.C.Model
{
	public class CEmptyStatement : CExpressionStatement, IEmptyStatement
	{
		public CEmptyStatement()
		{
		}

		public override string ToString()
		{
			return ";";
		}

		public void Accept(IModelToCode conv)
		{
			conv.Generate(this);
		}
	}
}
