using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using NUnit.Framework;
using Paraiba.Core;
using Ucpf.Core.Tests;

namespace Ucpf.Languages.CSharp.Tests {
	[TestFixture]
	public class CSharpRegenerateTest {
		private const string ToolPath =
			@"C:\Program Files (x86)\Microsoft SDKs\Windows\v7.0A\Bin";

		private const string CscName = "csc.exe";

		private const string IldasmName = "ildasm.exe";

		public string GetILCode(string workPath, string fileName) {
			{
				var args = new[] { "/optimize+", fileName };
				var info = new ProcessStartInfo {
					FileName = Path.Combine(ToolPath, CscName),
					Arguments = args.JoinString(" "),
					CreateNoWindow = true,
					UseShellExecute = false,
					WorkingDirectory = workPath,
				};
				Process.Start(info).Dispose();
			}

			{
				var args = new[] { "/text", Path.ChangeExtension(fileName, "exe") };
				var info = new ProcessStartInfo {
					FileName = Path.Combine(ToolPath, IldasmName),
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

		[Test]
		public void Test(string fileName) {
			var workPath = Fixture.CleanTemporalPath();
			var orgPath = Fixture.GetInputPath("CSharp", fileName);
			var srcPath = Fixture.GetTemporalPath(fileName);
			File.Copy(orgPath, srcPath);
			var expected = GetILCode(workPath, srcPath);
			var model = CSharpModelFactory.CreateModel(orgPath);
			var code = CSharpCodeGenerator.Generate(model);
			File.WriteAllText(srcPath, code);
			var actual = GetILCode(workPath, srcPath);
			Assert.That(actual, Is.EqualTo(expected));
		}
	}
}
