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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Unicoen.Apps.RefactoringDSL.NamespaceDetector;
using Unicoen.Languages.Java;
using Unicoen.Model;
using Unicoen.TestUtils;
using Unicoen.Tests;

namespace Unicoen.Apps.RefactoringDSL.Tests.NamespaceDetector {
    public class ApplicationTest {
        private UnifiedProgram _model;

        [SetUp]
        public void SetUp() {
            var inputPath = FixtureUtil.GetInputPath(
                    "Java", "default", "Namespace.java");
            var code = File.ReadAllText(inputPath, Encoding.Default);
            _model = JavaFactory.GenerateModel(code);
        }

        [Test]
        public void 関数呼び出しの所属空間を特定できる() {
            var callNode = _model.FirstDescendant<UnifiedCall>();
            var belongingNamespace = Application.GetBelongingNamespace(callNode);
            Console.WriteLine(belongingNamespace.GetNamespaceString());
        }

        [Test]
        public void 自分の親を探して関数の宣言部分を取得できる() {
            var callNode = _model.FirstDescendant<UnifiedCall>();
            var definition = Application.FindDefinition(callNode, _model);
            Assert.That(definition != null);
            Assert.That(
                    definition.Name.Name,
                    Is.EqualTo(
                            ((UnifiedVariableIdentifier)callNode.Function).Name));
        }

        [Test]
        public void 自分の親を探して変数の宣言部分を探す() {
            // Expression 以下の VariableIdentifier を取り出す
            var viList = new List<UnifiedVariableIdentifier>();
            foreach (
                    var unifiedVariableIdentifiers in
                            _model.Descendants<UnifiedBinaryExpression>().Select
                                    (
                                            e =>
                                            e.Descendants
                                                    <UnifiedVariableIdentifier>(
                                                            ))) {
                foreach (var uvi in unifiedVariableIdentifiers) {
                    viList.Add(uvi);
                }
            }
            foreach (
                    var unifiedVariableIdentifiers in
                            _model.Descendants<UnifiedUnaryExpression>().Select(
                                    e =>
                                    e.Descendants<UnifiedVariableIdentifier>())) {
                foreach (var uvi in unifiedVariableIdentifiers) {
                    viList.Add(uvi);
                }
            }
            foreach (
                    var unifiedVariableIdentifiers in
                            _model.Descendants<UnifiedTernaryExpression>().
                                    Select(
                                            e =>
                                            e.Descendants
                                                    <UnifiedVariableIdentifier>(
                                                            ))) {
                foreach (var uvi in unifiedVariableIdentifiers) {
                    viList.Add(uvi);
                }
            }

            Console.WriteLine(viList.Count);
            foreach (var vi in viList) {
                Console.WriteLine(vi);
            }
        }

        [Test]
        public void 関数が呼ばれている部分を探す() {
            var fdNode = _model.FirstDescendant<UnifiedFunctionDefinition>();
            var brothers = GetBrotherNode(fdNode);
            foreach (var brother in brothers) {
                var callNodes = brother.Descendants<UnifiedCall>();
            }
        }

        // 自分の兄弟ノード（自分も含む）を取得する
        public static IEnumerable<IUnifiedElement> GetBrotherNode(
                UnifiedElement node) {
            return node.FirstAncestor<IUnifiedElement>().Descendants();
        }
    }
}