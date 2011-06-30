using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using NUnit.Framework;
using Unicoen.Core.Tests;
using Unicoen.Languages.Java;

namespace Unicoen.Apps.Translator.Tests {
	class TestForXmlGenerating {
		[Test]
		public void XMLを生成できる() {
			var filePath = FixtureUtil.GetInputPath("Java", "default", "Fibonacci.java");

			var code = File.ReadAllText(filePath, Encoding.Default);
			var model = JavaFactory.GenerateModel(code);

			var xml = model.ToXml();

			//			var fileStream = new FileStream(@"c:\test.xml", FileMode.Truncate, FileAccess.Write, FileShare.None, 124096);
			//			var writer = new StreamWriter(fileStream);

			var path = @"c:\test.xml";
			using (var fs = new FileStream(path, FileMode.Create)) {
				using (var writer = new StreamWriter(fs)) {
					// writer.WriteLine(xml);
					Console.WriteLine(xml);
				}
			}
		}

		[Test]
		public void SandBox() {
			var a = "aaaaaa";

			var b = a as IEnumerable;
			if(b == null) {
				Console.WriteLine("AAAAAAA");
			}
			else {
				Console.WriteLine(b);
			}

			Console.WriteLine(a.GetType().Name + ":" + a as string);
			Console.WriteLine(a + "");
		}
	}
}
