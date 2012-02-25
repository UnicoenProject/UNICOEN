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
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Paraiba.Core;
using Unicoen.CodeGenerators;
using Unicoen.Languages.Tests;
using Unicoen.ProgramGenerators;
using Unicoen.Tests;

namespace Unicoen.Languages.CSharp.Tests {
	public partial class CSharpFixture : Fixture {
		private const string CscPath =
				@"C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe";

		private static readonly string[] IldasmPaths = new[] {
				@"C:\Program Files (x86)\Microsoft SDKs\Windows\v7.0A\Bin\ildasm.exe"
				,
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
		public override UnifiedProgramGenerator ProgramGenerator {
			get { return CSharpFactory.ProgramGenerator; }
		}

		/// <summary>
		///   対応する言語のコード生成器を取得します．
		/// </summary>
		public override UnifiedCodeGenerator CodeGenerator {
			get { return CSharpFactory.CodeGenerator; }
		}

		private static string DecorateToCompile(string statement) {
			return "class A { public void M1() {" + statement + "} }";
		}

		/// <summary>
		///   セマンティクスの変化がないか比較するためにソースコードをデフォルトの設定でコンパイルします．
		/// </summary>
		/// <param name="workPath"> コンパイル対象のソースコードが格納されているディレクトリのパス </param>
		/// <param name="srcPath"> コンパイル対象のソースコードのファイル名 </param>
		public override void Compile(string workPath, string srcPath) {
			var exeFilePath = Path.Combine(
					workPath,
					Path.ChangeExtension(srcPath, "dll"));
			var args = new[] {
					"/optimize+",
					"/t:library",
					"\"/out:" + exeFilePath + "\"",
					"\"" + Path.Combine(workPath, srcPath) + "\""
			};
			var arguments = string.Join(" ", args);
			CompileWithArguments(workPath, CscPath, arguments);
		}

		/// <summary>
		///   コンパイル済みのコードのバイト列を取得します．
		/// </summary>
		/// <param name="path"> コンパイル済みのコードのパス </param>
		/// <returns> コンパイル済みのコードのバイト列 </returns>
		public override object GetCompiledByteCode(string path) {
			var ildasmPath = IldasmPaths.First(File.Exists);
			var args = new[] { "/text", path };
			var info = new ProcessStartInfo {
					FileName = ildasmPath,
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
					str = str.Replace("\r\n", "\n").Split('\n')
							.Select(l => l.Trim())
							.Where(l => !l.StartsWith("//"))
							.Where(l => !l.StartsWith(".assembly"))
							.Where(l => !l.StartsWith(".module"))
							.JoinString("\n");
					return str;
				}
			} catch (Win32Exception e) {
				throw new InvalidOperationException(
						"Failed to launch 'ildasmPath': " + ildasmPath, e);
			}
		}

		public IEnumerable<TestCaseData> SetUpKurogane() {
			Action<string, string> compileAction = (s1, s2) => { };
			return SetUpTestCaseData(
					"Kurogane",
					path =>
					DownloadAndUnzip(
							"http://kurogane.codeplex.com/SourceControl/list/changesets",
							path),
					compileAction);
		} 

		public IEnumerable<TestCaseData> SetUpUnicoen() {
			Action<string, string> compileAction = (s1, s2) => { };
			//yield return new TestCaseData(Path.Combine(FixtureUtil.RootPath, "Unicoen.Apps"), compileAction);
			yield return
					new TestCaseData(
							Path.Combine(FixtureUtil.RootPath, "Unicoen.Core"),
							compileAction);
//			yield return
//					new TestCaseData(
//							Path.Combine(
//									FixtureUtil.RootPath, "Unicoen.Core.Tests"),
//							compileAction);
//			yield return
//					new TestCaseData(
//							Path.Combine(
//									FixtureUtil.RootPath, "Unicoen.Languages"),
//							compileAction);
//			yield return
//					new TestCaseData(
//							Path.Combine(FixtureUtil.RootPath, "Unicoen.Utils"),
//							compileAction);
//			yield return
//					new TestCaseData(
//							Path.Combine(
//									FixtureUtil.RootPath, "Unicoen.WebApps"),
//							compileAction);
		}
	}
}