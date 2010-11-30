using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ucpf.Languages.C
{
	public class CValue
	{
		public int NumericValue { get; set; }

		// constructor
		public CValue(Object num)
		{
			NumericValue = int.Parse(num.ToString());
		}
	}
}
