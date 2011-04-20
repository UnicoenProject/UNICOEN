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

using Code2Xml.Languages.Python2.XmlGenerators;
using NUnit.Framework;
using Unicoen.Languages.Python2.Model;

namespace Unicoen.Languages.Python2.Tests {
	[TestFixture]
	public class PythonLiteralTest {
		[Test]
		[TestCase("'1'", "1")]
		[TestCase("\"1\"", "1")]
		public void ParseStringLiteral(string code, string expectation) {
			var ast = Python2XmlGenerator.Instance.Generate(code);
			var lit = PythonModelFactory.CreateStringLiteral(ast);
			Assert.That(lit.Value, Is.EqualTo(expectation));
		}
	}
}