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
using NUnit.Framework;
using Paraiba.Core;
using Unicoen.Core.CodeFactories;
using Unicoen.Core.ModelFactories;
using Unicoen.Core.Tests;
using Unicoen.Languages.Python2.CodeFactories;
using Unicoen.Languages.Python2.ModelFactories;

namespace Unicoen.Languages.Python2.Tests {
	/// <summary>
	///   再生成したソースコードが変化していないかテストします。
	///   元コード1→モデル1→コード2→... のように再生成します。
	///   コードは、コンパイルしたアセンブリファイルの逆コンパイル結果同士、
	///   もしくは、コードから得られるモデル同士で比較しています。
	/// </summary>
	[Ignore, TestFixture]
	public class Python2RegenerateTest : RegenerateTest {
		private const string CscPath =
				@"C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe";

		private static readonly string[] IldasmPathes = new[] {
				@"C:\Program Files (x86)\Microsoft SDKs\Windows\v7.0A\Bin\ildasm.exe",
				@"C:\Program Files\Microsoft SDKs\Windows\v7.0A\Bin\ildasm.exe",
		};

		private readonly Python2Fixture _fixture = new Python2Fixture();

		public override LanguageFixture Fixture {
			get { return _fixture; }
		}

		private readonly Python2CodeFactory _codeFactory = new Python2CodeFactory();

		public override CodeFactory CodeFactory {
			get { return _codeFactory; }
		}

		private readonly Python2ModelFactory _modelFactory = new Python2ModelFactory();

		public override ModelFactory ModelFactory {
			get { return _modelFactory; }
		}

		protected override void Compile(string workPath, string fileName) {
			throw new NotImplementedException();
			var exeFilePath = Path.Combine(
					workPath,
					Path.ChangeExtension(fileName, "dll"));
			var args = new[] {
					"/optimize+",
					"/t:library",
					"\"/out:" + exeFilePath + "\"",
					"\"" + Path.Combine(workPath, fileName) + "\""
			};
			var arguments = args.JoinString(" ");
			CompileWithArguments(workPath, CscPath, arguments);
		}

		protected override IEnumerable<object[]> GetAllCompiledCode(string workPath) {
			throw new NotImplementedException();
			return Directory.EnumerateFiles(
					workPath, "*.dll",
					SearchOption.AllDirectories)
					.Select(path => new object[] { path, GetByteCode(workPath, path) });
		}

		protected override void CompileWithArguments(
				string workPath, string command, string arguments) {
			var info = new ProcessStartInfo {
					FileName = command,
					Arguments = arguments,
					CreateNoWindow = true,
					UseShellExecute = false,
					WorkingDirectory = workPath,
					RedirectStandardError = true,
			};
			try {
				using (var p = Process.Start(info)) {
					var errorMessage = p.StandardError.ReadToEnd();
					p.WaitForExit();
					if (p.ExitCode != 0) {
						throw new InvalidOperationException(
								"Failed to compile the code.\n" + errorMessage);
					}
				}
			} catch (Win32Exception e) {
				throw new InvalidOperationException("Failed to launch compiler.", e);
			}
		}

		private static string GetByteCode(string workPath, string exeFilePath) {
			throw new NotImplementedException();
			var ildasmPath = IldasmPathes.First(File.Exists);
			var args = new[] { "/text", exeFilePath };
			var info = new ProcessStartInfo {
					FileName = ildasmPath,
					Arguments = args.JoinString(" "),
					CreateNoWindow = true,
					RedirectStandardInput = true,
					RedirectStandardOutput = true,
					UseShellExecute = false,
					WorkingDirectory = workPath,
			};

			try {
				using (var p = Process.Start(info)) {
					var str = p.StandardOutput.ReadToEnd();
					p.WaitForExit();
					if (p.ExitCode != 0) {
						throw new InvalidOperationException(
								"Failed to disassemble the exe file.");
					}
					return str.Replace("\r\n", "\n").Split('\n')
							.Select(l => l.Trim())
							.Where(l => !l.StartsWith("//"))
							.Where(l => !l.StartsWith(".assembly"))
							.Where(l => !l.StartsWith(".module"))
							.JoinString("\n");
				}
			} catch (Win32Exception e) {
				throw new InvalidOperationException(
						"Failed to launch 'ildasmPath': " + ildasmPath, e);
			}
		}

		[Test, TestCase(@"..\..\fixture\Python2\input\Fibonacci.py")]
		public override void VerifyCompareThroughCompiledCodeForSameCode(
				string orgPath) {
			base.VerifyCompareThroughCompiledCodeForSameCode(orgPath);
		}

		[Test, TestCase(@"..\..\fixture\Python2\input\Fibonacci.py")]
		public override void VerifyCompareThroughModelForSameCode(string orgPath) {
			base.VerifyCompareThroughModelForSameCode(orgPath);
		}

		[Test, TestCaseSource("TestCodes"), TestCaseSource("TestStatements")]
		public override void CompareThroughByteCodeUsingCode(string code) {
			base.CompareThroughByteCodeUsingCode(code);
		}

		[Test, TestCaseSource("TestCodes"), TestCaseSource("TestStatements")]
		public override void CompareThroughModelUsingCode(string code) {
			base.CompareThroughModelUsingCode(code);
		}

		[Test, TestCaseSource("TestFilePathes")]
		public override void CompareThroughByteCodeUsingFile(string orgPath) {
			base.CompareThroughByteCodeUsingFile(orgPath);
		}

		[Test, TestCaseSource("TestFilePathes")]
		public override void CompareThroughModelUsingFile(string orgPath) {
			base.CompareThroughModelUsingFile(orgPath);
		}

		[Test, TestCaseSource("TestDirectoryPathes")]
		public override void CompareThroughByteCodeUsingDirectory(
				string orgPath, string command, string arguments) {
			base.CompareThroughByteCodeUsingDirectory(orgPath, command, arguments);
		}

		[Test, TestCaseSource("TestDirectoryPathes")]
		public override void CompareThroughModelUsingDirectory(
				string orgPath, string command, string arguments) {
			base.CompareThroughModelUsingDirectory(orgPath, command, arguments);
		}
	}
}