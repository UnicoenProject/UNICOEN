using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Paraiba.Text;
using Unicoen.Apps.Aop;
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
					Collect(
							Path.Combine(
									"..", "..", "..", "fixture", "Java", "download", "junit4.8.2", "src"));

			var writer = new StringWriter();
			var converter = new MseConverter(writer);

			writer.WriteLine("(Moose.Model (id: 1)");
			writer.WriteLine("\t(entity");

			foreach (var file in filePaths) {
				//とりあえずJavaファイルのみをフォルタリング
				var ext = Path.GetExtension(file);
				if(ext != ".java")
					continue;

				converter.Generate(CreateModel(file), writer);
			}

			writer.WriteLine("\t)");
			//TODO 言語の種類を出力
			writer.WriteLine("(sourceLanguage 'Java'))");

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
