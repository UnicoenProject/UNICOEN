using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ucpf.Languages.C
{
	public class CConstant : CExpression
	{
		public string Name { get; set; }

		public string ToString()
		{
			return Name;
		}


		// constructor
		public CConstant(string name) : base(null, "const")
		{
			Name = name;
		}
	}
}