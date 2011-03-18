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
	/// Java向けに再生成したソースコードが変化していないかテストします。
	/// コード→モデル→コードと変換することで再生成します。
	/// コードは、コンパイルしたバイナリファイル同士、もしくは、
	/// コードから得られるモデルで比較しています。
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

		private static IEnumerable<TestCaseData> TestCases {
			get {
				return Directory.EnumerateFiles(Fixture.GetInputPath("CSharp"))
					.Select(path => new TestCaseData(path));
			}
		}

		/// <summary>
		/// CompareThroughILCodeが正常に動作するかテストします。
		/// 全く同じコードをコンパイルしたバイナリファイルの逆コンパイルした結果で比較します。
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
		/// CompareThroughModelが正常に動作するかテストします。
		/// 全く同じコードから生成したモデル同士で比較します。
		/// </summary>
		/// <param name="orgPath">再生成するソースコードのパス</param>
		[Test, TestCase(@"..\..\fixture\CSharp\input\Fibonacci.cs")]
		public void CompareThroughModelForSameCode(string orgPath) {
			var orgCode = File.ReadAllText(orgPath);
			var expected = CSharpModelFactory.CreateModel(orgCode);
			var actual = CSharpModelFactory.CreateModel(orgCode);
			Assert.That(actual, Is.EqualTo(expected)
				.Using(StructuralEqualityComparer.Instance));
		}

		/// <summary>
		/// コンパイル結果を通して再生成したコードが変化しないかテストします。
		/// コードはコンパイルしたバイナリファイルを逆コンパイルした結果で比較します。
		/// </summary>
		/// <param name="orgPath">再生成するソースコードのパス</param>
		[Ignore, Test, TestCaseSource("TestCases")]
		public void CompareThroughILCode(string orgPath) {
			var workPath = Fixture.CleanTemporalPath();
			var fileName = Path.GetFileName(orgPath);
			var srcPath = Fixture.GetTemporalPath(fileName);
			File.Copy(orgPath, srcPath);
			var expected = GetILCode(workPath, fileName);
			var orgCode = File.ReadAllText(orgPath);
			var model = CSharpModelFactory.CreateModel(orgCode);
			var code = CSharpCodeGenerator.Generate(model);
			File.WriteAllText(srcPath, code);
			var actual = GetILCode(workPath, fileName);
			Assert.That(actual, Is.EqualTo(expected));
		}

		/// <summary>
		/// モデルを通した再生成したコードが変化しないかテストします。
		/// コードから生成したモデルで比較します。
		/// </summary>
		/// <param name="orgPath">再生成するソースコードのパス</param>
		[Ignore, Test, TestCaseSource("TestCases")]
		public void CompareThroughModel(string orgPath) {
			var orgCode = File.ReadAllText(orgPath);
			var expected = CSharpModelFactory.CreateModel(orgCode);
			var newCode = CSharpCodeGenerator.Generate(expected);
			var actual = CSharpModelFactory.CreateModel(newCode);
			Assert.That(actual, Is.EqualTo(expected)
				.Using(StructuralEqualityComparer.Instance));
		}
	}
}