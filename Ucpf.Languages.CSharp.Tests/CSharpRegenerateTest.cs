using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Paraiba.Core;
using Ucpf.Core.Tests;

namespace Ucpf.Languages.CSharp.Tests {
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

				using (var p = Process.Start(info)) {
					p.WaitForExit();
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

		[Test, TestCase(@"..\..\fixture\CSharp\input\Block1.cs")]
		public void CompareThroughILCodeForSameCode(string orgPath) {
			var workPath = Fixture.CleanTemporalPath();
			var fileName = Path.GetFileName(orgPath);
			var srcPath = Fixture.GetTemporalPath(fileName);
			File.Copy(orgPath, srcPath);
			var expected = GetILCode(workPath, fileName);
			var actual = GetILCode(workPath, fileName);
			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test, TestCaseSource("TestCases")]
		public void CompareThroughILCode(string orgPath) {
			var workPath = Fixture.CleanTemporalPath();
			var fileName = Path.GetFileName(orgPath);
			var srcPath = Fixture.GetTemporalPath(fileName);
			File.Copy(orgPath, srcPath);
			var expected = GetILCode(workPath, fileName);
			var model = CSharpModelFactory.CreateModel(orgPath);
			var code = CSharpCodeGenerator.Generate(model);
			File.WriteAllText(srcPath, code);
			var actual = GetILCode(workPath, fileName);
			Assert.That(actual, Is.EqualTo(expected));
		}
	}
}