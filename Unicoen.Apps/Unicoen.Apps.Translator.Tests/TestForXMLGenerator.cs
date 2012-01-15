using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Unicoen.Core.Tests;

namespace Unicoen.Apps.Translator.Tests {
	public class TestForXMLGenerator {
		[Test]
		public void XMLを正しく出力できる() {
			var filePathes = new string[] {
					FixtureUtil.GetInputPath("Java", "default", "Foo.java"), 
					FixtureUtil.GetInputPath("JavaScript", "foo.js"),
			};

			var output = @"c:\";
			foreach (var input in filePathes) {
				Console.WriteLine(input);
				XMLGenerator.GenerateXML(input, output);

				if (File.Exists(output + Path.GetFileName(input)+ ".xml")) {
					Assert.True(true);
				} else {
					Assert.False(true);
				}
			}
		}

		[Test]
		public void ファイルが無かったときに例外を吐ける() {
			var input = FixtureUtil.GetInputPath("Java", "default", "HHello.java");

			try {
				XMLGenerator.GenerateXML(input);
			} catch (FileNotFoundException e) {
				Assert.True(true);
				return;
			}

			Assert.False(true);

		}
	}

}
