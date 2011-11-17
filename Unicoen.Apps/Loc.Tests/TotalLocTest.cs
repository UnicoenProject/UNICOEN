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
    public class TotalLocTest
    {
        [Test]
        public void TestJavaFile()
        {
            var javaInputPath1 = FixtureUtil.GetInputPath("Java", "point.java");
            Assert.That(TotalLoc.CountTotalLoc(javaInputPath1), Is.EqualTo(81));
        }

        [Test]
        public void TestJavaDir()
        {
            var javaInputPath2 = FixtureUtil.GetInputPath("Java", "LocSample");
            Assert.That(TotalLoc.CountTotalLoc(javaInputPath2), Is.EqualTo(121));
        }
    }
}
