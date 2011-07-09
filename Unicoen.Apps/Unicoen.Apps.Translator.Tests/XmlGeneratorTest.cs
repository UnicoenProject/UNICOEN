using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Unicoen.Core.Tests;

namespace Unicoen.Apps.Translator.Tests {
	public class XmlGeneratorTest {
		[Test]
		public void XMLを正しく出力できる() {
			var input = FixtureUtil.GetInputPath("Java", "default", "Hello.java");
			var output = FixtureUtil.GetOutputPath();
			Console.WriteLine(input);

			XmlGenerator.GenerateXml(input, output);
		}
	}
}
