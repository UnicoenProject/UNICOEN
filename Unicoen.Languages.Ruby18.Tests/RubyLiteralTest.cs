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

using System.Numerics;
using Code2Xml.Languages.Ruby18.CodeToXmls;
using NUnit.Framework;
using Unicoen.Core.Model;
using Unicoen.Languages.Ruby18.Model;

namespace Unicoen.Languages.Ruby18.Tests {
	[TestFixture]
	public class RubyParseLiteralTest {
		[Test]
		[TestCase("true", true)]
		[TestCase("false", false)]
		public void ParseBooleanLiteral(string code, bool expectation) {
			var ast = Ruby18CodeToXml.Instance.Generate(code);
			var lit = RubyModelFactory.CreateBooleanLiteral(ast);
			Assert.That(lit.Value, Is.EqualTo(expectation));
		}

		[Test]
		[TestCase("1.1", 1.1)]
		public void ParseDecimalLiteral(string code, double expectation) {
			var ast = Ruby18CodeToXml.Instance.Generate(code);
			var lit = RubyModelFactory.CreateDecimalLiteral(ast);
			Assert.That(lit.Value, Is.EqualTo((decimal)expectation));
		}

		[Test]
		[TestCase("1", 1)]
		public void ParseIntegerLiteral(string code, int expectation) {
			var ast = Ruby18CodeToXml.Instance.Generate(code);
			var lit = RubyModelFactory.CreateLiteral(ast) as UnifiedIntegerLiteral;
			Assert.That(lit.Value, Is.EqualTo((BigInteger)expectation));
		}

		[Test]
		[TestCase("'1'", "1")]
		[TestCase("\"1\"", "1")]
		//TODO: [TestCase("\"#{1}\"", "1")]
		//TODO: [TestCase("\"#{a}\"", "a")]
		public void ParseStringLiteral(string code, string expectation) {
			var ast = Ruby18CodeToXml.Instance.Generate(code);
			var lit = RubyModelFactory.CreateStringLiteral(ast);
			Assert.That(lit.Value, Is.EqualTo(expectation));
		}
	}
}