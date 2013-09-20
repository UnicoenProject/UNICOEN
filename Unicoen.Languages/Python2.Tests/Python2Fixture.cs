#region License

// Copyright (C) 2011-2013 The Unicoen Project
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

using System.Collections.Generic;
using System.IO;
using Code2Xml.Core;
using Code2Xml.Core.Processors;
using NUnit.Framework;
using Unicoen.CodeGenerators;
using Unicoen.Languages.Tests;
using Unicoen.ProgramGenerators;

namespace Unicoen.Languages.Python2.Tests {
	public partial class Python2Fixture : Fixture {
		private static readonly string CompileCommand = ExternalProgramUtils.GetPythonPath("2") ?? "python";

		/// <summary>
		///   対応する言語のソースコードの拡張子を取得します．
		/// </summary>
		public override string Extension {
			get { return ".py"; }
		}

		/// <summary>
		///   対応する言語のソースコードの拡張子を取得します．
		/// </summary>
		public override string CompiledExtension {
			get { return ".pyc"; }
		}

		/// <summary>
		///   バイトコード同士を比較する際に許容する不一致の要素数を取得します．
		/// </summary>
		public override int AllowedMismatchCount {
			get { return 0; }
		}

		/// <summary>
		///   対応する言語のモデル生成器を取得します．
		/// </summary>
		public override UnifiedProgramGenerator ProgramGenerator {
			get { return Python2Factory.ProgramGenerator; }
		}

		/// <summary>
		///   対応する言語のコード生成器を取得します．
		/// </summary>
		public override UnifiedCodeGenerator CodeGenerator {
			get { return Python2Factory.CodeGenerator; }
		}

		/// <summary>
		///   セマンティクスの変化がないか比較するためにソースコードをデフォルトの設定でコンパイルします．
		/// </summary>
		/// <param name="workPath"> コンパイル対象のソースコードが格納されているディレクトリのパス </param>
		/// <param name="srcPath"> コンパイル対象のソースコードのファイル名 </param>
		public override void Compile(string workPath, string srcPath) {
			var args = new[] {
					"-m",
					"compileall",
					"\"" + srcPath + "\""
			};
			var arguments = string.Join(" ", args);
			CompileWithArguments(workPath, CompileCommand, arguments);
		}

		private IEnumerable<TestCaseData> SetUpPyPy() {
			return SetUpTestCaseData(
					"PyPy",
					path => {
						DownloadAndUntbz("https://bitbucket.org/pypy/pypy/downloads/pypy-1.5-src.tar.bz2", path);
						File.Delete(
								Path.Combine(path, @"pypy-1.5-src\lib-python\2.7\lib2to3\tests\data\py3_test_grammar.py"));
						File.Delete(
								Path.Combine(
										path, @"pypy-1.5-src\lib-python\modified-2.7\lib2to3\tests\data\py3_test_grammar.py"));
						File.Delete(Path.Combine(path, @"pypy-1.5-src\lib_pypy\distributed\socklayer.py"));
						File.Delete(Path.Combine(path, @"pypy-1.5-src\pypy\translator\goal\old_queries.py"));
						Directory.Delete(Path.Combine(path, @"pypy-1.5-src\lib-python\2.7\test"), true);
					});
		}

		//TODO: For Python3
		//private IEnumerable<TestCaseData> SetUpDjango() {
		//    return SetUpTestCaseData(
		//            "django-1.3",
		//            path =>
		//            DownloadAndUnzip(
		//                    "https://github.com/django/django/zipball/1.3", path));
		//}

		private IEnumerable<TestCaseData> SetUpTornade() {
			return SetUpTestCaseData(
					"tornade-2.0.0",
					path => DownloadAndUnzip("https://github.com/facebook/tornado/zipball/v2.0.0", path));
		}
	}
}