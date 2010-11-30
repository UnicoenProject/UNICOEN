using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ucpf.Languages.C
{
	public class CVariableArgument : CArgument
	{
		private string _name;
		public override string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}
		
		// constructor
		public CVariableArgument(string str)
		{
			Name = str;
		}
	}
}
