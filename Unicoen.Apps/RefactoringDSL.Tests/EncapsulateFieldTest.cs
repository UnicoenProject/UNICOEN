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
using System.Text;
using NUnit.Framework;
using Unicoen.Languages.Java;
using Unicoen.Model;
using Unicoen.TestUtils;
using Unicoen.Tests;

namespace Unicoen.Apps.RefactoringDSL.Tests {
    public class EncapsulateFieldTest {
        private UnifiedProgram _model;

        [SetUp]
        public void SetUp() {
            var inputPath = FixtureUtil.GetInputPath(
                    "Java", "default", "Encapsulate.java");
            var code = File.ReadAllText(inputPath, Encoding.Default);
            _model = JavaFactory.GenerateModel(code);
        }

        [Test]
        public void リファクタリングする() {
            var enc = new EncapsulateField(_model);
            const string targetClassName = "Foo";
            var refactored = enc.Refactor(targetClassName);
            Console.WriteLine(JavaFactory.GenerateCode(refactored));
        }
    }
}