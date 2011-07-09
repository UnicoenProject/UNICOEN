#region License

// Copyright (C) 2011 The Unicoen Project
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System;
using System.IO;
using System.Text;
using System.Xml;
using NUnit.Framework;
using Unicoen.Core.Tests;
using Unicoen.Languages.JavaScript;

namespace Unicoen.Apps.Translator.Tests {
	public class XmlGenerateTest {
		[Test]
		public void Xmlを生成できる() {
			var inPath = FixtureUtil.GetInputPath("JavaScript", "hello.js");
			var outPath = FixtureUtil.GetOutputPath("hello_js.xml");

			var code = File.ReadAllText(inPath, Encoding.Default);
			var model = JavaScriptFactory.GenerateModel(code);

			var xml = model.ToXml();
			var str = model.ToString();

			using (var fs = new FileStream(outPath, FileMode.Create)) {
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