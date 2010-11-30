using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ucpf.Languages.C
{
	public class CNumericArgument : CArgument
	{
		private int _num;
		public override string Name
		{
			get
			{
				return _num.ToString();
			}
			set	{}
		}

		// constructors
		public CNumericArgument(int num)
		{
			_num = num;
		}

		public CNumericArgument(string snum)
		{
			_num = int.Parse(snum);
		}
	}
}
