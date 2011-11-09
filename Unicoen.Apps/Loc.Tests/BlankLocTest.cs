using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Unicoen.Apps.Loc.Util;
using Unicoen.Tests;

namespace Unicoen.Apps.Loc.Tests {
	[TestFixture]
	public class BlankLocTest {
		[Test]
		public void TestMeasureJava() {
            var javaInputPath = FixtureUtil.GetInputPath("Java", "Fibonacci.java");
			Assert.That(BLoc.CountBLoc(javaInputPath), Is.EqualTo(1));
		}
	}
}
