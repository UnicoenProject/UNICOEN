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

using System;
using System.IO;
using NUnit.Framework;
using Paraiba.Text;
using Unicoen.Languages.C;
using Unicoen.Languages.Java;
using Unicoen.Languages.JavaScript;
using Unicoen.Tests;

namespace Unicoen.Apps.Translator.Tests {
    public class ModelComparisonTest {
        [Test]
        public void ComparisonTest() {
            string javaFilePath = FixtureUtil.GetInputPath(
                    "Java", "Fibonacci.java");
            string cFilePath = FixtureUtil.GetInputPath("C", "fibonacci.c");
            string jsFilePath = FixtureUtil.GetInputPath(
                    "JavaScript", "fibonacci.js");

            var javaCode = File.ReadAllText(javaFilePath, XEncoding.SJIS);
            var cCode = File.ReadAllText(cFilePath, XEncoding.SJIS);
            var jsCode = File.ReadAllText(jsFilePath, XEncoding.SJIS);

            var javaModel = JavaFactory.GenerateModel(javaCode);
            var cModel = CFactory.GenerateModel(cCode);
            var jsModel = JavaScriptFactory.GenerateModel(jsCode);

            Console.WriteLine(javaModel.ToString());
        }
    }
}