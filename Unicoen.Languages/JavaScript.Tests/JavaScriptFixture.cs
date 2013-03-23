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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Paraiba.Text;
using Unicoen.CodeGenerators;
using Unicoen.Languages.Java.Tests;
using Unicoen.Languages.Tests;
using Unicoen.ProgramGenerators;
using Unicoen.TestUtils;
using Unicoen.Tests;

namespace Unicoen.Languages.JavaScript.Tests {
    public partial class JavaScriptFixture : Fixture {
        private const string CompileCommand = "java";
        private const string DisassembleCommand = "javap";

        private readonly string[] _compileArguments;
        private readonly JavaFixture _javaFixture = new JavaFixture();

        public JavaScriptFixture() {
            _compileArguments = new[] {
                    "-cp",
                    SetUpRhino(),
                    "org.mozilla.javascript.tools.jsc.Main"
            };
        }

        /// <summary>
        ///   対応する言語のソースコードの拡張子を取得します．
        /// </summary>
        public override string Extension {
            get { return ".js"; }
        }

        /// <summary>
        ///   対応する言語のソースコードの拡張子を取得します．
        /// </summary>
        public override string CompiledExtension {
            get { return ".class"; }
        }

        /// <summary>
        ///   対応する言語のモデル生成器を取得します．
        /// </summary>
        public override UnifiedProgramGenerator ProgramGenerator {
            get { return JavaScriptFactory.ProgramGenerator; }
        }

        /// <summary>
        ///   対応する言語のコード生成器を取得します．
        /// </summary>
        public override UnifiedCodeGenerator CodeGenerator {
            get { return JavaScriptFactory.CodeGenerator; }
        }

        /// <summary>
        ///   セマンティクスの変化がないか比較するためにソースコードをデフォルトの設定でコンパイルします．
        /// </summary>
        /// <param name="workPath"> コンパイル対象のソースコードが格納されているディレクトリのパス </param>
        /// <param name="srcPath"> コンパイル対象のソースコードのファイル名 </param>
        public override void Compile(string workPath, string srcPath) {
            var args = _compileArguments.Concat(
                    new[] {
                            "\"" + Path.Combine(workPath, srcPath) + "\""
                    });
            //e.g. (java) -cp js.jar org.mozilla.javascript.tools.jsc.Main *.js
            var arguments = string.Join(" ", args);
            CompileWithArguments(workPath, CompileCommand, arguments);
        }

    	/// <summary>
    	///   コンパイル済みのコードのバイト列を取得します．
    	/// </summary>
    	/// <param name="rootPath">コンパイル済みコードのルートディレクトリ</param>
    	/// <param name="path"> コンパイル済みのコードのパス </param>
    	/// <returns> コンパイル済みのコードのバイト列 </returns>
    	public override object GetCompiledByteCode(string rootPath, string path) {
            var args = new[] { "-c", path };
            var info = new ProcessStartInfo {
                    FileName = DisassembleCommand,
                    Arguments = string.Join(" ", args),
                    CreateNoWindow = true,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
            };

            try {
                using (var p = Process.Start(info)) {
                    var str = p.StandardOutput.ReadToEnd();
                    p.WaitForExit();
                    if (p.ExitCode != 0) {
                        throw new InvalidOperationException(
                                "Failed to disassemble the exe file.");
                    }
                    var indexOfgetEncodedSource =
                            str.IndexOf(
                                    "  public java.lang.String getEncodedSource();");
                    var indexOfgetParamOrVarConst =
                            str.IndexOf(
                                    "  public boolean getParamOrVarConst(int);");
                    str = str.Substring(0, indexOfgetEncodedSource)
                          + str.Substring(indexOfgetParamOrVarConst);
                    return str;
                    //return string.Join(
                    //        "\n", str.Split(new[] { "\n" }, StringSplitOptions.None).Select(
                    //                s => {
                    //                    var index = s.IndexOf("//");
                    //                    if (index >= 0) {
                    //                        return s.Substring(0, index);
                    //                    }
                    //                    return s;
                    //                }));
                }
            } catch (Win32Exception e) {
                throw new InvalidOperationException(
                        "Failed to launch 'ildasmPath': " + DisassembleCommand,
                        e);
            }
        }

