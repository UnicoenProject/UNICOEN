using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ICSharpCode.SharpZipLib.BZip2;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Tar;
using ICSharpCode.SharpZipLib.Zip;
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

		public static void Unzip(Stream stream, string outDirPath) {
			var fastZip = new FastZip();
			fastZip.ExtractZip(stream, outDirPath, FastZip.Overwrite.Always, null, null, null, true, true);
		}

		public static void Untgz(Stream stream, string outDirPath) {
			using (var inputStream = new GZipInputStream(stream)) {
				var archive = TarArchive.CreateInputTarArchive(inputStream);
				archive.AsciiTranslate = false;
				archive.ExtractContents(outDirPath);
			}
		}

		public static void Untbz(Stream stream, string outDirPath) {
			using (var inputStream = new BZip2InputStream(stream)) {
				var archive = TarArchive.CreateInputTarArchive(inputStream);
				archive.AsciiTranslate = false;
				archive.ExtractContents(outDirPath);
			}
		}
	}
}
