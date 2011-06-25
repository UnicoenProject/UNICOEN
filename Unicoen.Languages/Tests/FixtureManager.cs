#region License

// Copyright (C) 2011 The Unicoen Project
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System.IO;
using System.Net;
using Ionic.Zip;

namespace Unicoen.Languages.Tests {
	public static class FixtureManager {
		public static void Download(string url, string outputPath) {
			using (var client = new WebClient()) {
				client.DownloadFile(url, outputPath);
			}
		}

		public static void DownloadStream(string url, string outputPath) {
			var outFile = Path.Combine(outputPath, "source.zip");

			using (var client = new WebClient())
			using (var stream = client.OpenRead(url))
			//using (var file = new FileStream(outFile, FileMode.Create)) {
			using (var file = new FileStream(@"C:\output\hoge.zip", FileMode.Create)) {
				var buff = new byte[1024];
				int len = 0;
				while((len = stream.Read(buff, 0, buff.Length)) > 0) {
					file.Write(buff, 0, len);
				}
			}
		}

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