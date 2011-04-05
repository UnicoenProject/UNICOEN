using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Paraiba.Core;
using Ucpf.Core.Model;
using Ucpf.Core.Tests;

namespace Ucpf.Languages.CSharp.Tests {
	/// <summary>
	/// C#向けに再生成したソースコードが変化していないかテストします。
	/// 元コード1→モデル1→コード2→... のように再生成します。
	/// コードは、コンパイルしたアセンブリファイルの逆コンパイル結果同士、
	/// もしくは、コードから得られるモデル同士で比較しています。
	/// </summary>
	[TestFixture]
	public class CSharpRegenerateTest {
		private const string CscPath =
			@"C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe";

		private const string IldasmPath =
			@"C:\Program Files (x86)\Microsoft SDKs\Windows\v7.0A\Bin\ildasm.exe";

		private static string GetILCode(string workPath, string fileName) {
			var exeFilePath = Path.Combine(workPath,
				Path.ChangeExtension(fileName, "exe"));
			{
				var args = new[] {
					"/optimize+",
					"/t:library",
					"\"/out:" + exeFilePath + "\"",
					"\"" + Path.Combine(workPath, fileName) + "\""
				};
				var argg = args.JoinString(" ");
				var info = new ProcessStartInfo {
					FileName = CscPath,
					Arguments = argg,
					CreateNoWindow = true,
					UseShellExecute = false,
					WorkingDirectory = workPath,
				};

				try {
					using (var p = Process.Start(info)) {
						p.WaitForExit();
					}
				} catch (Win32Exception e) {
					throw new InvalidOperationException("Failed to launch 'ildasm': " + IldasmPath , e);
				}
			}

			{
				var args = new[] { "/text", exeFilePath };
				var info = new ProcessStartInfo {
					FileName = IldasmPath,
					Arguments = args.JoinString(" "),
					CreateNoWindow = true,
					RedirectStandardInput = true,
					RedirectStandardOutput = true,
					UseShellExecute = false,
					WorkingDirectory = workPath,
				};

				using (var p = Process.Start(info)) {
					var str = p.StandardOutput.ReadToEnd();
					return str.Replace("\r\n", "\n").Split('\n')
						.Select(l => l.Trim())
						.Where(l => !l.StartsWith("//"))
						.Where(l => !l.StartsWith(".assembly"))
						.Where(l => !l.StartsWith(".module"))
						.JoinString("\n");
				}
			}
		}

		public static IEnumerable<TestCaseData> TestCases {
			get { return Fixture.CSharpTestCases; }
		}

		/// <summary>
		/// 再生成を行わずCompareThroughILCodeが正常に動作するかテストします。
		/// 全く同じコードをコンパイルしたアセンブリファイルの逆コンパイル結果で比較します。
		/// </summary>
		/// <param name="orgPath">再生成するソースコードのパス</param>
		[Test, TestCase(@"..\..\fixture\CSharp\input\Fibonacci.cs")]
		public void CompareThroughILCodeForSameCode(string orgPath) {
			var workPath = Fixture.CleanTemporalPath();
			var fileName = Path.GetFileName(orgPath);
			var srcPath = Fixture.GetTemporalPath(fileName);
			File.Copy(orgPath, srcPath);
			var expected = GetILCode(workPath, fileName);
			var actual = GetILCode(workPath, fileName);
			Assert.That(actual, Is.EqualTo(expected));
		}

		/// <summary>
		/// 再生成を行わずCompareThroughModelが正常に動作するかテストします。
		/// 全く同じコードから生成したモデル同士で比較します。
		/// </summary>
		/// <param name="orgPath">再生成するソースコードのパス</param>
		[Test, TestCase(@"..\..\fixture\CSharp\input\Fibonacci.cs")]
		public void CompareThroughModelForSameCode(string orgPath) {
			var orgCode = File.ReadAllText(orgPath);
			var expected = CSharpModelFactory.CreateModel(orgCode);
			var actual = CSharpModelFactory.CreateModel(orgCode);
			Assert.That(actual, Is.EqualTo(expected)
				.Using(StructuralEqualityComparerForDebug.Instance));
		}

		/// <summary>
		/// コンパイル結果を通して再生成したコードが変化しないかテストします。
		/// 元コード1→モデル1→コード2と再生成します。
		/// コンパイルしたアセンブリファイルの逆コンパイル結果を通して、
		/// 元コード1とコード2を比較します。
		/// </summary>
		/// <param name="orgPath">再生成するソースコードのパス</param>
		[Test, TestCaseSource("TestCases")]
		public void CompareThroughILCode(string orgPath) {
			var workPath = Fixture.CleanTemporalPath();
			var fileName = Path.GetFileName(orgPath);
			var srcPath = Fixture.GetTemporalPath(fileName);
			File.Copy(orgPath, srcPath);
			var orgILCode1 = GetILCode(workPath, fileName);
			var orgCode1 = File.ReadAllText(orgPath);
			var model1 = CSharpModelFactory.CreateModel(orgCode1);
			var code2 = CSharpCodeGenerator.Generate(model1);
			File.WriteAllText(srcPath, code2);
			var iLCode2 = GetILCode(workPath, fileName);
			Assert.That(iLCode2, Is.EqualTo(orgILCode1));
		}

		/// <summary>
		/// モデルを通した再生成したコードが変化しないかテストします。
		/// 元コード1→モデル1→コード2→モデル2→コード3→モデル3と再生成します。
		/// モデル2とモデル3を比較します。
		/// </summary>
		/// <param name="orgPath">再生成するソースコードのパス</param>
		[Test, TestCaseSource("TestCases")]
		public void CompareThroughModel(string orgPath) {
			var orgCode = File.ReadAllText(orgPath);
			var model1 = CSharpModelFactory.CreateModel(orgCode);
			var code2 = CSharpCodeGenerator.Generate(model1);
			var model2 = CSharpModelFactory.CreateModel(code2);
			var code3 = CSharpCodeGenerator.Generate(model2);
			var model3 = CSharpModelFactory.CreateModel(code3);
			Assert.That(model3, Is.EqualTo(model1)
				.Using(StructuralEqualityComparerForDebug.Instance));
		}
	}
}