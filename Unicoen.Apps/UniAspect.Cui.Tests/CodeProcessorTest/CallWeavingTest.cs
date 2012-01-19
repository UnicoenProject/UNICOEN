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

using System.Text.RegularExpressions;
using NUnit.Framework;
using Unicoen.Apps.UniAspect.Cui.Processor;
using Unicoen.Apps.UniAspect.Cui.Processor.Pointcut;
using Unicoen.Processor;
using Unicoen.Tests;

namespace Unicoen.Apps.UniAspect.Cui.CodeProcessorTest {
    /// <summary>
    ///   関数呼び出しに関するアスペクトの合成が正しく機能するかテストする
    /// </summary>
    [TestFixture]
    public class CallWeavingTest {
        private readonly string _studentPath =
                FixtureUtil.GetInputPath("Java", "Default", "Student.java");

        // TODO コメントアウトしている言語のファイルを用意する
        // TODO CodeProcessorProviderを使うようにする

        [Test]
        //		[TestCase("Java", ".java", "System.out.println(\"Inserted after.\");")]
        //		[TestCase("JavaScript", ".js", "Console.log(\"Inserted after.\");")]
        //		[TestCase("C", ".c", "printf(\"Inserted after.\");")]
        //		[TestCase("CSharp", ".cs", "Console.WriteLine(\"Inserted after.\");")]
        //		[TestCase("Python", ".py", "print \"Inserted after.\"")]
        public void CallAfterが正しく動作することを検証します(
                string language, string ext, string code) {
            var model = UnifiedGenerators.GenerateProgramFromFile(
                    FixtureUtil.GetInputPath(
                            "Aspect", "Call", "Fibonacci" + ext));
            var actual = UnifiedGenerators.GenerateProgramFromFile(
                    FixtureUtil.GetInputPath(
                            "Aspect", "Call",
                            "Fibonacci_expectation_after" + ext));

            Call.InsertAtAfterCallByName(
                    model, "fibonacci",
                    UcoGenerator.CreateAdvice(language, code));

            Assert.That(
                    model,
                    Is.EqualTo(actual).Using(
                            StructuralEqualityComparer.Instance));
        }

        [Test]
        //		[TestCase("Java", ".java", "System.out.println(\"Inserted before.\");")]
        //		[TestCase("JavaScript", ".js", "Console.log(\"Inserted before.\");")]
        //		[TestCase("C", ".c", "printf(\"Inserted before.\");")]
        //		[TestCase("CSharp", ".cs", "Console.WriteLine(\"Inserted before.\");")]
        //		[TestCase("Python", ".py", "print \"Inserted before.\"")]
        public void CallBeforeが正しく動作することを検証します(
                string language, string ext, string code) {
            var model = UnifiedGenerators.GenerateProgramFromFile(
                    FixtureUtil.GetInputPath(
                            "Aspect", "Call", "Fibonacci" + ext));
            var actual = UnifiedGenerators.GenerateProgramFromFile(
                    FixtureUtil.GetInputPath(
                            "Aspect", "Call",
                            "Fibonacci_expectation_before" + ext));

            Call.InsertAtBeforeCallByName(
                    model, "fibonacci",
                    UcoGenerator.CreateAdvice(language, code));

            Assert.That(
                    model,
                    Is.EqualTo(actual).Using(
                            StructuralEqualityComparer.Instance));
        }

        [Test]
        public void WeavingAtAfterCallAll() {
            var model = UnifiedGenerators.GenerateProgramFromFile(_studentPath);
            var actual =
                    UnifiedGenerators.GenerateProgramFromFile(
                            FixtureUtil.GetAopExpectationPath(
                                    "Java", "Student_callAfter.java"));

            Call.InsertAtAfterCallAll(
                    model, UcoGenerator.CreateAdvice("Java", "Console.Write();"));

            Assert.That(
                    model,
                    Is.EqualTo(actual).Using(
                            StructuralEqualityComparer.Instance));
        }

        [Test]
        [TestCase("write")]
        public void WeavingAtAfterCallByName(string name) {
            var model = UnifiedGenerators.GenerateProgramFromFile(_studentPath);
            var actual =
                    UnifiedGenerators.GenerateProgramFromFile(
                            FixtureUtil.GetAopExpectationPath(
                                    "Java", "Student_callAfter.java"));

            Call.InsertAtAfterCallByName(
                    model, name,
                    UcoGenerator.CreateAdvice("Java", "Console.Write();"));

            Assert.That(
                    model,
                    Is.EqualTo(actual).Using(
                            StructuralEqualityComparer.Instance));
        }

        [Test]
        [TestCase("^w")]
        public void WeavingAtAfterCallByRegex(string regex) {
            var model = UnifiedGenerators.GenerateProgramFromFile(_studentPath);
            var actual =
                    UnifiedGenerators.GenerateProgramFromFile(
                            FixtureUtil.GetAopExpectationPath(
                                    "Java", "Student_callAfter.java"));

            Call.InsertAtAfterCall(
                    model, new Regex(regex),
                    UcoGenerator.CreateAdvice("Java", "Console.Write();"));

            Assert.That(
                    model,
                    Is.EqualTo(actual).Using(
                            StructuralEqualityComparer.Instance));
        }

        [Test]
        public void WeavingAtBeforeCallAll() {
            var model = UnifiedGenerators.GenerateProgramFromFile(_studentPath);
            var actual =
                    UnifiedGenerators.GenerateProgramFromFile(
                            FixtureUtil.GetAopExpectationPath(
                                    "Java", "Student_callBefore.java"));

            Call.InsertAtBeforeCallAll(
                    model, UcoGenerator.CreateAdvice("Java", "Console.Write();"));

            Assert.That(
                    model,
                    Is.EqualTo(actual).Using(
                            StructuralEqualityComparer.Instance));
        }

        [Test]
        [TestCase("write")]
        public void WeavingAtBeforeCallByName(string name) {
            var model = UnifiedGenerators.GenerateProgramFromFile(_studentPath);
            var actual =
                    UnifiedGenerators.GenerateProgramFromFile(
                            FixtureUtil.GetAopExpectationPath(
                                    "Java", "Student_callBefore.java"));

            Call.InsertAtBeforeCallByName(
                    model, name,
                    UcoGenerator.CreateAdvice("Java", "Console.Write();"));

            Assert.That(
                    model,
                    Is.EqualTo(actual).Using(
                            StructuralEqualityComparer.Instance));
        }

        [Test]
        [TestCase("^w")]
        public void WeavingAtBeforeCallByRegex(string regex) {
            var model = UnifiedGenerators.GenerateProgramFromFile(_studentPath);
            var actual =
                    UnifiedGenerators.GenerateProgramFromFile(
                            FixtureUtil.GetAopExpectationPath(
                                    "Java", "Student_callBefore.java"));

            Call.InsertAtBeforeCall(
                    model, new Regex(regex),
                    UcoGenerator.CreateAdvice("Java", "Console.Write();"));

            Assert.That(
                    model,
                    Is.EqualTo(actual).Using(
                            StructuralEqualityComparer.Instance));
        }
    }
}