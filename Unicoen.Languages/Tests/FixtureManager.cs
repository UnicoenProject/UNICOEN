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