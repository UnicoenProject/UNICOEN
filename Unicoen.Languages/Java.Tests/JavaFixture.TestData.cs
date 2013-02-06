#region License

// Copyright (C) 2011-2012 The Unicoen Project
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
using Unicoen.TestUtils;

namespace Unicoen.Languages.Java.Tests {
	/// <summary>
	///   テストに必要なデータを提供します．
	/// </summary>
	public partial class JavaFixture {
		/// <summary>
		///   テスト時に入力されるA.xxxファイルのメソッド宣言の中身です。 Java言語であれば， <c>class A { public void M1() { ... } }</c> の...部分に このプロパティで指定されたコード断片を埋め込んでA.javaファイルが生成されます。
		/// </summary>
		public override IEnumerable<TestCaseData> TestCodes {
			get {
				var statements = new[] {
						"double MAX_VALUE = 0x1.fffffffffffffP+1023; // 1.7976931348623157e+308"
						,
						"double MIN_NORMAL = 0x1.0p-1022; // 2.2250738585072014E-308"
						,
						"double MIN_VALUE = 0x0.0000000000001P-1022; // 4.9e-324"
						, // 4.94065645841247E-324
						"M1();",
						"new A();",
						"int[] a[][] = new int[1][1][1]; System.out.println(a);"
						,
						"int[] a[] = new int[10][10], b[][] = new int[10][10][10];"
						,
						"int i; for (i = 0; i < 0; i++) System.out.println(1);",
						"Integer i; if ((i = 0).toString() != null) { }",
						"int mask = 0x80000000;",
						"System.out.println(0x1E.ep0); System.out.println(0x1E.eP+1);"
						,
				}.Select(s => new TestCaseData(DecorateToCompile(s)));

				var codes = new[] {
						"class A { void execute(String ... str) { } }",
						"class A { public @interface M1 { String value(); } }",
						"class A { void m() { for (final int a = 0, b = 1; ; ) System.out.println(a + b); } }"
						,
						"import java.util.List;",
						"class A { int a = 0; }",
				}.Select(s => new TestCaseData(s));

				return statements.Concat(codes);
			}
		}

		/// <summary>
		///   テスト時に入力するファイルパスの集合です．
		/// </summary>
		public override IEnumerable<TestCaseData> TestFilePaths {
			get {
				// 必要に応じて以下の要素をコメントアウト
				return new[] {
						"Fibonacci",
				}
						.Select(
								s =>
								FixtureUtil.GetInputPath(
										LanguageName, s + Extension))
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
						new {
								DirName = "UNICOEN", Command = cmd,
								Arguments = args
						},
				}
						.Select(
								o => {
									Action<string> action =
											workPath =>
											CompileWithArguments(
													workPath, o.Command, o.Arguments);
									return
											new TestCaseData(
													FixtureUtil.GetInputPath(
															LanguageName,
															o.DirName), new[] { "." }, action);
								})
						.Concat(SetUpJUnit())
						//.Concat(SetUpCraftBukkit())
						.Concat(SetUpBukkit())
						.Concat(SetUpGameOfLife())
						.Concat(SetUpJedis())
						.Concat(SetUpZoie())
						;
			}
		}

		public override IEnumerable<TestCaseData> TestHeavyProjectInfos {
			get {
				return SetUpJdk()
						.Concat(SetUpJenkins())
						;
			}
		}

		private string SetUpMaven3() {
			var path = FixtureUtil.GetDownloadPath(LanguageName, "Maven3");
			var exePath = Path.Combine(
					path, "apache-maven-3.0.4", "bin", "mvn.bat");
			if (Directory.Exists(path)
			    &&
			    Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories)
			    		.Any()) {
				return exePath;
			}
			Directory.CreateDirectory(path);
			DownloadAndUntgz(
					"http://ftp.kddilabs.jp/infosystems/apache/maven/maven-3/3.0.4/binaries/apache-maven-3.0.4-bin.tar.gz",
					path);
			return exePath;
		}

		private IEnumerable<TestCaseData> SetUpJUnit() {
			const string srcDirName = "src";
			return SetUpTestCaseData(
					"junit4.8.2",
					deployPath => {
						DownloadAndUnzip(
								"https://github.com/downloads/KentBeck/junit/junit4.8.2.zip",
								deployPath);
						var srcDirPath = Path.Combine(deployPath, srcDirName);
						var arcPath = Path.Combine(
								deployPath, "junit4.8.2", "junit-4.8.2-src.jar");
						Extractor.Unzip(arcPath, srcDirPath);
						return true;
					},
					workDirPath => {
						var depPath = Path.Combine(workDirPath, "junit4.8.2", "temp.hamcrest.source");
						workDirPath = Path.Combine(workDirPath, srcDirName);
						foreach (var srcPath in GetAllSourceFilePaths(workDirPath)) {
							var args = new[] {
									"-cp",
									".;\"" + depPath + "\"",
									"\"" + srcPath + "\"",
							};
							CompileWithArguments(workDirPath, CompileCommand, string.Join(" ", args));
						}
					},
					"src", Path.Combine("junit4.8.2", "temp.hamcrest.source")
					);
		}

		private IEnumerable<TestCaseData> SetUpJdk() {
			return SetUpTestCaseData(
					"jdk",
					deployPath => {
						var jdkPath = Directory.GetDirectories(
								@"C:\Program Files\Java\")
								.LastOrDefault(
										p =>
										Path.GetFileName(p).StartsWith("jdk1.6"));
						if (jdkPath == null) {
							return false;
						}
						var arcPath = Path.Combine(jdkPath, "src.zip");
						Extractor.Unzip(arcPath, deployPath);
						return true;
					});
		}

		private IEnumerable<TestCaseData> SetUpCraftBukkit() {
			return SetUpTestCaseData(
					"CraftBukkit",
					deployPath =>
					DownloadAndUnzip(
							"https://github.com/Bukkit/CraftBukkit/zipball/master",
							deployPath),
					CompileMaven);
		}

		private IEnumerable<TestCaseData> SetUpBukkit() {
			return SetUpTestCaseData(
					"Bukkit-Bukkit-ddb9039",
					deployPath =>
					DownloadAndUnzip(
							"https://github.com/Bukkit/Bukkit/zipball/1.3.2-R1.0",
							deployPath),
					CompileMaven);
		}

		private IEnumerable<TestCaseData> SetUpJenkins() {
			return SetUpTestCaseData(
					"jenkins-1.418",
					deployPath =>
					DownloadAndUnzip(
							"https://github.com/jenkinsci/jenkins/zipball/jenkins-1.418",
							deployPath));
		}

		private IEnumerable<TestCaseData> SetUpGameOfLife() {
			return SetUpTestCaseData(
					"wakaleo-game-of-life-e9af441",
					deployPath =>
					DownloadAndUnzip(
							"https://github.com/wakaleo/game-of-life/zipball/release-candidate-44",
							deployPath));
		}

		private IEnumerable<TestCaseData> SetUpJedis() {
			return SetUpTestCaseData(
					"xetorthio-jedis-2741483",
					deployPath =>
					DownloadAndUnzip(
							"https://github.com/xetorthio/jedis/zipball/jedis-2.0.0",
							deployPath));
		}

		private IEnumerable<TestCaseData> SetUpZoie() {
			return SetUpTestCaseData(
					"javasoze-zoie-ef7b454",
					deployPath =>
					DownloadAndUnzip(
							"https://github.com/javasoze/zoie/zipball/release-3.0.0",
							deployPath),
					"");
		}
	}
}