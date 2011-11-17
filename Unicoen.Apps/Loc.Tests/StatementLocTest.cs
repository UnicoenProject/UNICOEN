using System;
using System.Collections.Generic;
using System.Linq;
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
            Assert.That(StatementLoc.CountStatementLoc(javaInputPath1), Is.EqualTo(43));
        }

        [Test]
        public void TestJavaDir()
        {
            var javaInputPath2 = FixtureUtil.GetInputPath("Java", "LocSample");
            Assert.That(StatementLoc.CountStatementLoc(javaInputPath2), Is.EqualTo(85));
        }

        [Test]
        public void TestJavaScriptFile()
        {
            var jsInputPath1 = FixtureUtil.GetInputPath("JavaScript", "student.js");
            Assert.That(StatementLoc.CountStatementLoc(jsInputPath1), Is.EqualTo(10));
        }

        [Test]
        public void TestJavaScriptDir()
        {
            var jsInputPath2 = FixtureUtil.GetInputPath("JavaScript", "tiny_mce");
            Assert.That(StatementLoc.CountStatementLoc(jsInputPath2), Is.EqualTo(13253));
        }
    }
}
