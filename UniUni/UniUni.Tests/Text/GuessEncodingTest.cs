using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using UniUni.Text;

namespace UniUni.Tests.Text {
	[TestFixture]
	public class GuessEncodingTest {
		private IEnumerable<TestCaseData> TestCases {
			get {
				return new[] {
						new TestCaseData(
								"#!/usr/bin/env python\n# -*- coding: utf-8 -*-",
								Encoding.UTF8),
						new TestCaseData(
								"#!/usr/bin/env python\n# -*- coding: euc-jp -*-",
								Encoding.GetEncoding("euc-jp")),
						new TestCaseData(
								"\n# -*- coding: latin-1 -*-",
								Encoding.GetEncoding(1252)),
						new TestCaseData(
								"#あいうえお日本語\n# -*- coding: latin-1 -*-",
								Encoding.GetEncoding(1252)),
				};
			}
		}

		[Test]
		[TestCaseSource("TestCases")]
		public void GuessFromMagicComment(string text, Encoding encoding) {
			Assert.That(GuessEncoding.GetEncodingFromMagicComment(text), Is.EqualTo(encoding));
		}
	}
}
