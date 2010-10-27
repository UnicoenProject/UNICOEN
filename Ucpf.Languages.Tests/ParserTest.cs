using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Paraiba.Xml;
using Ucpf.AstGenerators;
using Ucpf.Plugins;

namespace Ucpf.Languages.Tests
{
	[TestFixture]
	public class ParserTest
	{
		private const string DirectoryPath = "../codes/";
		private const string OutputDirectoryPath = "../codes/xmlexpected/";

		static IEnumerable<TestCaseData> TestCases
		{
			get
			{
				return Directory.EnumerateFiles(DirectoryPath)
					.SelectMany(path => {
						var ext = Path.GetExtension(path);
						return PluginManager.AstGenerators
							.Where(a => a.TargetExtensions.Contains(ext))
							.Select(a => Tuple.Create(path, a));
					})
					.Select(t => new TestCaseData(t.Item1, t.Item2));
			}
		}

		//[Test, TestCaseSource("TestCases")]
		public void パース結果をファイルに出力できる(string fileName, IAstGenerator astGen)
		{
			var path = Path.Combine(DirectoryPath, fileName);
			var outpath = Path.Combine(OutputDirectoryPath, Path.GetFileName(fileName) + astGen.ParserName);
			var r = astGen.GenerateFromFile(path);
			using (var fs = new FileStream(outpath, FileMode.Create))
			using (var writer = new StreamWriter(fs)) {
				writer.Write(r.ToString());
			}
		}

		[Test, TestCaseSource("TestCases")]
		public void パース結果が変化していない(string fileName, IAstGenerator astGen)
		{
			var path = Path.Combine(DirectoryPath, fileName);
			var inpath = Path.Combine(OutputDirectoryPath, Path.GetFileName(fileName) + astGen.ParserName);
			var r = astGen.GenerateFromFile(path);
			using (var fs = new FileStream(inpath, FileMode.Open))
			using (var reader = new StreamReader(fs)) {
				Assert.That(r.ToString(), Is.EqualTo(reader.ReadToEnd()));
			}
		}

		[Test, TestCaseSource("TestCases")]
		public void 全てのソースコードをパースできる(string fileName, IAstGenerator astGen)
		{
			var path = Path.Combine(DirectoryPath, fileName);
			var codeGen = PluginManager.CodeGenerators
				.First(c => c.ParserName == astGen.ParserName);

			var r1 = astGen.GenerateFromFile(path);
			var c1 = codeGen.Generate(r1);
			var r2 = astGen.GenerateFromText(c1);
			var c2 = codeGen.Generate(r2);
			var r3 = astGen.GenerateFromText(c2);

			Assert.IsTrue(XmlUtil.EqualsWithElementAndValue(r2, r3));
			Assert.AreEqual(c1, c2);
		}
	}
}
