using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ICSharpCode.SharpZipLib.BZip2;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Tar;
using ICSharpCode.SharpZipLib.Zip;
using Ionic.Zip;
using ZipFile = Ionic.Zip.ZipFile;

namespace Unicoen.Utils {
	public static class Extractor {
		public static void Unzip(string path) {
			var dirPath = Path.GetDirectoryName(path);
			Unzip(path, dirPath);
		}

		public static void Untgz(string path) {
			var dirPath = Path.GetDirectoryName(path);
			Untgz(path, dirPath);
		}

		public static void Untbz(string path) {
			var dirPath = Path.GetDirectoryName(path);
			Untbz(path, dirPath);
		}

		public static void Unzip(string inPath, string outDirPath) {
			var fastZip = new FastZip();
			fastZip.ExtractZip(inPath, outDirPath, null);
			//using (var zip = ZipFile.Read(inPath)) {
			//    foreach (var e in zip) {
			//        e.Extract(outDirPath, ExtractExistingFileAction.OverwriteSilently);
			//    }
			//}
		}

		public static void Untgz(string inPath, string outDirPath) {
			using (var fs = File.OpenRead(inPath))
			using (var stream = new GZipInputStream(fs)) {
				var archive = TarArchive.CreateInputTarArchive(stream);
				archive.ExtractContents(outDirPath);
			}
		}

		public static void Untbz(string inPath, string outDirPath) {
			using (var fs = File.OpenRead(inPath))
			using (var stream = new BZip2InputStream(fs)) {
				var archive = TarArchive.CreateInputTarArchive(stream);
				archive.ExtractContents(outDirPath);
			}
		}
	}
}
