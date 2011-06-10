using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Ionic.Zip;

namespace Unicoen.Languages.Tests
{
	public static class FixtureManager
	{
		public static void Download(string url, string outputPath) {
			using (var client = new WebClient()) {
				client.DownloadFile(url, outputPath);
			}
		}

		public static void Unzip(string path) {
			var dirPath = Path.GetDirectoryName(path);
			using (var zip = ZipFile.Read(path)) {
				foreach (var e in zip) {
					e.Extract(dirPath, ExtractExistingFileAction.OverwriteSilently);
				}
			}
		}
	}
}
