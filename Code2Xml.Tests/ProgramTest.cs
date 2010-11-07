using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Paraiba.Core;
using Paraiba.Text;
using Ucpf.AstGenerators;
using Ucpf.Languages.C;
using Ucpf.Languages.CSharp;
using Ucpf.Languages.Java;
using Ucpf.Languages.JavaScript;
using Ucpf.Languages.Lua;
using Ucpf.Languages.Python2;
using Ucpf.Languages.Python3;
using Ucpf.Languages.Ruby;

namespace Code2Xml.Tests
{
	[TestFixture]
	public class ProgramTest
	{
		static IEnumerable<TestCaseData> TestCases
		{
			get
			{
				yield return new TestCaseData("c", "-C", CAstGeneratorOld.Instance).Returns(true);
				yield return new TestCaseData("cs", "-C#", CSharpAstGeneratorOld.Instance).Returns(true);
				yield return new TestCaseData("java", "-Java", JavaAstGenerator.Instance).Returns(true);
				yield return new TestCaseData("js", "-JavaScript", JavaScriptAstGeneratorOld.Instance).Returns(true);
				yield return new TestCaseData("py", "-Python2", Python2AstGenerator.Instance).Returns(true);
				yield return new TestCaseData("py", "-Python3", Python3AstGenerator.Instance).Returns(true);
				yield return new TestCaseData("lua", "-Lua", LuaAstGeneratorOld.Instance).Returns(true);
				yield return new TestCaseData("rb", "-Ruby", RubyAstGenerator.Instance).Returns(true);
			}
		}

		[Test, TestCaseSource("TestCases")]
		public bool パースできる(string extension, string parserOption, IAstGenerator astGenerator)
		{
			var filePath = "../codes/Block3." + extension;
			var output = new StringWriter();
			Console.SetOut(output);

			Program.Main(new[] { filePath, parserOption });

			var actual = output.ToString();
			var expected = astGenerator.GenerateFromFile(filePath).ToString();
			return actual.StartsWith(expected);
		}

		[Test]
		public void パース結果をファイルに出力できる()
		{
			var filePaths = new[] { "../codes/Block1.c", "../codes/Block2.c", "../codes/Block3.c" };
			const string outputPath = "output.txt";

			Program.Main(filePaths.Concat(new[] { "-C", "-f", outputPath }).ToArray());

			using (var fs = new FileStream(outputPath, FileMode.Open))
            using (var reader = new StreamReader(fs, XEncoding.SJIS))
            {
				var expected = filePaths
					.Select(filePath => CAstGeneratorOld.Instance.GenerateFromFile(filePath) + Environment.NewLine)
					.JoinString();
				var actual = reader.ReadToEnd();
				Assert.That(actual, Is.EqualTo(expected));
			}
			File.Delete(outputPath);
		}

		[Test]
		public void パース結果をディレクトリに出力できる()
		{
			var filePaths = new[] { "../codes/Block1.c", "../codes/Block2.c", "../codes/Block3.c" };

			Program.Main(filePaths.Concat(new[] { "-C", "-d" }).ToArray());

			foreach (var filePath in filePaths) {
				var newPath = Path.Combine(Path.GetDirectoryName(filePath),
					Path.ChangeExtension(Path.GetFileName(filePath), ".xml"));
				using (var fs = new FileStream(newPath, FileMode.Open))
                using (var reader = new StreamReader(fs, XEncoding.SJIS))
                {
					var actual = reader.ReadToEnd();
					var expected = CAstGeneratorOld.Instance.GenerateFromFile(filePath).ToString();
					Assert.That(actual.StartsWith(expected), Is.True);
				}
				File.Delete(newPath);
			}
		}

		[Test]
		public void パース結果を指定ディレクトリに出力できる()
		{
			var filePaths = new[] { "../codes/Block1.c", "../codes/Block2.c", "../codes/Block3.c" };
			const string outputPath = "output";
			Directory.CreateDirectory(outputPath);

			Program.Main(filePaths.Concat(new[] { "-C", "-d", outputPath }).ToArray());

			foreach (var filePath in filePaths) {
				var newPath = Path.Combine(outputPath,
					Path.ChangeExtension(Path.GetFileName(filePath), ".xml"));
				using (var fs = new FileStream(newPath, FileMode.Open))
                using (var reader = new StreamReader(fs, XEncoding.SJIS))
                {
					var actual = reader.ReadToEnd();
					var expected = CAstGeneratorOld.Instance.GenerateFromFile(filePath).ToString();
					Assert.That(actual.StartsWith(expected), Is.True);
				}
			}
			Directory.Delete(outputPath, true);
		}

		[Test]
		public void コードを生成できる()
		{
			var filePaths = new[] { "../codes/Block1.c", "../codes/Block2.c", "../codes/Block3.c" };
			const string outputPath = "output";
			Directory.CreateDirectory(outputPath);

			Program.Main(filePaths.Concat(new[] { "-C", "-d", outputPath }).ToArray());
			Program.Main(filePaths
				.Select(path => Path.Combine(outputPath,
					Path.ChangeExtension(Path.GetFileName(path), ".xml")))
				.Concat(new[] { "-code", "-C", "-d", outputPath }).ToArray());

			foreach (var filePath in filePaths) {
				var newPath = Path.Combine(outputPath, Path.GetFileName(filePath));
				using (var fs = new FileStream(newPath, FileMode.Open))
                using (var reader = new StreamReader(fs, XEncoding.SJIS)) {
                    var actual = reader.ReadToEnd();
                    var ast = CAstGeneratorOld.Instance.GenerateFromFile(filePath);
                    var expected = CCodeGenerator.Instance.Generate(ast);
                    Assert.That(actual.StartsWith(expected), Is.True);
                }
			}
			Directory.Delete(outputPath, true);
		}
	}
}
