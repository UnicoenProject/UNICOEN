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
using Paraiba.Text;
using Unicoen.Core.Tests;

namespace Unicoen.Languages.CSharp.Tests {
	/// <summary>
	///   C#向けに再生成したソースコードが変化していないかテストします。
	///   元コード1→モデル1→コード2→... のように再生成します。
	///   コードは、コンパイルしたアセンブリファイルの逆コンパイル結果同士、
	///   もしくは、コードから得られるモデル同士で比較しています。
	/// </summary>
	[Ignore, TestFixture]
	public class CSharpRegenerateTest {
		private const string CscPath =
				@"C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe";

		private static readonly string[] IldasmPathes = new[] {
				@"C:\Program Files (x86)\Microsoft SDKs\Windows\v7.0A\Bin\ildasm.exe",
				@"C:\Program Files\Microsoft SDKs\Windows\v7.0A\Bin\ildasm.exe",
		};

		private static string GetILCode(string workPath, string fileName) {
			var exeFilePath = Path.Combine(
					workPath,
					Path.ChangeExtension(fileName, "dll"));
			{
				var args = new[] {
						"/optimize+",
						"/t:library",
						"\"/out:" + exeFilePath + "\"",
						"\"" + Path.Combine(workPath, fileName) + "\""
				};
				var info = new ProcessStartInfo {
						FileName = CscPath,
						Arguments = args.JoinString(" "),
						CreateNoWindow = true,
						UseShellExecute = false,
						WorkingDirectory = workPath,
				};

				try {
					using (var p = Process.Start(info)) {
						p.WaitForExit();
						if (p.ExitCode != 0) {
							throw new InvalidOperationException("Failed to compile the code.");
						}
					}
				} catch (Win32Exception e) {
					throw new InvalidOperationException(
							"Failed to launch 'csc': " + CscPath, e);
				}
			}

			{
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
		}

		public static IEnumerable<TestCaseData> TestStatements {
			get { return CSharpFixture.TestStatements; }
		}

		public static IEnumerable<TestCaseData> TestCodes {
			get { return CSharpFixture.TestCodes; }
		}

		public static IEnumerable<TestCaseData> TestFilePathes {
			get { return CSharpFixture.TestFilePathes; }
		}

		/// <summary>
		///   再生成を行わずCompareThroughILCodeが正常に動作するかテストします。
		///   全く同じコードをコンパイルしたアセンブリファイルの逆コンパイル結果で比較します。
		/// </summary>
		/// <param name = "orgPath">再生成するソースコードのパス</param>
		[Test, TestCase(@"..\..\fixture\CSharp\input\Fibonacci.cs")]
		public void TestCompareThroughILCodeForSameCode(string orgPath) {
			var workPath = Fixture.CleanTemporalPath();
			var fileName = Path.GetFileName(orgPath);
			var srcPath = Fixture.GetTemporalPath(fileName);
			File.Copy(orgPath, srcPath);
			var expected = GetILCode(workPath, fileName);
			var actual = GetILCode(workPath, fileName);
			Assert.That(actual, Is.EqualTo(expected));
		}

		/// <summary>
		///   再生成を行わずCompareThroughModelが正常に動作するかテストします。
		///   全く同じコードから生成したモデル同士で比較します。
		/// </summary>
		/// <param name = "orgPath">再生成するソースコードのパス</param>
		[Test, TestCase(@"..\..\fixture\CSharp\input\Fibonacci.cs")]
		public void TestCompareThroughModelForSameCode(string orgPath) {
			var orgCode = File.ReadAllText(orgPath, XEncoding.SJIS);
			var expected = CSharpModelFactory.CreateModel(orgCode);
			var actual = CSharpModelFactory.CreateModel(orgCode);
			Assert.That(
					actual, Is.EqualTo(expected)
					        		.Using(StructuralEqualityComparerForDebug.Instance));
		}

		/// <summary>
		///   コンパイル結果を通して再生成したコードが変化しないかテストします。
		///   元コード1→モデル1→コード2と再生成します。
		///   コンパイルしたアセンブリファイルの逆コンパイル結果を通して、
		///   元コード1とコード2を比較します。
		/// </summary>
		/// <param name = "orgCode1">再生成するソースコード</param>
		/// <param name = "fileName">再生成するソースコードのファイル名</param>
		public void VerifyCompareThroughILCode(string orgCode1, string fileName) {
			var workPath = Fixture.CleanTemporalPath();
			var srcPath = Fixture.GetTemporalPath(fileName);
			File.WriteAllText(srcPath, orgCode1, XEncoding.SJIS);
			var orgILCode1 = GetILCode(workPath, fileName);
			var model1 = CSharpModelFactory.CreateModel(orgCode1);
			var code2 = CSharpCodeGenerator.Generate(model1);
			File.WriteAllText(srcPath, code2, XEncoding.SJIS);
			var iLCode2 = GetILCode(workPath, fileName);
			Assert.That(iLCode2, Is.EqualTo(orgILCode1));
		}

		/// <summary>
		///   モデルを通した再生成したコードが変化しないかテストします。
		///   元コード1→モデル1→コード2→モデル2→コード3→モデル3と再生成します。
		///   モデル2とモデル3を比較します。
		/// </summary>
		/// <param name = "orgCode">再生成するソースコードの内容</param>
		public void VerifyCompareThroughModel(string orgCode) {
			var model1 = CSharpModelFactory.CreateModel(orgCode);
			var code2 = CSharpCodeGenerator.Generate(model1);
			var model2 = CSharpModelFactory.CreateModel(code2);
			var code3 = CSharpCodeGenerator.Generate(model2);
			var model3 = CSharpModelFactory.CreateModel(code3);
			Assert.That(
					model3, Is.EqualTo(model2)
					        		.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Test, TestCaseSource("TestStatements")]
		public void CompareThroughILCodeUsingStatement(string statement) {
			VerifyCompareThroughILCode(statement, "A.cs");
		}

		[Test, TestCaseSource("TestStatements")]
		public void CompareThroughModelUsingStatement(string statement) {
			VerifyCompareThroughModel(statement);
		}

		[Test, TestCaseSource("TestCodes")]
		public void CompareThroughILCodeUsingCode(string code) {
			VerifyCompareThroughILCode(code, "A.cs");
		}

		[Test, TestCaseSource("TestCodes")]
		public void CompareThroughModelUsingCode(string code) {
			VerifyCompareThroughModel(code);
		}

		[Test, TestCaseSource("TestFilePathes")]
		public void CompareThroughILCodeUsingFile(string orgPath) {
			var fileName = Path.GetFileName(orgPath);
			VerifyCompareThroughILCode(
					File.ReadAllText(orgPath, XEncoding.SJIS), fileName);
		}

		[Test, TestCaseSource("TestFilePathes")]
		public void CompareThroughModelUsingFile(string orgPath) {
			VerifyCompareThroughModel(File.ReadAllText(orgPath, XEncoding.SJIS));
		}
	}
}