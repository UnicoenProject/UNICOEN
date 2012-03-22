#region License

// Copyright (C) 2011 The Unicoen Project
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using NUnit.Framework;
using Unicoen.Apps.Loc.Util;
using Unicoen.TestUtils;
using Unicoen.Tests;

namespace Unicoen.Apps.Loc.Tests {
    [TestFixture]
    public class BlankLocTest {
        [Test]
        public void TestJavaDir() {
            var javaInputPath2 = FixtureUtil.GetInputPath("Java", "LocSample");
            Assert.That(BlankLoc.Count(javaInputPath2), Is.EqualTo(17));
        }

        [Test]
        public void TestJavaFile() {
            var javaInputPath1 = FixtureUtil.GetInputPath("Java", "point.java");
            Assert.That(BlankLoc.Count(javaInputPath1), Is.EqualTo(9));
        }

        [Test]
        public void TestJavaScriptDir() {
            var jsInputPath2 = FixtureUtil.GetInputPath(
                    "JavaScript", "tiny_mce");
            Assert.That(BlankLoc.Count(jsInputPath2), Is.EqualTo(3093));
        }

        [Test]
        public void TestJavaScriptFile() {
            var jsInputPath1 = FixtureUtil.GetInputPath(
                    "JavaScript", "student.js");
            Assert.That(BlankLoc.Count(jsInputPath1), Is.EqualTo(2));
        }
    }
}