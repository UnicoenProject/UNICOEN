using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ICSharpCode.SharpZipLib.BZip2;
using ICSharpCode.SharpZipLib.Tar;
using Ionic.Zip;

namespace Unicoen.Utils {
	public static class Extractor {
		public static void Unzip(string path) {
			var dirPath = Path.GetDirectoryName(path);
			Unzip(path, dirPath);
		}

		public static void Unzip(string inPath, string outDirPath) {
			using (var zip = ZipFile.Read(inPath)) {
				foreach (var e in zip) {
					e.Extract(outDirPath, ExtractExistingFileAction.OverwriteSilently);
				}
			}
		}
	}
}
