﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Unicoen.Core.Model;

namespace Unicoen.Apps.Aop.Tests
{
	[TestFixture]
	public class IntertypeTest {

		//TODO CreateAdvice()に関するテストを追加する

		[Test]
		public void Java言語向けメソッドインタータイプ宣言を正しくモデル化できる() {
			const string code = "public int getX() { return x; }";
			var elements = CodeProcessor.CreateIntertype("Java", code);
			Assert.That(elements.ElementAt(0).GetType(), 
				Is.EqualTo(typeof(UnifiedFunctionDefinition)));
		}

		[Test]
		public void Java言語向けフィールドインタータイプ宣言を正しくモデル化できる() {
			const string code = "private int x = 10;";
			var elements = CodeProcessor.CreateIntertype("Java", code);
			Assert.That(elements.ElementAt(0).GetType(), 
				Is.EqualTo(typeof(UnifiedVariableDefinitionList)));
		}

		[Test]
		public void JavaScript言語向けメソッドインタータイプ宣言を正しくモデル化できる() {
			const string code = "function getX() { return x; }";
			var elements = CodeProcessor.CreateIntertype("JavaScript", code);
			Assert.That(elements.ElementAt(0).GetType(), 
				Is.EqualTo(typeof(UnifiedFunctionDefinition)));
		}

		[Test]
		public void JavaScript言語向けフィールドインタータイプ宣言を正しくモデル化できる() {
			const string code = "var x = 10;";
			var elements = CodeProcessor.CreateIntertype("JavaScript", code);
			Assert.That(elements.ElementAt(0).GetType(), 
				Is.EqualTo(typeof(UnifiedVariableDefinitionList)));
		}
	}
}
