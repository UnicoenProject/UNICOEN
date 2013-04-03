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
using System.Linq;
using NUnit.Framework;
using Unicoen.Languages.Tests;
using Unicoen.TestUtils;

namespace Unicoen.Languages.C.Tests {
    public partial class CFixture : Fixture {
        /// <summary>
        ///   テスト時に入力されるA.xxxファイルのメソッド宣言の中身です。 Java言語であれば， <c>class A { public void M1() { ... } }</c> の...部分に このプロパティで指定されたコード断片を埋め込んでA.javaファイルが生成されます。
        /// </summary>
        public override IEnumerable<TestCaseData> TestCodes {
            get {
                var statements = new[] {
                        "{ func(); }",
                }.Select(s => new TestCaseData(DecorateToCompile(s)));

                var codes = new[] {
                        "int main() { return 0; }",
                }.Select(s => new TestCaseData(s));

                return statements.Concat(codes);
            }
        }

        /// <summary>
        ///   テスト時に入力するファイルパスの集合です．
        /// </summary>
        public override IEnumerable<TestCaseData> TestFilePaths {
            get {
                // 必要に応じて以下の要素をコメントアウト
                return new[] {
                        "fibonacci",
                        "fibonacci2",
                        "empty",
                        "assignment",
                        "Block1",
                        "Block2",
                        "Block3",
                        "hello",
                        "test",
                        "fact",
                        //"LineDriveController",
                        //"ActionController",
                        "switchNest",
                        "pointer",
                }
                        .Select(
                                s =>
                                        new TestCaseData(
                                                FixtureUtil.GetInputPath(
                                                        "C", s + Extension)));
            }
        }

        /// <summary>
        ///   テスト時に入力するプロジェクトファイルのパスとコンパイル処理の組み合わせの集合です．
        /// </summary>
        public override IEnumerable<TestCaseData> TestProjectInfos {
            get { yield break; }
        }

        public override IEnumerable<TestCaseData> TestHeavyProjectInfos {
            get { yield break; }
        }
    }
}