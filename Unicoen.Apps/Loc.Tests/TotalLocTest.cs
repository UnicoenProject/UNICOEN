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

        [Test]
        public void TestJavaScriptFile()
        {
            var jsInputPath1 = FixtureUtil.GetInputPath("JavaScript", "student.js");
            Assert.That(TotalLoc.CountTotalLoc(jsInputPath1), Is.EqualTo(15));
        }

        [Test]
        public void TestJavaScriptDir()
        {
            var jsInputPath2 = FixtureUtil.GetInputPath("JavaScript", "tiny_mce");
            Assert.That(TotalLoc.CountTotalLoc(jsInputPath2), Is.EqualTo(14202));
        }


        //var cInputPath = FixtureUtil.GetInputPath("C", "fibonacci.c");
        //var cSharpInputPath = FixtureUtil.GetInputPath("CSharp", "Student.cs");
        //var pyInputPath = FixtureUtil.GetInputPath("Python2", "fibonacci.py");
        //var rubyInputPath = FixtureUtil.GetInputPath("Ruby18", "fibonacci.rb");
    }
}
