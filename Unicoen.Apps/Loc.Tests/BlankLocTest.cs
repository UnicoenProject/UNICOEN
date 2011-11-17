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
            Assert.That(BlankLoc.CountBlankLoc(javaInputPath1), Is.EqualTo(9));
        }

        [Test]
        public void TestJavaDir()
        {
            var javaInputPath2 = FixtureUtil.GetInputPath("Java", "LocSample");
            Assert.That(BlankLoc.CountBlankLoc(javaInputPath2), Is.EqualTo(17));
        }
    }
}
