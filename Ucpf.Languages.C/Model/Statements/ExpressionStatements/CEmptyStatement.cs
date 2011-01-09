using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ucpf.Common.Model;

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
	}
}
