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

using System.Collections.Generic;
using System.IO;
using System.Linq;
using Code2Xml.Core;
using NUnit.Framework;
using Unicoen.CodeGenerators;
using Unicoen.Languages.Tests;
using Unicoen.ProgramGenerators;
using Unicoen.TestUtils;
using Unicoen.Tests;

namespace Unicoen.Languages.Python2.Tests {
    public partial class Python2Fixture : Fixture {

        /// <summary>
        ///   テスト時に入力されるA.xxxファイルのメソッド宣言の中身です。 Java言語であれば， <c>class A { public void M1() { ... } }</c> の...部分に このプロパティで指定されたコード断片を埋め込んでA.javaファイルが生成されます。
        /// </summary>
        public override IEnumerable<TestCaseData> TestCodes {
            get {
                return new[] {
                        "a = 1",
                        "class A: pass",
                }.Select(s => new TestCaseData(s));
            }
        }

        /// <summary>
        ///   テスト時に入力するファイルパスの集合です．
        /// </summary>
        public override IEnumerable<TestCaseData> TestFilePaths {
            get {
                // 必要に応じて以下の要素をコメントアウト
                return new[] {
                        "Block1",
                        "Block2",
                        "Block3",
                        "Fibonacci",
                }
                        .Select(
                                s =>
                                new TestCaseData(
                                        FixtureUtil.GetInputPath(
                                                LanguageName, s + Extension)));
            }
        }

        /// <summary>
        ///   テスト時に入力するプロジェクトファイルのパスとコンパイル処理の組み合わせの集合です．
        /// </summary>
        public override IEnumerable<TestCaseData> TestProjectInfos {
            get {
                return
                        SetUpTornade()
                                .Concat(SetUpPyPy())
                        ;
            }
        }

        public override IEnumerable<TestCaseData> TestHeavyProjectInfos {
            get { yield break; }
        }

    }
}