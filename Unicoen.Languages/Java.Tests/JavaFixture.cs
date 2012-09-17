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
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Paraiba.IO;
using Unicoen.CodeGenerators;
using Unicoen.Languages.Tests;
using Unicoen.ProgramGenerators;

namespace Unicoen.Languages.Java.Tests {
	/// <summary>
	///   テストに必要なデータを提供します．
	/// </summary>
	public partial class JavaFixture : Fixture {
		private const string MavenArg = "compile";
		private const string CompileCommand = "javac";
		private const string DisassembleCommand = "javap";
		private readonly string _mavenCommand;

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
		public override UnifiedProgramGenerator ProgramGenerator {
			get { return JavaFactory.ProgramGenerator; }
		}

		/// <summary>
		///   対応する言語のコード生成器を取得します．
		/// </summary>
		public override UnifiedCodeGenerator CodeGenerator {
			get { return JavaFactory.CodeGenerator; }
		}

		private static string DecorateToCompile(string statement) {
			return "class A { public void M1() {\n" + statement + "\n} }";
		}

		/// <summary>
		///   指定したファイルのソースコードをデフォルトの設定でコンパイルします．
		/// </summary>
		/// <param name="workPath"> コンパイル時の作業ディレクトリのパス </param>
		/// <param name="srcPath"> コンパイル対象のソースコードのパス </param>
		public override void Compile(string workPath, string srcPath) {
			var args = new[] {
					"\"" + srcPath + "\""
			};
			var arguments = string.Join(" ", args);
			CompileWithArguments(workPath, CompileCommand, arguments);
		}

		/// <summary>
		///   コンパイル済みのコードのバイト列を取得します．
		/// </summary>
		/// <param name="rootPath">コンパイル済みコードのルートディレクトリ</param>
		/// <param name="path"> コンパイル済みコードのパス </param>
		/// <returns> コンパイル済みのコードのバイト列 </returns>
		public override object GetCompiledByteCode(string rootPath, string path) {
			var relativePath = XPath.GetRelativePath(path, rootPath);
			relativePath =
					relativePath.Substring(0, relativePath.Length - 6).Replace('\\', '.').
							Replace('/', '.');
			var args = new[] { "-c", "-private", relativePath };
			var info = new ProcessStartInfo {
					FileName = DisassembleCommand,
					Arguments = string.Join(" ", args),
					WorkingDirectory = rootPath,
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
					return str;
				}
			} catch (Win32Exception e) {
				throw new InvalidOperationException(
						"Failed to launch 'ildasmPath': " + DisassembleCommand,
						e);
			}
		}

		private void CompileMaven(string workPath) {
			var pomPath =
					Directory.EnumerateFiles(
							workPath, "pom.xml", SearchOption.AllDirectories).
							First();
			workPath = Path.GetDirectoryName(pomPath);
			CompileWithArguments(workPath, _mavenCommand, MavenArg);
		}
	}
}