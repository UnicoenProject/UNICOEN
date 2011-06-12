using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Unicoen.Apps.Aop
{
	public static class FileCollector
	{
		public static IEnumerable<string> Collect(string folderRootPath) {
			return Directory.EnumerateFiles(folderRootPath, "*", SearchOption.AllDirectories);
		}
	}
}
