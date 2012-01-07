using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Unicoen.Tests;
using Unicoen.Apps.Loc.Util;

namespace Unicoen.Apps.Loc.Tests
{
	[TestFixture]
	public class StatementLocTest
	{
		[Test]
		public void TestJavaFile()
		{
			var javaInputPath1 = FixtureUtil.GetInputPath("Java", "point.java");
			Assert.That(StatementLoc.Count(javaInputPath1), Is.EqualTo(43));
		}

		[Test]
		public void TestJavaDir()
		{
			var javaInputPath2 = FixtureUtil.GetInputPath("Java", "LocSample");
			Assert.That(StatementLoc.Count(javaInputPath2), Is.EqualTo(85));
		}

		[Test]
		public void TestJavaScriptFile()
		{
			var jsInputPath1 = FixtureUtil.GetInputPath("JavaScript", "student.js");
			Assert.That(StatementLoc.Count(jsInputPath1), Is.EqualTo(10));
		}

		[Test]
		public void TestJavaScriptDir()
		{
			var jsInputPath2 = FixtureUtil.GetInputPath("JavaScript", "tiny_mce");
			Assert.That(StatementLoc.Count(jsInputPath2), Is.EqualTo(13253));
		}

		[Test]
		public void TestPython2File() {
			var path = FixtureUtil.GetInputPath("Python2", "fibonacci.py");
			Assert.That(StatementLoc.Count(path), Is.EqualTo(8));
		}
	}
}
