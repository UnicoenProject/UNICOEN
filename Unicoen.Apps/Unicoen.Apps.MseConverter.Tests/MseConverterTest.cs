using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Paraiba.Text;
using Unicoen.Apps.Aop.Cui.CodeProcessor;
using Unicoen.Model;
using Unicoen.Tests;

namespace Unicoen.Apps.MseConverter.Tests
{
	[TestFixture]
	public class MseConverterTest {
		//指定されたパスのファイルを読み込んで共通コードオブジェクトに変換します
		public UnifiedProgram CreateModel(string path) {
			var code = File.ReadAllText(path, XEncoding.SJIS);
			return CodeProcessor.CreateModel(".java", code);
		}

		[Test]
		public void 共通オブジェクトをmseフォーマットに変換できる() {
			var filePaths =
					Collect(FixtureUtil.GetDownloadPath("java", "junit4.8.2"));

			var writer = new StringWriter();
			var converter = new MseConverter(writer);

			converter.Generate(filePaths, writer);

			Console.Write(writer.ToString());
		}

		public static IEnumerable<string> Collect(string folderRootPath) {
			//指定された文字列がフォルダじゃなかった場合
			if (!Directory.Exists(folderRootPath)) {
				return Enumerable.Repeat(folderRootPath, 1);
			}

			//指定された文字列に該当するフォルダがある場合
			return Directory.EnumerateFiles(
					folderRootPath, "*.java", SearchOption.AllDirectories);
		}
	}
}
