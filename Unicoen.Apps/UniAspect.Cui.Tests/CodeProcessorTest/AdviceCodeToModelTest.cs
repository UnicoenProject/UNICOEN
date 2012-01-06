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
using System.Linq;
using NUnit.Framework;
using Unicoen.Apps.UniAspect.Cui.Processor;
using Unicoen.Apps.UniAspect.Cui.Processor.Pointcut;
using Unicoen.Languages.Java.CodeGenerators;
using Unicoen.Model;

namespace Unicoen.Apps.UniAspect.Cui.CodeProcessorTest {
	[TestFixture]
	public class AdviceToModelTest {

		[Test]
		public void Java言語向けコード片を正しくモデル化できる() {
			const string code = "System.out.println(JOINPOINT_NAME + \"This is a test!\");";
			var advice = UcoGenerator.CreateAdvice("Java", code);
			Assert.That(advice.GetType(), Is.EqualTo(typeof(UnifiedBlock)));
		}

		[Test]
		public void JavaScript言語向けコード片を正しくモデル化できる() {
			const string code = "alert(\"This is a test!\");";
			var advice = UcoGenerator.CreateAdvice("JavaScript", code);
			Assert.That(advice.GetType(), Is.EqualTo(typeof(UnifiedBlock)));
		}

		[Test]
		public void Java言語向けメソッドインタータイプ宣言を正しくモデル化できる() {
			const string code = "public int getX() { return x; }";
			var elements = UcoGenerator.CreateIntertype("Java", code);
			Assert.That(
					elements.ElementAt(0).GetType(),
					Is.EqualTo(typeof(UnifiedFunctionDefinition)));
		}

		[Test]
		public void Java言語向けフィールドインタータイプ宣言を正しくモデル化できる() {
			const string code = "private int x = 10;";
			var elements = UcoGenerator.CreateIntertype("Java", code);
			Assert.That(
					elements.ElementAt(0).GetType(),
					Is.EqualTo(typeof(UnifiedVariableDefinitionList)));
		}

		[Test]
		public void JavaScript言語向けメソッドインタータイプ宣言を正しくモデル化できる() {
			const string code = "function getX() { return x; }";
			var elements = UcoGenerator.CreateIntertype("JavaScript", code);
			Assert.That(
					elements.ElementAt(0).GetType(),
					Is.EqualTo(typeof(UnifiedFunctionDefinition)));
		}

		[Test]
		public void JavaScript言語向けフィールドインタータイプ宣言を正しくモデル化できる() {
			const string code = "var x = 10;";
			var elements = UcoGenerator.CreateIntertype("JavaScript", code);
			Assert.That(
					elements.ElementAt(0).GetType(),
					Is.EqualTo(typeof(UnifiedVariableDefinitionList)));
		}

		[Test]
		public void 特殊文字を含むアドバイス内の変数を指定された文字列に置き換えられる() {
			var code = "System.out.println(JOINPOINT_NAME + \" is executed!\");";
			var advice = UcoGenerator.CreateAdvice("Java", code);

			//アドバイス内の特殊文字を置き換える
			Execution.ReplaceSpecialToken(advice, "test");

			code = "System.out.println(\"test\" + \" is executed!\");";
			var actual = UcoGenerator.CreateAdvice("Java", code);

			var gen = new JavaCodeGenerator();
			Console.WriteLine(gen.Generate(advice));

			Assert.That(gen.Generate(advice), Is.EqualTo(gen.Generate(actual)));
		}
	}
}