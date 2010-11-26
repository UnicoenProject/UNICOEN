using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ucpf.Languages.C
{
	public class CVariable
	{
		public string Name;
		public CType Type;

		// constructor
		public CVariable(CType type, string name)
		{
			Name = name;
			Type = type;
		}
	}
}
