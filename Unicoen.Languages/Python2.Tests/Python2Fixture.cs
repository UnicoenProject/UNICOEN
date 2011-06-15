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

using System.Collections.Generic;
using System.IO;
using System.Linq;
using Code2Xml.Core;
using NUnit.Framework;
using Paraiba.Core;
using Unicoen.Core.Processor;
using Unicoen.Core.Tests;
using Unicoen.Languages.Tests;

namespace Unicoen.Languages.Python2.Tests {
	public class Python2Fixture : Fixture {
		private static readonly string CompileCommand =
				Settings.GetPythonInstallPath("2.") ?? "python";

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
		public override ModelFactory ModelFactory {
			get { return Python2Factory.ModelFactory; }
		}

		/// <summary>
		///   対応する言語のコード生成器を取得します．
		/// </summary>
		public override CodeFactory CodeFactory {
			get { return Python2Factory.CodeFactory; }
		}

		/// <summary>
		///   テスト時に入力されるA.xxxファイルのメソッド宣言の中身です。
		///   Java言語であれば，<c>class A { public void M1() { ... } }</c>の...部分に
		///   このプロパティで指定されたコード断片を埋め込んでA.javaファイルが生成されます。
		/// </summary>
		public override IEnumerable<TestCaseData> TestCodes {
			get {
				return new[] {
						"a = 1",
						"class A: pass",
				}.Select(s => new TestCaseData(s));
			}
		}

		/// <summary>
		///   テスト時に入力するファイルパスの集合です．
		/// </summary>
		public override IEnumerable<TestCaseData> TestFilePathes {
			get {
				// 必要に応じて以下の要素をコメントアウト
				return new[] {
						"Block1",
						"Block2",
						"Block3",
						"Fibonacci",
				}
						.Select(
								s =>
								new TestCaseData(FixtureUtil.GetInputPath(LanguageName, s + Extension)));
			}
		}

		/// <summary>
		///   テスト時に入力するプロジェクトファイルのパスとコンパイルのコマンドの組み合わせの集合です．
		/// </summary>
		public override IEnumerable<TestCaseData> TestProjectInfos {
			get {
				yield break;
				//				return new[] {
				//						new { DirName = "default", Command = "javac", Arguments = "*.java" },
				//						new { DirName = "NewTestFiles", Command = "javac", Arguments = "*.java" },
				//				}
				//						.Select(
				//								o => new TestCaseData(
				//								     		Fixture.GetInputPath("Java", o.DirName),
				//								     		o.Command, o.Arguments));
			}
		}

		/// <summary>
		///   セマンティクスの変化がないか比較するためにソースコードをデフォルトの設定でコンパイルします．
		/// </summary>
		/// <param name = "dirPath">コンパイル対象のソースコードが格納されているディレクトリのパス</param>
		/// <param name = "fileName">コンパイル対象のソースコードのファイル名</param>
		public override void Compile(string dirPath, string fileName) {
			var args = new[] {
					"-m",
					"compileall",
					"\"" + Path.Combine(dirPath, fileName) + "\""
			};
			var arguments = args.JoinString(" ");
			CompileWithArguments(dirPath, CompileCommand, arguments);
		}

		private  TestCaseData SetUpPyPy() {
			var path = FixtureUtil.GetDownloadPath(LanguageName, "PyPy");
			var srcPath = Path.Combine(path, "src.zip");
			var depPath = Path.Combine(path, "dep.jar");
			var args = new[] {
					"-cp",
					"\"" + path + "\";\"" + depPath + "\"",
					"\"" + Path.Combine(path, @"org\junit\runner\JUnitCore.java") + "\"",
			};
			var testCase = new TestCaseData(
					path,
					CompileCommand,
					args.JoinString(" "));
			if (Directory.Exists(path))
				return testCase;
			Directory.CreateDirectory(path);
			FixtureManager.Download(
					"https://github.com/downloads/KentBeck/junit/junit-4.8.2-src.jar", srcPath);
			FixtureManager.Unzip(srcPath);
			FixtureManager.Download(
					"https://github.com/downloads/KentBeck/junit/junit-dep-4.8.2.jar", depPath);
			return testCase;
		}
	}
}