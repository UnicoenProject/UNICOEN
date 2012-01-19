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

namespace Unicoen.Utils {
    public static class Downloader {
        public static void Download(string url, string outPath) {
            using (var client = new WebClient()) {
                using (var stream = client.OpenRead(url)) {
                    using (var file = new FileStream(outPath, FileMode.Create)) {
                        var buff = new byte[64 * 1024];
                        int len;
                        while ((len = stream.Read(buff, 0, buff.Length)) > 0) {
                            file.Write(buff, 0, len);
                        }
                    }
                }
            }
        }

        public static Stream GetStream(string url) {
            return new WebClient().OpenRead(url);
        }
    }
}