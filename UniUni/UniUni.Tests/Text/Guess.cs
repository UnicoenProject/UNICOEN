using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using UniUni.Text;

namespace UniUni.Tests.Text {
	[TestFixture]
	public class EncodingUtilTest {
		private IEnumerable<TestCaseData> testCases {
			get {
				return new[] {
						new TestCaseData(
								"#!/usr/bin/env python\n# -*- coding: utf-8 -*-",
								Encoding.UTF8),
						new TestCaseData(
								"#!/usr/bin/env python\n# -*- coding: euc-jp -*-",
								Encoding.GetEncoding("euc-jp")),
				};
			}
		}

		[Test]
		[TestCaseSource("testCases")]
		public void GuessFromMagicComment(string text, Encoding encoding) {
			Assert.That(EncodingUtil.Guess(text), Is.EqualTo(encoding));
		}
	}
}
