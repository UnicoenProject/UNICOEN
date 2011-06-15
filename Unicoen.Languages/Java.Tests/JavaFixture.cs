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
using NUnit.Framework;
using Paraiba.Core;
using Unicoen.Core.Processor;
using Unicoen.Core.Tests;
using Unicoen.Languages.Tests;

namespace Unicoen.Languages.Java.Tests {
	/// <summary>
	///   テストに必要なデータを提供します．
	/// </summary>
	public class JavaFixture : Fixture {
		private const string CompileCommand = "javac";

		/// <summary>
		///   対応する言語のソースコードの拡張子を取得します．
		/// </summary>
		public override string Extension {
			get { return ".java"; }
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
		public override ModelFactory ModelFactory {
			get { return JavaFactory.ModelFactory; }
		}

		/// <summary>
		///   対応する言語のコード生成器を取得します．
		/// </summary>
		public override CodeFactory CodeFactory {
			get { return JavaFactory.CodeFactory; }
		}

		/// <summary>
		///   テスト時に入力されるA.xxxファイルのメソッド宣言の中身です。
		///   Java言語であれば，<c>class A { public void M1() { ... } }</c>の...部分に
		///   このプロパティで指定されたコード断片を埋め込んでA.javaファイルが生成されます。
		/// </summary>
		public override IEnumerable<TestCaseData> TestCodes {
			get {
				var statements = new[] {
						"M1();",
						"new A();",
						"int[] a[][] = new int[1][1][1]; System.out.println(a);",
				}.Select(s => new TestCaseData(DecorateToCompile(s)));

				var codes = new[] {
						"class A { }",
						"public class A { }",
				}.Select(s => new TestCaseData(s));

				return statements.Concat(codes);
			}
		}

		private static string DecorateToCompile(string statement) {
			return "class A { public void M1() {" + statement + "} }";
		}

		/// <summary>
		///   テスト時に入力するファイルパスの集合です．
		/// </summary>
		public override IEnumerable<TestCaseData> TestFilePathes {
			get {
				// 必要に応じて以下の要素をコメントアウト
				return new[] {
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
				const string cmd = CompileCommand;
				const string args = "*.java";
				return new[] {
						new { DirName = "default", Command = cmd, Arguments = args },
						new { DirName = "NewTestFiles", Command = cmd, Arguments = args },
				}
						.Select(
								o => new TestCaseData(
								     		FixtureUtil.GetInputPath(LanguageName, o.DirName),
								     		o.Command,
								     		o.Arguments))
						.Concat(
								new[] {
										SetUpJUnit(),
								});
			}
		}

		/// <summary>
		///   セマンティクスの変化がないか比較するためにソースコードをデフォルトの設定でコンパイルします．
		/// </summary>
		/// <param name = "dirPath"></param>
		/// <param name = "fileName"></param>
		public override void Compile(string dirPath, string fileName) {
			var args = new[] {
					"\"" + Path.Combine(dirPath, fileName) + "\""
			};
			var arguments = args.JoinString(" ");
			CompileWithArguments(dirPath, CompileCommand, arguments);
		}

		private TestCaseData SetUpJUnit() {
			var path = FixtureUtil.GetDownloadPath(LanguageName, "JUnit4.8.2");
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