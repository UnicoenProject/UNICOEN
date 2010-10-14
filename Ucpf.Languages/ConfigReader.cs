using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

namespace OpenCodeProcessorFramework.Languages
{
	public static class ConfigReader
	{
		public static string Python2()
		{
			return @"C:\Python27\python.exe";
		}

		public static string Python3()
		{
			return @"C:\Python31\python.exe";
		}

		public static string IronRuby()
		{
			return @"C:\Program Files\IronRuby 1.1";
		}
	}
}
