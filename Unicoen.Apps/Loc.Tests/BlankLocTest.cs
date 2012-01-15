using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Unicoen.Apps.Loc.Util;
using Unicoen.Tests;

namespace Unicoen.Apps.Loc.Tests
{
    [TestFixture]
    public class BlankLocTest
    {
        [Test]
        public void TestJavaFile()
        {
            var javaInputPath1 = FixtureUtil.GetInputPath("Java", "point.java");
            Assert.That(BlankLoc.Count(javaInputPath1), Is.EqualTo(9));
        }

        [Test]
        public void TestJavaDir()
        {
            var javaInputPath2 = FixtureUtil.GetInputPath("Java", "LocSample");
            Assert.That(BlankLoc.Count(javaInputPath2), Is.EqualTo(17));
        }

        [Test]
        public void TestJavaScriptFile()
        {
            var jsInputPath1 = FixtureUtil.GetInputPath("JavaScript", "student.js");
            Assert.That(BlankLoc.Count(jsInputPath1), Is.EqualTo(2));
        }

        [Test]
        public void TestJavaScriptDir()
        {
            var jsInputPath2 = FixtureUtil.GetInputPath("JavaScript", "tiny_mce");
            Assert.That(BlankLoc.Count(jsInputPath2), Is.EqualTo(3093));
        }
    }
}
