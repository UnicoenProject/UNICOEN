using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Paraiba.Text;
using Paraiba.Xml;
using Ucpf.Common.AstGenerators;
using Ucpf.Common.CodeGenerators;
using Ucpf.Common.Plugins;
using Ucpf.Common.Tests;

namespace Ucpf.Languages.Tests {
	[TestFixture]
	public class ParserTest {
		private static IEnumerable<TestCaseData> TestCases {
			get {
				var names = new[] {
					"C",
					"CSharp",
					"IronRuby",
					"Java",
					"JavaScript",
					"Lua",
					"Python2",
					"Python3",
					"Ruby18",
					//"Ruby19",
				};
				return names
					.SelectMany(
						name => Directory.EnumerateFiles(Fixture.GetInputPath(name))
						        	.Select(path => new { Name = name, Path = path }))
					.Select(p =>
					        new TestCaseData(p.Name, p.Path,
					        	PluginManager.AstGenerators.FirstOrDefault(
					        		o => o.GetType().Name == p.Name + "AstGenerator"),
					        	PluginManager.CodeGenerators.FirstOrDefault(
					        		o => o.GetType().Name == p.Name + "CodeGenerator")))
					.Where(t => t.Arguments[2] != null);
			}
		}

		[Test, TestCaseSource("TestCases")]
		public void パース結果が変化していない(string lang, string path, AstGenerator astGen,
		                          CodeGenerator codeGen) {
			var expPath = Fixture.GetXmlExpectationPath(lang, Path.GetFileName(path));
			var r = astGen.GenerateFromFile(path);
			using (var reader = new StreamReader(expPath, XEncoding.SJIS)) {
				Assert.That(r.ToString(), Is.EqualTo(reader.ReadToEnd()));
			}
		}

		[Test, TestCaseSource("TestCases")]
		public void パース結果をファイルに出力できる(string lang, string path, AstGenerator astGen,
		                             CodeGenerator codeGen) {
			var outPath = Fixture.GetOutputFilePath(lang, Path.GetFileName(path));
			var r = astGen.GenerateFromFile(path);
			using (var writer = new StreamWriter(outPath, false, XEncoding.SJIS)) {
				writer.Write(r.ToString());
			}
		}

		[Test, TestCaseSource("TestCases")]
		public void 構文木生成とコード生成を二回繰り返してもコードが変化しない(string lang, string path,
		                                          AstGenerator astGen,
		                                          CodeGenerator codeGen) {
			var r1 = astGen.GenerateFromFile(path);
			var c1 = codeGen.Generate(r1);
			var r2 = astGen.Generate(c1);
			var c2 = codeGen.Generate(r2);
			var r3 = astGen.Generate(c2);
			var c3 = codeGen.Generate(r3);

			Assert.IsTrue(XmlUtil.EqualsWithElementAndValue(r2, r3));
			Assert.AreEqual(c2, c3);
		}
	}
}