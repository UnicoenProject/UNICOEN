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
		[Test]
		public void Javaから変換された共通オブジェクトをmseフォーマットに変換できる() {
			const string langType = ".java";
			var filePaths =
					Collect(FixtureUtil.GetDownloadPath("java", "junit4.8.2"), langType);

			var writer = new StringWriter();
			var converter = new MseConverter(writer, "Java");

			converter.Generate(filePaths, writer, "Java");

			Console.Write(writer.ToString());
		}

		[Test]
		public void JavaScriptから変換された共通オブジェクトをmseフォーマットに変換できる() {
			const string langType = ".js";
			var filePaths =
					Collect(FixtureUtil.GetDownloadPath("JavaScript", "Processing.js-1.2.3"), langType);

			var writer = new StringWriter();
			var converter = new MseConverter(writer, "JavaScript");

			converter.Generate(filePaths, writer, "JavaScript");

			Console.Write(writer.ToString());
		}

		[Test]
		public void CSharpから変換された共通オブジェクトをmseフォーマットに変換できる() {
			const string langType = ".cs";
			var filePaths =
					Collect(FixtureUtil.GetDownloadPath("java", "junit4.8.2"), langType);

			var writer = new StringWriter();
			var converter = new MseConverter(writer, "CSharp");

			converter.Generate(filePaths, writer, "CSharp");

			Console.Write(writer.ToString());
		}

		[Test]
		public void Pythonから変換された共通オブジェクトをmseフォーマットに変換できる() {
			const string langType = ".py";
			var filePaths =
					Collect(FixtureUtil.GetDownloadPath("Python2", "django"), langType);

			var writer = new StringWriter();
			var converter = new MseConverter(writer, "Python");

			converter.Generate(filePaths, writer, "Python");

			Console.Write(writer.ToString());
		}

		[Test]
		public void Tornadeをmseフォーマットに変換できる() {
			const string langType = ".py";
			var filePaths =
					Collect(FixtureUtil.GetDownloadPath("Python2", "tornado"), langType);

			var writer = new StringWriter();
			var converter = new MseConverter(writer, "Python");

			converter.Generate(filePaths, writer, "Python");

			Console.Write(writer.ToString());
		}

		public static IEnumerable<string> Collect(string folderRootPath, string language) {
			//指定された文字列がフォルダじゃなかった場合
			if (!Directory.Exists(folderRootPath)) {
				return Enumerable.Repeat(folderRootPath, 1);
			}

			//指定された文字列に該当するフォルダがある場合
			return Directory.EnumerateFiles(
					folderRootPath, ("*" + language), SearchOption.AllDirectories);
		}
	}
}