        private string SetUpRhino() {
            var path = FixtureUtil.GetDownloadPath(LanguageName, "Rhino");
            var jarPath = Path.Combine(path, "rhino1_7R3", "js.jar");
            if (Directory.Exists(path)
                &&
                Directory.EnumerateFiles(
                        path, "*" + Extension, SearchOption.AllDirectories).
                        Count() >= 1) {
                return jarPath;
            }
            Directory.CreateDirectory(path);
            DownloadAndUnzip(
                    "ftp://ftp.mozilla.org/pub/mozilla.org/js/rhino1_7R3.zip",
                    path);
            return jarPath;
        }

        private IEnumerable<TestCaseData> SetUpjQuery() {
            return SetUpTestCaseData(
                    "jQuery1.6.1",
                    path => Downloader.Download(
                            "http://code.jquery.com/jquery-1.6.1.js",
                            Path.Combine(path, "src.js")), CompileAll);
        }

        private IEnumerable<TestCaseData> SetUpjQueryMin() {
            return SetUpTestCaseData(
                    "jQuery1.6.1.min",
                    path => Downloader.Download(
                            "http://code.jquery.com/jquery-1.6.1.min.js",
                            Path.Combine(path, "src.js"))
                    );
        }

        private IEnumerable<TestCaseData> SetUpProcessing_js() {
            return SetUpTestCaseData(
                    "Processing.js-1.2.3",
                    path => Downloader.Download(
                            "http://processingjs.org/content/download/processing-js-1.2.3/processing-1.2.3.js",
                            Path.Combine(path, "src.js")),
                    CompileAll);
        }

        private IEnumerable<TestCaseData> SetUpProcessing_jsMin() {
            return SetUpTestCaseData(
                    "Processing.js-1.2.3-min",
                    path => Downloader.Download(
                            "http://processingjs.org/content/download/processing-js-1.2.3/processing-1.2.3.min.js",
                            Path.Combine(path, "src.js")),
                    CompileAll);
        }

        private IEnumerable<TestCaseData> SetUpProcessing_jsApi() {
            return SetUpTestCaseData(
                    "Processing.js-1.2.3-api",
                    path => Downloader.Download(
                            "http://processingjs.org/content/download/processing-js-1.2.3/processing-1.2.3-api.js",
                            Path.Combine(path, "src.js")),
                    CompileAll);
        }

        private IEnumerable<TestCaseData> SetUpProcessing_jsApiMin() {
            return SetUpTestCaseData(
                    "Processing.js-1.2.3-api.min",
                    path => Downloader.Download(
                            "http://processingjs.org/content/download/processing-js-1.2.3/processing-1.2.3-api.min.js",
                            Path.Combine(path, "src.js")),
                    CompileAll);
        }

        private IEnumerable<TestCaseData> SetUpDojo() {
            return SetUpTestCaseData(
                    "dojo",
                    path => Downloader.Download(
                            "http://download.dojotoolkit.org/release-1.6.1/dojo.js.uncompressed.js",
                            Path.Combine(path, "src.js")),
                    CompileAll);
        }

        private IEnumerable<TestCaseData> SetUpDojoMin() {
            return SetUpTestCaseData(
                    "dojo.min",
                    path => Downloader.Download(
                            "http://download.dojotoolkit.org/release-1.6.1/dojo.js",
                            Path.Combine(path, "src.js")),
                    CompileAll);
        }

        private IEnumerable<TestCaseData> SetUpPlay() {
            return SetUpTestCaseData(
                    "play-1.2RC3",
                    path =>
                    DownloadAndUnzip(
                            "https://github.com/playframework/play/zipball/1.2RC3",
                            path),
                    TryCompileAll);
        }

        private IEnumerable<TestCaseData> SetUpAIChallenge() {
            return SetUpTestCaseData(
                    "aichallenge",
                    path =>
                    DownloadAndUnzip(
                            "https://github.com/aichallenge/aichallenge/zipball/epsilon",
                            path),
                    workPath => {
                        var paths = Directory.EnumerateFiles(
                                workPath, "*.js", SearchOption.AllDirectories);
                        foreach (var path in paths) {
                            GuessEncoding.Convert(path, Encoding.Default);
                        }
                        CompileAll(workPath);
                    });
        }
    }
}