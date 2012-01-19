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

using System.Linq;
using Code2Xml.Languages.Java.CodeToXmls;
using NUnit.Framework;
using Unicoen.Languages.Java.ProgramGenerators;
using Unicoen.Model;

namespace Unicoen.Apps.Findbug.Tests {
    [TestFixture]
    public class DefUseAnalyzerTest {
        [Test]
        public void GetDefines() {
            var ast = JavaCodeToXml.Instance.Generate(
                    "{ int i; i = 1; }", p => p.block());
            var codeObject = JavaProgramGeneratorHelper.CreateBlock(ast);

            var definitions = DefUseAnalyzer.FindDefines(codeObject).ToArray();

            // i = 1; の i に該当するUnifiedIdentifierが得られるはず
            var expected = new[]
            { codeObject.Descendants<UnifiedIdentifier>().Last() };
            Assert.That(definitions, Is.EqualTo(expected));
        }

        [Test]
        public void GetUses() {
            var ast = JavaCodeToXml.Instance.Generate(
                    "{ int i, j; i = 1; j = i; }", p => p.block());
            var codeObject = JavaProgramGeneratorHelper.CreateBlock(ast);

            var definitions = DefUseAnalyzer.FindUses(codeObject).ToArray();

            // j = i; の i に該当するUnifiedBinaryExpressionが得られるはず
            var expected = new[]
            { codeObject.Descendants<UnifiedIdentifier>().Last() };
            Assert.That(definitions, Is.EqualTo(expected));
        }
    }
}