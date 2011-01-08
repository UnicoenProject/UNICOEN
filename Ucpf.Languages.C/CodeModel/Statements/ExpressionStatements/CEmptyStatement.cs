using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ucpf.Common.CodeModel;

namespace Ucpf.Languages.C.CodeModel
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
	}
}
