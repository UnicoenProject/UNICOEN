using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ucpf.Languages.C
{
	public class COperator
	{
		public string Name { get; set; }


		// constructor
		public COperator(string name)
		{
			Name = name;
		}
	}
}

/*
 * Binary Operator of C
 * arithmetic operator :: * / % + -
 * bit operator :: << >> & | ^ ~
 * substitution operator :: =,+=,-=,*=,/= 
 * comparison operator :: <=, <, >=, >, ==, != 
 * logical oeprator :: && ||
*/