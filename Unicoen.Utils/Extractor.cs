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
            using (var fs = File.OpenRead(inPath)) {
                using (var stream = new GZipInputStream(fs)) {
                    var archive = TarArchive.CreateInputTarArchive(stream);
                    archive.ExtractContents(outDirPath);
                }
            }
        }

        public static void Untbz(string inPath, string outDirPath) {
            using (var fs = File.OpenRead(inPath)) {
                using (var stream = new BZip2InputStream(fs)) {
                    var archive = TarArchive.CreateInputTarArchive(stream);
                    archive.ExtractContents(outDirPath);
                }
            }
        }

        public static void Unzip(Stream stream, string outDirPath) {
            var fastZip = new FastZip();
            fastZip.ExtractZip(
                    stream, outDirPath, FastZip.Overwrite.Always, null, null,
                    null, true, true);
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