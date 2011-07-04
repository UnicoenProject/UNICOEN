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
			var fileName = "Hello.java";
			var input = FixtureUtil.GetInputPath("Java", "default", fileName);
			Console.WriteLine(input);
			var output = @"c:\";

			XMLGenerator.GenerateXML(input, output);

			if(File.Exists(output + fileName + ".xml")) {
				Assert.True(true);
			}
			else {
				Assert.False(true);
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
