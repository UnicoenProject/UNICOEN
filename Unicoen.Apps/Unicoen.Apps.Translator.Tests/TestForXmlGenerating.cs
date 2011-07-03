using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using NUnit.Framework;
using Unicoen.Core.Tests;
using Unicoen.Languages.C;
using Unicoen.Languages.Java;
using Unicoen.Languages.JavaScript;

namespace Unicoen.Apps.Translator.Tests {
	class TestForXmlGenerating {
		[Test]
		public void XMLを生成できる() {
			var filePath = FixtureUtil.GetInputPath("JavaScript", "hello.js");

			var code = File.ReadAllText(filePath, Encoding.Default);
			var model = JavaScriptFactory.GenerateModel(code);

			var xml = model.ToXml();
			var str = model.ToString();

			var path = @"c:\hello_js.xml";
			using (var fs = new FileStream(path, FileMode.Create)) {
				using (var writer = new StreamWriter(fs)) {
					writer.WriteLine(xml);
					Console.WriteLine(xml);
				}
			}
		}
		

		[Test]
		public void SandBox() {
			var root = new XmlDocument();
			if (!File.Exists(@"c:\hello_java.xml")) {
				return;
			}
		
			root.Load(@"c:\hello_java.xml");
			var modifier = root.GetElementsByTagName("UnifiedModifier").Item(0);

			var strings = (modifier as XmlElement).GetElementsByTagName("String");
			for (int i = 0; i < strings.Count; i++) {
				var node = strings.Item(i);
				Console.WriteLine(node.Value);
			}

			// Function calling
			var callNode = root.GetElementsByTagName("UnifiedCall").Item(0);
			var children = callNode.ChildNodes;

			Console.WriteLine(children.Count);

			XmlNode propNode = null;
			for (int i = 0; i < children.Count; i++) {
				var node = children.Item(i);
				if (node.LocalName.Equals("UnifiedProperty")) {
					propNode = node;
					break;
				}
			}

			if (propNode == null) {
				Console.WriteLine("aaaaa:");
				return;
			}

			var strNodeList = (propNode as XmlElement).GetElementsByTagName("String");

			for (int i = 0; i < strNodeList.Count; i++) {
				var node = strNodeList.Item(i);
				Console.WriteLine("aaaaasdfasdfadsfasda");
				Console.WriteLine(node.Value);
			}



		}
	}
}
