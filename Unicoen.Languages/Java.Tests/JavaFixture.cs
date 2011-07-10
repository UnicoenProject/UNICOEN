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
using System.IO;
using System.Linq;
using NUnit.Framework;
using Paraiba.Core;
using Unicoen.Core.Processor;
using Unicoen.Core.Tests;
using Unicoen.Languages.Tests;
using Unicoen.Utils;

namespace Unicoen.Languages.Java.Tests {
	/// <summary>
	///   テストに必要なデータを提供します．
	/// </summary>
	public class JavaFixture : Fixture {
		private readonly string _mavenCommand;
		private const string MavenArg = "package";
		private const string CompileCommand = "javac";

		public JavaFixture() {
			_mavenCommand = SetUpMaven3();
		}

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
						"class A { void execute(String ... str) { } }",
						"class A { public @interface M1 { String value(); } }",
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
						.Select(s => FixtureUtil.GetInputPath(LanguageName, s + Extension))
						.Select(s => new TestCaseData(s));
			}
		}

		/// <summary>
		///   テスト時に入力するプロジェクトファイルのパスとコンパイル処理の組み合わせの集合です．
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
								o => {
									Action<string, string> action =
											(s1, s2) => CompileWithArguments(s1, o.Command, o.Arguments);
									return
											new TestCaseData(
													FixtureUtil.GetInputPath(LanguageName, o.DirName), action);
								})
						.Concat(SetUpJUnit())
						.Concat(SetUpJenkins())
						.Concat(SetUpCraftBukkit())
						.Concat(SetUpBukkit())
						;
			}
		}

		public override IEnumerable<TestCaseData> TestHeavyProjectInfos {
			get { return SetUpJdk(); }
		}

		/// <summary>
		///   指定したファイルのソースコードをデフォルトの設定でコンパイルします．
		/// </summary>
		/// <param name = "workPath">コンパイル時の作業ディレクトリのパス</param>
		/// <param name = "srcPath">コンパイル対象のソースコードのパス</param>
		public override void Compile(string workPath, string srcPath) {
			var args = new[] {
					"\"" + srcPath + "\""
			};
			var arguments = args.JoinString(" ");
			CompileWithArguments(workPath, CompileCommand, arguments);
		}

		private string SetUpMaven3() {
			var path = FixtureUtil.GetDownloadPath(LanguageName, "Maven3");
			var exePath = Path.Combine(path, "apache-maven-3.0.3", "bin", "mvn.bat");
			if (Directory.Exists(path)
			    && Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories).Any())
				return exePath;
			Directory.CreateDirectory(path);
			DownloadAndUntgz(
					"http://www.meisei-u.ac.jp/mirror/apache/dist//maven/binaries/apache-maven-3.0.3-bin.tar.gz",
					path);
			return exePath;
		}

		private IEnumerable<TestCaseData> SetUpJUnit() {
			const string srcDirName = "src";
			return SetUpTestCaseData(
					"junit4.8.2",
					path => {
						DownloadAndUnzip(
								"https://github.com/downloads/KentBeck/junit/junit4.8.2.zip", path);
						var srcDirPath = Path.Combine(path, srcDirName);
						var arcPath = Path.Combine(path, "junit4.8.2", "junit-4.8.2-src.jar");
						Extractor.Unzip(arcPath, srcDirPath);
					},
					(workPath, inPath) => {
						workPath = Path.Combine(workPath, srcDirName);
						var depPath = Path.Combine(inPath, "junit4.8.2", "temp.hamcrest.source");
						foreach (var srcPath in GetAllSourceFilePaths(workPath)) {
							var args = new[] {
									"-cp",
									".;\"" + depPath + "\"",
									"\"" + srcPath + "\"",
							};
							CompileWithArguments(workPath, CompileCommand, args.JoinString(" "));
						}
					});
		}

		private void CompileMaven(string workPath) {
			var pomPath =
					Directory.EnumerateFiles(workPath, "pom.xml", SearchOption.AllDirectories).
							First();
			workPath = Path.GetDirectoryName(pomPath);
			CompileWithArguments(workPath, _mavenCommand, MavenArg);
		}

		private IEnumerable<TestCaseData> SetUpJdk() {
			return SetUpTestCaseData(
					"jdk", path => {
						var jdkPath = Directory.GetDirectories(@"C:\Program Files\Java\")
								.LastOrDefault(p => Path.GetFileName(p).StartsWith("jdk"));
						if (jdkPath == null)
							return false;
						var arcPath = Path.Combine(jdkPath, "src.zip");
						Extractor.Unzip(arcPath, path);
						return true;
					});
		}

		private IEnumerable<TestCaseData> SetUpCraftBukkit() {
			return SetUpTestCaseData(
					"CraftBukkit",
					path =>
					DownloadAndUnzip(
							"https://github.com/Bukkit/CraftBukkit/zipball/master", path),
					CompileMaven);
		}

		private IEnumerable<TestCaseData> SetUpBukkit() {
			return SetUpTestCaseData(
					"Bukkit",
					path =>
					DownloadAndUnzip(
							"https://github.com/Bukkit/Bukkit/zipball/master", path),
					CompileMaven);
		}

		private IEnumerable<TestCaseData> SetUpJenkins() {
			return SetUpTestCaseData(
					"jenkins-1.418",
					path =>
					DownloadAndUnzip(
							"https://github.com/jenkinsci/jenkins/zipball/jenkins-1.418", path));
		}
	}
}