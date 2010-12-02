using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AntlrHelper
{
	class Program
	{
		static void Main(string[] args) {
			foreach (var arg in args) {
				Modifier.Modify(arg);
			}
		}
	}
}
