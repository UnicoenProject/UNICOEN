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
using Paraiba.Core;
using Unicoen.Core.Processor;
using Unicoen.Core.Tests;
using Unicoen.Languages.Tests;

namespace Unicoen.Languages.CSharp.Tests {
	public class CSharpFixture : Fixture {
		private const string CscPath =
				@"C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe";

		private static readonly string[] IldasmPathes = new[] {
				@"C:\Program Files (x86)\Microsoft SDKs\Windows\v7.0A\Bin\ildasm.exe",
				@"C:\Program Files\Microsoft SDKs\Windows\v7.0A\Bin\ildasm.exe",
		};

		/// <summary>
		///   対応する言語のソースコードの拡張子を取得します．
		/// </summary>
		public override string Extension {
			get { return ".cs"; }
		}

		/// <summary>
		///   対応する言語のソースコードの拡張子を取得します．
		/// </summary>
		public override string CompiledExtension {
			get { return ".dll"; }
		}

		/// <summary>
		///   対応する言語のモデル生成器を取得します．
		/// </summary>
		public override ModelFactory ModelFactory {
			get { return CSharpFactory.ModelFactory; }
		}

		/// <summary>
		///   対応する言語のコード生成器を取得します．
		/// </summary>
		public override CodeFactory CodeFactory {
			get { return CSharpFactory.CodeFactory; }
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
						"Student",
						"Block1",
						"Block2",
						"Block3",
				}
						.Select(
								s => new TestCaseData(FixtureUtil.GetInputPath("CSharp", s + Extension)));
				//return Directory.EnumerateFiles(GetInputPath("CSharp"))
				//        .Select(path => new TestCaseData(path));
			}
		}

		/// <summary>
		///   テスト時に入力するプロジェクトファイルのパスとコンパイル処理の組み合わせの集合です．
		/// </summary>
		public override IEnumerable<TestCaseData> TestProjectInfos {
			get { yield break; }
		}

		public override IEnumerable<TestCaseData> TestHeavyProjectInfos {
			get { yield break; }
		}

		/// <summary>
		///   セマンティクスの変化がないか比較するためにソースコードをデフォルトの設定でコンパイルします．
		/// </summary>
		/// <param name = "dirPath">コンパイル対象のソースコードが格納されているディレクトリのパス</param>
		/// <param name = "fileName">コンパイル対象のソースコードのファイル名</param>
		public override void Compile(string dirPath, string fileName) {
			var exeFilePath = Path.Combine(
					dirPath,
					Path.ChangeExtension(fileName, "dll"));
			var args = new[] {
					"/optimize+",
					"/t:library",
					"\"/out:" + exeFilePath + "\"",
					"\"" + Path.Combine(dirPath, fileName) + "\""
			};
			var arguments = args.JoinString(" ");
			CompileWithArguments(dirPath, CscPath, arguments);
		}

		/// <summary>
		///   コンパイル済みのコードのバイト列を取得します．
		/// </summary>
		/// <param name = "path">コンパイル済みのコードのパス</param>
		/// <returns>コンパイル済みのコードのバイト列</returns>
		protected override byte[] GetCompiledByteCode(string path) {
			var ildasmPath = IldasmPathes.First(File.Exists);
			var args = new[] { "/text", path };
			var info = new ProcessStartInfo {
					FileName = ildasmPath,
					Arguments = args.JoinString(" "),
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
					str = str.Replace("\r\n", "\n").Split('\n')
							.Select(l => l.Trim())
							.Where(l => !l.StartsWith("//"))
							.Where(l => !l.StartsWith(".assembly"))
							.Where(l => !l.StartsWith(".module"))
							.JoinString("\n");
					return Encoding.Unicode.GetBytes(str);
				}
			} catch (Win32Exception e) {
				throw new InvalidOperationException(
						"Failed to launch 'ildasmPath': " + ildasmPath, e);
			}
		}
	}
}