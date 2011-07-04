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
			var input = FixtureUtil.GetInputPath("JavaScript",  "hello.js");
			Console.WriteLine(input);
			var output = @"c:\";

			XMLGenerator.GenerateXML(input, output);
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
