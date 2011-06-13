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

using System.Linq;
using NUnit.Framework;
using Unicoen.Core.Model;

namespace Unicoen.Apps.Aop.Tests {
	[TestFixture]
	public class AdviceToModelTest {
		[Test]
		public void Java言語向けコード片を正しくモデル化できる() {
			const string code = "System.out.println(\"This is a test!\");";
			var advice = CodeProcessor.CreateAdvice("Java", code);

			Assert.That(advice.GetType(), Is.EqualTo(typeof(UnifiedBlock)));
		}

		[Test]
		public void JavaScript言語向けコード片を正しくモデル化できる() {
			const string code = "alert(\"This is a test!\");";
			var advice = CodeProcessor.CreateAdvice("JavaScript", code);
			Assert.That(advice.GetType(), Is.EqualTo(typeof(UnifiedBlock)));
		}

		[Test]
		public void Java言語向けメソッドインタータイプ宣言を正しくモデル化できる() {
			const string code = "public int getX() { return x; }";
			var elements = CodeProcessor.CreateIntertype("Java", code);
			Assert.That(
					elements.ElementAt(0).GetType(),
					Is.EqualTo(typeof(UnifiedFunction)));
		}

		[Test]
		public void Java言語向けフィールドインタータイプ宣言を正しくモデル化できる() {
			const string code = "private int x = 10;";
			var elements = CodeProcessor.CreateIntertype("Java", code);
			Assert.That(
					elements.ElementAt(0).GetType(),
					Is.EqualTo(typeof(UnifiedVariableDefinitionList)));
		}

		[Test]
		public void JavaScript言語向けメソッドインタータイプ宣言を正しくモデル化できる() {
			const string code = "function getX() { return x; }";
			var elements = CodeProcessor.CreateIntertype("JavaScript", code);
			Assert.That(
					elements.ElementAt(0).GetType(),
					Is.EqualTo(typeof(UnifiedFunction)));
		}

		[Test]
		public void JavaScript言語向けフィールドインタータイプ宣言を正しくモデル化できる() {
			const string code = "var x = 10;";
			var elements = CodeProcessor.CreateIntertype("JavaScript", code);
			Assert.That(
					elements.ElementAt(0).GetType(),
					Is.EqualTo(typeof(UnifiedVariableDefinitionList)));
		}
	}
}