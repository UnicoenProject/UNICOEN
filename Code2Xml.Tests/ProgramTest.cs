using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Paraiba.Core;
using Paraiba.Text;
using Ucpf.Common.AstGenerators;
using Ucpf.Common.Plugins;
using Ucpf.Common.Tests;
using Ucpf.Languages.C;

namespace Code2Xml.Tests {
	[TestFixture]
	public class ProgramTest {
		private static string CLanguageName = "C";

		private static IEnumerable<TestCaseData> TestCases {
			get {
				var langs = new[] {
					new { Name = "C", Opt = "-C" },
					new { Name = "CSharp", Opt = "-C#" },
					new { Name = "Java", Opt = "-Java" },
					new { Name = "JavaScript", Opt = "-JavaScript" },
					new { Name = "Lua", Opt = "-Lua" },
					new { Name = "Python2", Opt = "-Python2" },
					new { Name = "Python3", Opt = "-Python3" },
					new { Name = "Ruby18", Opt = "-Ruby18" },
					new { Name = "Ruby19", Opt = "-Ruby19" },
				};
				return langs
					.SelectMany(
						lang => Directory.EnumerateFiles(Fixture.GetInputPath(lang.Name))
						        	.Select(path => new { lang.Name, lang.Opt, Path = path }))
					.Select(p =>
					        new TestCaseData(p.Path, p.Opt,
					        	PluginManager.AstGenerators.FirstOrDefault(
					        		o => o.GetType().Name == p.Name + "AstGenerator")))
					.Where(t => t.Arguments[2] != null);
			}
		}

		[Test]
		public void コードを生成できる() {
			var names = new[] { "Block1.c", "Block2.c", "Block3.c" };
			var filePaths = names
				.Select(n => Fixture.GetInputPath(CLanguageName, n));
			var outputPath = Fixture.GetOutputDirPath(CLanguageName);

			Program.Main(filePaths.Concat(new[] { "-C", "-d", outputPath }).ToArray());
			Program.Main(filePaths
				.Select(path => Path.Combine(outputPath,
					Path.ChangeExtension(Path.GetFileName(path), ".xml")))
				.Concat(new[] { "-code", "-C", "-d", outputPath }).ToArray());

			foreach (var filePath in filePaths) {
				var newPath = Path.Combine(outputPath, Path.GetFileName(filePath));
				using (var reader = new StreamReader(newPath, XEncoding.SJIS)) {
					var actual = reader.ReadToEnd();
					var ast = CAstGenerator.Instance.GenerateFromFile(filePath);
					var expected = CCodeGenerator.Instance.Generate(ast);
					Assert.That(actual.StartsWith(expected), Is.True);
				}
			}
			Directory.Delete(outputPath, true);
		}

		[Test, TestCaseSource("TestCases")]
		public void パースできる(string filePath, string option, AstGenerator astGen) {
			if (filePath.EndsWith("ruby2ruby_test.rb"))
				filePath = filePath;
			using (var output = new StringWriter()) {
				Console.SetOut(output);

				Program.Main(new[] { filePath, option });

				var actual = output.ToString();
				var expected = astGen.GenerateFromFile(filePath).ToString();
				Assert.That(actual.StartsWith(expected), Is.True);
			}
		}

		[Test]
		public void パース結果をディレクトリに出力できる() {
			var names = new[] { "Block1.c", "Block2.c", "Block3.c" };
			var filePaths = names
				.Select(n => Fixture.GetInputPath(CLanguageName, n));

			Program.Main(filePaths.Concat(new[] { "-C", "-d" }).ToArray());

			foreach (var filePath in filePaths) {
				var newPath = Path.Combine(Path.GetDirectoryName(filePath),
					Path.ChangeExtension(Path.GetFileName(filePath), ".xml"));
				using (var reader = new StreamReader(newPath, XEncoding.SJIS)) {
					var actual = reader.ReadToEnd();
					var expected =
						CAstGenerator.Instance.GenerateFromFile(filePath).ToString();
					Assert.That(actual.StartsWith(expected), Is.True);
				}
				File.Delete(newPath);
			}
		}

		[Test]
		public void パース結果をファイルに出力できる() {
			var names = new[] { "Block1.c", "Block2.c", "Block3.c" };
			var filePaths = names
				.Select(n => Fixture.GetInputPath(CLanguageName, n));
			const string outputFilePath = "output.txt";

			Program.Main(filePaths.Concat(new[] { "-C", "-f", outputFilePath }).ToArray());

			using (var reader = new StreamReader(outputFilePath, XEncoding.SJIS)) {
				var expected = filePaths
					.Select(
						filePath =>
						CAstGenerator.Instance.GenerateFromFile(filePath) + Environment.NewLine)
					.JoinString();
				var actual = reader.ReadToEnd();
				Assert.That(actual, Is.EqualTo(expected));
			}
			File.Delete(outputFilePath);
		}

		[Test]
		public void パース結果を指定ディレクトリに出力できる() {
			var names = new[] { "Block1.c", "Block2.c", "Block3.c" };
			var filePaths = names
				.Select(n => Fixture.GetInputPath(CLanguageName, n));
			var outputPath = Fixture.GetOutputDirPath(CLanguageName);

			Program.Main(filePaths.Concat(new[] { "-C", "-d", outputPath }).ToArray());

			foreach (var filePath in filePaths) {
				var newPath = Path.Combine(outputPath,
					Path.ChangeExtension(Path.GetFileName(filePath), ".xml"));
				using (var reader = new StreamReader(newPath, XEncoding.SJIS)) {
					var actual = reader.ReadToEnd();
					var expected =
						CAstGenerator.Instance.GenerateFromFile(filePath).ToString();
					Assert.That(actual.StartsWith(expected), Is.True);
				}
			}
			Directory.Delete(outputPath, true);
		}
	}
}