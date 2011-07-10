using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace UniUni.Tests.Text {
	[TestFixture]
	public class GuessTest {
		[Test]
		[TestCase("#!/usr/bin/env python\n# -*- coding: utf-8 -*-")]
		public void GuessFromMagicComment(string text) {
			
		}
	}
}
