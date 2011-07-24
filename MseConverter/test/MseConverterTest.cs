using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Paraiba.Text;
using Unicoen.Apps.Aop;
using Unicoen.Apps.Aop.Cui.CodeProcessor;
using Unicoen.Model;
using Unicoen.Tests;

namespace MseConverter.test
{
	[TestFixture]
	public class MseConverterTest {

		private readonly string _fibonacciPath = Path.Combine(
				"..", "..", "..", "fixture", "Java", "input", "Default", "Fibonacci.java");

		private readonly string _studentPath = Path.Combine(
				"..", "..", "..", "fixture", "Java", "input", "Default", "Student.java");

		//指定されたパスのファイルを読み込んで共通コードオブジェクトに変換します
		public UnifiedProgram CreateModel(string path) {
			var code = File.ReadAllText(path, XEncoding.SJIS);
			return CodeProcessor.CreateModel(".java", code);
		}

		[Test]
		public void 共通オブジェクトをmseフォーマットに変換できる() {
			var filePaths =
					Collect(FixtureUtil.GetDownloadPath("java", "junit4.8.2", "src"));

			var writer = new StringWriter();
			var converter = new MseConverter(writer);

			converter.Generate(filePaths, writer);

			Console.Write(writer.ToString());
		}

		public static IEnumerable<string> Collect(string folderRootPath) {
			//指定された文字列がフォルダじゃなかった場合
			if (!Directory.Exists(folderRootPath)) {
				var list = new List<string>();
				list.Add(folderRootPath);
				return list;
			}

			//指定された文字列に該当するフォルダがある場合
			return Directory.EnumerateFiles(
					folderRootPath, "*", SearchOption.AllDirectories);
		}
	}
}
